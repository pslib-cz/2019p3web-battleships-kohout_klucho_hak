﻿using BattleShips.Data;
using BattleShips.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    /// <summary>
    /// Holds logic, data manipulation and creation for all stages of the already created game.
    /// </summary>
    public class InGame : IGameSetup, IGameBattle, ISiteFunctionality, IShipPlacement
    {


        //TODO Robert dodělá identity, vytvořit admin a normální user
        //TODO Robert => Vojta AdminGameSetup.cshtml - Zde admin nastaví jaké ships a parametry můžou uživatelé nastavovat při vytváření hry, GameSetup.cshtml - Zde uživatelé nastaví svoje hry (načítat seznam dostupných ships z databáze (IList<Ships> setupShips {get; set;}))
        //TODO Vojta Dodělat ShipPlacement
  



        private readonly ApplicationDbContext _db;

        private readonly ISession _session;
        private readonly IHttpContextAccessor _hca; //Will be used for example when getting user: _hca.HttpContext.User;
        public Guid CurrentGameId { get; private set; }
        public InGame(ApplicationDbContext db, IHttpContextAccessor hca)
        {
            _db = db;
            _session = hca.HttpContext.Session;
            _hca = hca;
            CurrentGameId = LoadGame("Game");

        }



        #region Session for Active Game and Getting logged in User (Kohout)
        /// <summary>
        /// Returns active game Guid.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private Guid LoadGame(string key)
        {
            Guid result = _session.Get<Guid>(key);
            if (typeof(Guid).IsClass && result == null) result = (Guid)Activator.CreateInstance(typeof(Guid));
            return result;
        }

        /// <summary>
        /// Saves active game Guid in session.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="guid"></param>
        public void SaveGame(string key, Guid guid)
        {
            _session.Set(key, guid);
        }

        //Gets id of logged in user
        public string GetUserId()
        {
            var output = _hca.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return output;
        }
        #endregion



        #region IGameBattle (Kohout)
        //Returns currently active Game.
        public Game GetGame()
        {
            Guid currentGameId = CurrentGameId;
            return _db.Games.Where(m => m.Id == currentGameId).Include(m => m.UserGames).ThenInclude(x => x.ApplicationUser).AsNoTracking().SingleOrDefault();
        }
        //Returns Ilist of UserGames in currently active Game.
        public IList<UserGame> GetUserGamesWithUser()
        {
            Guid currentGameId = CurrentGameId;
            return _db.UserGames
                .Where(m => m.GameId == currentGameId)
                .Include(m => m.ApplicationUser)
                .AsNoTracking()
                .ToList();
        }

        //Returns IList of NavyBattlePieces based on UserGame Id.
        public IList<NavyBattlePiece> GetNavyBattlePieces(int userGameId)
        {
            IList<NavyBattlePiece> output;
            output = _db.NavyBattlePieces.Where(m => m.UserGameId == userGameId).AsNoTracking().ToList();

            return output;
        }


        #region Firing
        //TODO - Refactor metodu fire pokud bude fungovat. It is a mess. :(
        //Fires at piece.
        public string Fire(int? pieceId)
        {
            string resultOfFiring = "Somenthing went wrong :( Try Again.";
            if (pieceId == null)
            {
                return "Somenthing went wrong, I did not get any piece to fire at. :(";
            }

            //Gets piece that user is trying to fire at.
            NavyBattlePiece firedAtPiece = _db.NavyBattlePieces.Where(m => m.Id == pieceId)
                .Include(m => m.Ship)
                .SingleOrDefault();

            //Gets active game.
            Game activeGame = GetGame();

            //Gets UserGame that is suposed to be firing in the Game.
            UserGame activeUserGame = _db.UserGames.Where(m => m.ApplicationUserId == activeGame.CurrentPlayerId).AsNoTracking().SingleOrDefault();
            //Gets UserGame that is firing in the game
            string activeUserId = GetUserId();
            UserGame firingUserGame = _db.UserGames.Where(u => u.ApplicationUserId == activeUserId)
                .Include(u => u.Game)
                .ThenInclude(x => x.UserGames)
                .ThenInclude(y => y.ApplicationUser)
                .SingleOrDefault();

            //Checks if game isnt already done.
            if (activeGame.GameState == GameState.Ended)
            {
                return "This game has already ended, you cannot play anymore.";
            }
            //If user that fired isnt the one that is supossed to be firing.
            if (firingUserGame.ApplicationUserId != activeUserGame.ApplicationUserId)
            {
                return "It is not your turn.";
            }
            //Checks if user is not trying to fire at his own piece.
            if (firedAtPiece.UserGameId == firingUserGame.Id)
            {
                return "You can not fire at your own piece!";
            }
            //Checks if the game piece isnt already hit.
            if (firedAtPiece.PieceState == PieceState.HitShip || firedAtPiece.PieceState == PieceState.HitWater)
            {
                return "You have already fired at that piece!";
            }


            //Fire :)
            PieceState newState;
            if (firedAtPiece.PieceState == PieceState.Water)
            {
                newState = PieceState.HitWater;
                resultOfFiring = "Splash!";
            }
            else
            {
                newState = PieceState.HitShip;
            }
            firedAtPiece.PieceState = newState;
            _db.NavyBattlePieces.Update(firedAtPiece);



            //If usergame hits ship check if there is any navybattlepiece of ship left on his board.
            if (newState == PieceState.HitShip)
            {

                //Gets UserGame whose ship has been hit.
                UserGame hittedUserGame = firingUserGame.Game.UserGames.Where( x => x.Id == firedAtPiece.UserGameId).FirstOrDefault();

                resultOfFiring = $"You have destroyed piece of a {firedAtPiece.Ship.Name} belonging to {hittedUserGame.ApplicationUser.PlayerName}s fleet.";

                //Gets piece of ship.
                IList<NavyBattlePiece> UnhitedShipPiece = _db.NavyBattlePieces.Where(p => p.UserGameId == firedAtPiece.UserGameId && p.PieceState == PieceState.Ship).Take(2).AsNoTracking().ToList();

                //Checks if there more than one piece of ship, if not then this usergame has lost. The piece state has to be yet saved to database.
                if (UnhitedShipPiece.Count() < 2) //Check for default value. EqualityComparer<NavyBattlePiece>.Default.Equals(UnhitedShipPiece, default
                {
                    resultOfFiring = $"You have destroyed the last piece of ship in {hittedUserGame.ApplicationUser.PlayerName}s fleet.";

                    hittedUserGame.PlayerState = PlayerState.Loser;
                    _db.UserGames.Update(hittedUserGame);
                    _db.SaveChanges();//Save to database so that in endgame the check counts even the last loser.

                    //Checks if the game hase ended because there is another loser.
                    if (GameEnd(firingUserGame))
                    {
                        resultOfFiring = "Congratulations you have Won, everyone else was destroyed!";
                    }
                    else
                    {
                        ContinueGame(firingUserGame);
                    }
                }
                else
                {
                    ContinueGame(firingUserGame);
                }

            }
            else
            {
                ContinueGame(firingUserGame);

            }
            _db.SaveChanges();
            return resultOfFiring;
        }

        /// <summary>
        /// Sets next player to play.
        /// </summary>
        /// <param name="game"></param>
        private void ContinueGame(UserGame firingUserGame)
        {
            firingUserGame.Game.UserRound++;
            //new user game firing
            List<UserGame> listUserGames = _db.UserGames.Where(u => u.GameId == firingUserGame.Game.Id).OrderBy(u => u.Id).ToList();
            //Checks if user fired at every enemy (Needed for more than 2 players)
            if (firingUserGame.Game.UserRound >= listUserGames.Count() - 1)
            {
                UserGame nextPlayer = new UserGame();

                int index = listUserGames.FindIndex(u => u.Id == firingUserGame.Id);//Gets index of user game that is currently plaing

                //Populate next player if index not outOFRange
                if (index + 1 < listUserGames.Count())
                {
                    nextPlayer = listUserGames[index + 1];
                }
                //Next round
                else
                {
                    nextPlayer = listUserGames[0];
                }
                firingUserGame.Game.CurrentPlayerId = nextPlayer.ApplicationUserId;
                firingUserGame.Game.UserRound = 0;
            }

            firingUserGame.Game.GameRound++;
            _db.Games.Update(firingUserGame.Game);

        }

        /// <summary>
        /// Ends Game if there is winner.
        /// </summary>
        /// <param name="winnerUserGame"></param>
        private bool GameEnd(UserGame winnerUserGame)
        { 
            int losersCount = 0;
            foreach (var item in winnerUserGame.Game.UserGames)
            {
                if (item.PlayerState == PlayerState.Loser)
                {
                    losersCount++;
                }
            }

            //Checks if there is more than 1 player that hasnt lost.
            if (winnerUserGame.Game.UserGames.Count() - 1 == losersCount)
            {

                winnerUserGame.PlayerState = PlayerState.Winner; //Sets winner usergame, others are already losers.

                //IList<ApplicationUser> loserApplicationUsers = new List<ApplicationUser>();
                ApplicationUser winnerAplicationUser = new ApplicationUser();
                foreach (var user in winnerUserGame.Game.UserGames)
                {
                    if (user.Id != winnerUserGame.Id)
                    {
                        user.ApplicationUser.TotalPlayedGames++;
                        _db.ApplicationUsers.Update(user.ApplicationUser);
                        //loserApplicationUsers.Add(user.ApplicationUser);
                    }
                    else
                    {
                        user.ApplicationUser.TotalPlayedGames++;
                        user.ApplicationUser.Wins++;
                        winnerAplicationUser = user.ApplicationUser;
                    }
                }
                winnerUserGame.Game.GameRound++;
                winnerUserGame.Game.GameState = GameState.Ended;
                _db.Games.Update(winnerUserGame.Game);
                _db.UserGames.Update(winnerUserGame);

                _db.ApplicationUsers.Update(winnerAplicationUser);
                return true;
            }
            return false;
        }
        #endregion
        #endregion



        #region IGameSetup (Klucho)
        //vytváří hru
        public bool CreateNewGame(string userId)
        {
            try
            {
                Guid newGameId = Guid.NewGuid();
                CurrentGameId = newGameId;
                SaveGame("Game", newGameId);
                var game = new Game() { OwnerId = userId, MaxPlayers = 2, GameSize = 10, Id = newGameId };
                _db.Games.Add(game);
                _db.SaveChanges();
                
                SaveGame("Game", game.Id); //uloží do sessiony aktivní hru 
            }
            catch
            {
                return false;
            }
            return true;
        }

        //vytvoří list dostupných lodí pro rozmístění (mezitabulka zakliknutých lodí)
        public void CreateShipGame(int? shipId)
        {
            int shipIdx = shipId ?? default(int);
            var shipGame = new ShipGame()
            {
                GameId = CurrentGameId, //new Guid("80828d2b-e7e0-4316-aa6b-cea1d08f413c") /*TODO - VOJTA - CurrentGameId*/,
                ShipId = shipIdx
            };
            _db.ShipGames.Add(shipGame);
            _db.SaveChanges();
        }

        //odstraní mezitabulku (propojení ship a game) - vybranou loď
        public void DeleteShipGame(int shipGameId)
        {
            ShipGame shipGame = _db.ShipGames.Where(x => x.Id == shipGameId).FirstOrDefault();
            _db.ShipGames.Remove(shipGame);
            _db.SaveChanges();

        }


        //vrátí mezitabulku shipGame se všema datama
        private List<ShipGame> GetShipGamesWithRelatedData()
        {
            //string userId = GetUserId(); 
            return _db.ShipGames.Where(m => m.GameId == CurrentGameId) /*new Guid("80828d2b-e7e0-4316-aa6b-cea1d08f413c")*/ 
                .Include(m => m.Ship) //model lodi (data)
                .ThenInclude(n => n.ShipPieces) //v modelu lodi ICollection ShipPieces
                .ThenInclude(s => s.Ship)
                .ToList();
        }

        //konverze BattlePiece na NavyBattlePiece
        private List<NavyBattlePiece> ConvertToNavyBattlePiece(ICollection<ShipPiece> shipPieces)
        {
            List<NavyBattlePiece> result = new List<NavyBattlePiece>();
            foreach (var piece in shipPieces)
            {
                NavyBattlePiece navyBattlePiece = new NavyBattlePiece()
                {
                    PosX = piece.PosX,
                    PosY = piece.PosY,
                    PieceState = piece.PieceState,
                    Ship = piece.Ship
                };
                result.Add(navyBattlePiece);
            }
            return result;
        }

        //vrátí list zakliknutých lodí
        public IList<List<NavyBattlePiece>> GetChosenShips()
        {
            IList<List<NavyBattlePiece>> result = new List<List<NavyBattlePiece>>();
            List<ShipGame> shipGames = GetShipGamesWithRelatedData();
            foreach (var shipGame in shipGames)
            {
                List<NavyBattlePiece> navyBattlePieces = new List<NavyBattlePiece>();
                navyBattlePieces = ConvertToNavyBattlePiece(shipGame.Ship.ShipPieces);
                result.Add(navyBattlePieces);
            }
            return result;
        }


        //nastaví hru
        public void Setgame(int maxPlayers, int gameSize)
        {
            Game game = _db.Games.Where(x => x.Id == CurrentGameId).FirstOrDefault();
            game.GameSize = gameSize;
            game.CurrentPlayerId = game.OwnerId;
            game.MaxPlayers = maxPlayers;
            _db.Games.Update(game);
            _db.SaveChanges();
            CreateUserGame();
            string userId = GetUserId();
            UserGame createdUserGame = _db.UserGames.Where(y => y.GameId == CurrentGameId && y.ApplicationUserId == userId)
                .Include(z => z.Game)
                .AsNoTracking()
                .FirstOrDefault();
            CreateBlankGameBoard(createdUserGame);
        }


        //dostupné lodě ze kterých si uživatel bude vybírat
        public List<Ship> GetShips()
        {
            return _db.Ships.AsNoTracking().ToList();
        }

        //z ShipPiece udělat NavyBattlePiece
        public IEnumerable GetShipPieces(int ShipId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEnumerable<ShipPiece>> DisplayShips(ShipPiece shipPiece)
        {
            throw new NotImplementedException();
        }

        #endregion



        #region IShipPlacement (Klucho)
        // po rozmístění lodí vytvoří novou mezitabulku (UserGame)
        public void CreateUserGame()
        {
            UserGame userGame = new UserGame 
            {
                GameId = CurrentGameId,
                ApplicationUserId = GetUserId()
            };
            _db.UserGames.Add(userGame);
            _db.SaveChanges();
        }


        // upraví prázdné hrací pole podle rozmístění lodí a uloží ho do databáze
        public void ShipPlacement(int userGameId)
        {
            throw new NotImplementedException();
        }

        // podle velikosti hry vytvoří prázdné hrací pole při načtení stránky
        public void CreateBlankGameBoard(UserGame userGame)
        {
            for (int row = 0; row < userGame.Game.GameSize; row++)
            {
                for (int piece = 0; piece < userGame.Game.GameSize; piece++)
                {
                    NavyBattlePiece navyBattlePiece = new NavyBattlePiece
                    {
                        PosY = row,
                        PosX = piece,
                        UserGameId = userGame.Id,
                        PieceState = PieceState.Water,
                        TypeId = 1 
                    };
                    _db.NavyBattlePieces.Add(navyBattlePiece);
                    _db.SaveChanges();
                }
            }
        }


        // vrátí lodě, které jsou dostupné v dané hře, pomocí listu mezitabulek shipGame
        public IList<Ship> GetGameShips(IList<ShipGame> shipGame)
        {
            throw new NotImplementedException();
        }

        // vrátí mezitabulky shipGames
        public IList<ShipGame> GetShipGames(Game game)
        {
            throw new NotImplementedException();
        }
        #endregion



        #region ISiteFunctionality (Hák)
        public bool RemoveGame(Guid gameId)
        {
            try
            {
                var game = _db.Games.SingleOrDefault(g => g.Id == gameId);
                _db.Games.Remove(game);
                _db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;

        }

        public void RemoveUser(string userId)
        {
            throw new NotImplementedException();
        }

        public IList<Game> GetUsersGames()
        {
            string userId = GetUserId();
            IList<UserGame> userGames = _db.UserGames.Where(o => o.ApplicationUserId == userId)
                .Include(o => o.Game).ThenInclude(s => s.CurrentPlayer)
                .Include(o => o.Game).ThenInclude(s => s.Owner)
                .AsNoTracking().ToList();
            IList<Game> games = new List<Game>();
            foreach (var item in userGames)
            {
                games.Add(item.Game);
            }

            return games;
        }

        public IList<ApplicationUser> UsersByScore()
        {
            throw new NotImplementedException();
        }

        public IList<Game> GetOtherGames()
        {
            return _db.Games.Where(o => o.GameState == GameState.ShipPlacement)
                .Include(o => o.Owner)
                .Include(o => o.CurrentPlayer)
                .AsNoTracking().ToList();
        }


        public void SetupGame()
        {
            string userId = GetUserId();
            Game setupGame = _db.Games.Where(o => o.OwnerId == userId && o.GameState == GameState.Setup).AsNoTracking().SingleOrDefault();
            if(setupGame is null)
            {
                CreateNewGame(userId);
            }
            else
            {
                SaveGame("Game", setupGame.Id);
            }
        }


        public IList<ApplicationUser> GetTopUsers()
        {
            IList<ApplicationUser> applicationUsers = _db.ApplicationUsers.OrderByDescending(o => o.Wins).Take(10).AsNoTracking().ToList();
      
            return applicationUsers;
        }



        public ApplicationUser GetLoggedInUser()
        {
            string userId = GetUserId();
            return _db.ApplicationUsers.Where(o => o.Id == userId).AsNoTracking().SingleOrDefault();
            //throw new NotImplementedException();
        }



        #endregion


    }
}
