using BattleShips.Data;
using BattleShips.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    /// <summary>
    /// Holds logic, data manipulation and creation for all stages of the already created game.
    /// </summary>
    public class InGame : IGameSetup, IGameBattle, ISiteFunctionality, IShipPlacement
    {
        //TODO Robert smazat migrace vytvořené pro SQL server a udělat nové
        //TODO Robert vytvořít Seed.cshtml, kde se naseedují základní data, ships, ship pieces, nějací uživatelé, game, usergames, navybattlepieces (minimální data pro otestování hry, založení hry)
        //TODO Robert podle tutorialu dodělá identity, vytvořit admin a normální user
        //TODO Robert GameList, Index
        //TODO Vojta AdminGameSetup.cshtml - Zde admin nastaví jaké ships a parametry můžou uživatelé nastavovat při vytváření hry, GameSetup.cshtml - Zde uživatelé nastaví svoje hry (načítat seznam dostupných ships z databáze (IList<Ships> setupShips {get; set;}))
        //TODO Vojta Dodělat ShipPlacement
        //TODO Vojta nastavit tvůrce hry jako Activního hráče ve hře.
        //TODO upozornění
        //TODO - Firing functional. It just needs design, one more check if user can still fire when there are more than 2 players. Refreshing page or somehow differently display TempData messages without nedd of reloading site.



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
            //Guid result = _session.Get<Guid>(key);
            //if (typeof(Guid).IsClass && result == null) result = (Guid)Activator.CreateInstance(typeof(Guid));
            //return result;
            //TODO - Use actual method instead placeholder for develompent 
            Guid currentGameId = new Guid("b9841419-f01f-402a-9e39-4c77321321e9");
            return currentGameId;
        }

        /// <summary>
        /// Saves active game Guid in session.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="guid"></param>
        private void SaveGame(string key, Guid guid)
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
            return _db.Games.Where(m => m.Id == currentGameId).AsNoTracking().SingleOrDefault();
        }
        //Returns Ilist of UserGames in currently active Game.
        public IList<UserGame> GetUserGamesWithUser()
        {
            Guid currentGameId = CurrentGameId;
            return _db.UserGames
                .Where(m => m.GameId == currentGameId)
                .Include(m => m.ApplicationUser)
                .Include(m => m.Game)
                .AsNoTracking().ToList();
        }

        //Returns IList of NavyBattlePieces based on UserGame Id.
        public IList<NavyBattlePiece> GetNavyBattlePieces(int userGameId)
        {
            return _db.NavyBattlePieces.Where(m => m.UserGameId == userGameId).AsNoTracking().ToList();
        }


        #region Firing
        //TODO - Refactor metodu fire pokud bude fungovat. It is a mess. :(
        //Fires at piece.
        public string Fire(int? pieceId)
        {
            string resultOfFiring = "Somenthing went wrong. :(";
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
                .AsNoTracking().SingleOrDefault();
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
            //Checks if the game piece isnt already hit.
            if (firedAtPiece.PieceState == PieceState.HittedShip || firedAtPiece.PieceState == PieceState.HittedWater)
            {
                return "You have already fired at that piece!";
            }
            //Checks if user is not trying to fire at his own piece.
            if (firedAtPiece.UserGameId == firingUserGame.Id)
            {
                return "You can not fire at your own piece!";
            }

            PieceState newState;
            switch (firedAtPiece.PieceState)
            {

                case PieceState.Water:
                    newState = PieceState.HittedWater;
                    resultOfFiring = "Splash!";
                    break;
                case PieceState.Ship:
                    newState = PieceState.HittedShip;
                    break;
                case PieceState.Margin:
                    newState = PieceState.HittedWater;
                    break;

                default:
                    newState = firedAtPiece.PieceState;
                    break;
            }
            firedAtPiece.PieceState = newState;
          

            //If usergame hits ship check if there is any navybattlepiece of ship left on his board.
            if (newState == PieceState.HittedShip)
            { 
                //Gets UserGame whose ship has been hit.
                UserGame hittedUserGame = _db.UserGames.Where(u => u.Id == firedAtPiece.UserGameId)
                                                        .Include(u => u.ApplicationUser)
                                                        .FirstOrDefault();

                resultOfFiring = $"You have destroyed piece of a {firedAtPiece.Ship.Name} belonging to players {hittedUserGame.ApplicationUser.PlayerName}s fleet.";
               
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
                        resultOfFiring = "Congratulation you have Won, everyone else was destroyed!";
                    }
                    else
                    {
                        ContinueGame(activeGame, firingUserGame);
                    }
                }
                else
                {
                    ContinueGame(activeGame, firingUserGame);
                }

            }
            else
            {
                ContinueGame(activeGame, firingUserGame);
               
            }
            _db.SaveChanges();
            return resultOfFiring;
        }

        /// <summary>
        /// Sets next player to play.
        /// </summary>
        /// <param name="firedInGame"></param>
        private void ContinueGame(Game firedInGame, UserGame firingUserGame)
        {
            //new user game firing
            List<UserGame> listUserGames = _db.UserGames.Where(u => u.GameId == firedInGame.Id).OrderBy(u => u.Id).ToList();
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

            
            firedInGame.GameRound++;
            firedInGame.CurrentPlayerId = nextPlayer.ApplicationUserId;
            _db.Games.Update(firedInGame);
            // _db.SaveChanges();
        }

        /// <summary>
        /// Ends Game if there is winner.
        /// </summary>
        /// <param name="winnerUserGame"></param>
        private bool GameEnd(UserGame winnerUserGame)
        {
            IList<UserGame> userGames = GetUserGamesWithUser();
            int losersCount = 0;
            foreach(var item in userGames)
            {
                if(item.PlayerState == PlayerState.Loser)
                {
                    losersCount++;
                }
            }
            //Checks if there is more than 1 player that hasnt lost.
            if (userGames.Count() -1 == losersCount)
            {
               
                Game game = winnerUserGame.Game;
                winnerUserGame.PlayerState = PlayerState.Winner; //Sets winner usergame, others are already losers.

                IList<ApplicationUser> loserApplicationUsers = new List<ApplicationUser>();
                ApplicationUser winnerAplicationUser = new ApplicationUser();
                foreach (var user in userGames)
                {
                    if (user.Id != winnerUserGame.Id)
                    {
                        user.ApplicationUser.TotalPlayedGames++;
                        loserApplicationUsers.Add(user.ApplicationUser);
                    }
                    else
                    {
                        user.ApplicationUser.TotalPlayedGames++;
                        user.ApplicationUser.Wins++;
                        winnerAplicationUser = user.ApplicationUser;
                    }
                }
                game.GameRound++;
                game.GameState = GameState.Ended;
                _db.Games.Update(game);
                _db.UserGames.Update(winnerUserGame);
              
                _db.ApplicationUsers.Update(winnerAplicationUser);

                ////https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext
                //using (var context = new ServiceProvider
                //{
                //    context.ApplicationUsers.UpdateRange(loserApplicationUsers);
                //    context.SaveChanges();
                //}

                //_db.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion
        #endregion



        #region IGameSetup (Klucho)
        public bool CreateNewGame(string userId, int maxPlayers, int boardSize)
        {
            try
            {
                Guid newGameId = Guid.NewGuid();
                CurrentGameId = newGameId;
                SaveGame("Game", newGameId);
                var game = new Game() { OwnerId = userId, MaxPlayers = maxPlayers, GameSize = boardSize, Id = newGameId };
                _db.Games.Add(game);
                _db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void CreateShipGames(Guid gameId, int shipId)
        {
            throw new NotImplementedException();
        }

        public List<Ship> GetShips()
        {
            return _db.Ships.ToList();
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
        public void CreateUserGame(Guid gameId, string userId)
        {
            throw new NotImplementedException();
        }



        public void ShipPlacement(int userGameId)
        {
            throw new NotImplementedException();
        }

        public void CreateBlankGameBoard(Game game)
        {
            throw new NotImplementedException();
        }



        public IList<Ship> GetGameShips(IList<ShipGame> shipGame)
        {
            throw new NotImplementedException();
        }

        public IList<ShipGame> GetShipGames(Game game)
        {
            throw new NotImplementedException();
        }
        #endregion



        #region ISiteFunctionality (Hák)
        public void RemoveGame(Guid gameId)
        {
            var game = _db.Games.SingleOrDefault(g => g.Id == gameId);
            _db.Games.Remove(game);
            _db.SaveChanges();
        }

        public void RemoveUser(string userId)
        {
            throw new NotImplementedException();
        }

        public IList<Game> GetGames(string userId)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicationUser> UsersByScore()
        {
            throw new NotImplementedException();
        }

        //public ApplicationUser GetLoggedInUser()
        //{
        //    string userId = _hca.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    return _db.ApplicationUsers.Where(o => o.Id == userId).AsNoTracking().SingleOrDefault();
        //    //throw new NotImplementedException();
        //}



        #endregion


    }
}
