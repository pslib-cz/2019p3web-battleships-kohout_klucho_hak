using BattleShips.Data;
using BattleShips.Helpers;
using BattleShips.ViewModels;
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
    public class InGame : IGameSetup, IGameBattle, ISiteFunctionality, IShipPlacement, IAdministration
    {
        private readonly ApplicationDbContext _db;
        private readonly ISession _session;
        private readonly IHttpContextAccessor _hca;
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
        public Guid GetUserId()
        {
            var userId = _hca.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid output = default;
            if (userId != null)
            {
                output = new Guid(userId);
            }
            return output;
        }
        #endregion



        #region IGameBattle (Kohout)
        // Returns currently active Game.
        public async Task<Game> GetGameAsync()
        {
            Guid currentGameId = CurrentGameId;
            return await _db.Games.Where(m => m.Id == currentGameId)
                .Include(x => x.CurrentPlayer)
                .Include(m => m.UserGames).ThenInclude(x => x.ApplicationUser).AsNoTracking().SingleOrDefaultAsync();
        }
        // Returns Ilist of UserGames in currently active Game.
        public async Task<IList<UserGame>> GetUserGamesWithUserAsync()
        {
            Guid currentGameId = CurrentGameId;
            return await _db.UserGames.Where(m => m.GameId == currentGameId)
                .Include(m => m.ApplicationUser)
                .AsNoTracking()
                .ToListAsync();
        }

        // Returns IList of NavyBattlePieces based on UserGame Id.
        public async Task<IList<NavyBattlePiece>> GetNavyBattlePiecesAsync(int userGameId)
        {
            IList<NavyBattlePiece> output;
            output = await _db.NavyBattlePieces.Where(m => m.UserGameId == userGameId).AsNoTracking().ToListAsync();

            return output;
        }

        public async Task FireAsync(int pieceId)
        {
            // Gets active game.
            var activeGame = await GetGameAsync();

            if(activeGame.GameState != GameState.Battle)
            {
                return;
            }

            // Gets piece that user is trying to fire at.
            var firedAtPiece = await GetNavyBattlePiecesByIdAsync(pieceId);

            
            // Gets UserGame that is suposed to be firing in the Game.
            var activeUserGame = await GetActiveUserGameAsync(activeGame);

            // Gets UserGame that is firing in the game
            var firingUserGame = await GetFiringUserGameAsync();

            // If firing attempt is invalid, get out of method
            if (IsValid(pieceId, firedAtPiece, activeGame, activeUserGame, firingUserGame) == false)
            {
                return;
            }

            // If usergame hits ship check if there is any navybattlepiece of ship left on his board.
            if (ChangeStateOfPiece(firedAtPiece))
            {
                // Cheks if somebody has lost
                if (await CheckForLoserAsync(firedAtPiece, firingUserGame))
                {
                    // Checks if the game hase ended because there is another loser.
                    if (GameEnd(firingUserGame) == false)
                    {
                        await ContinueGameAsync(firingUserGame);
                    }
                }
                else
                {
                    await ContinueGameAsync(firingUserGame);
                }
            }
            else
            {
                await ContinueGameAsync(firingUserGame);

            }
            await _db.SaveChangesAsync();
        }

        #region Firing Helpers
        private async Task<NavyBattlePiece> GetNavyBattlePiecesByIdAsync(int pieceId)
        {
            var output = await _db.NavyBattlePieces.Where(m => m.Id == pieceId)
               .Include(m => m.Ship)
               .SingleOrDefaultAsync();

            return output;
        }
        private async Task<UserGame> GetActiveUserGameAsync(Game activeGame)
        {
            var output = await _db.UserGames.Where(m => m.ApplicationUserId == activeGame.CurrentPlayerId).AsNoTracking().SingleOrDefaultAsync();
            return output;
        }
        private async Task<UserGame> GetFiringUserGameAsync()
        {
            var activeUserId = GetUserId();
            var output = await _db.UserGames.Where(u => u.ApplicationUserId == activeUserId)
                .Include(u => u.Game)
                .ThenInclude(x => x.UserGames)
                .ThenInclude(y => y.ApplicationUser)
                .SingleOrDefaultAsync();
            return output;
        }

        /// <summary>
        /// Checks if player that was hit lost
        /// </summary>
        /// <param name="firedAtPiece"></param>
        /// <param name="firingUserGame"></param>
        /// <returns></returns>
        private async Task<bool> CheckForLoserAsync(NavyBattlePiece firedAtPiece, UserGame firingUserGame)
        {
            bool result = false;
            // Gets UserGame whose ship has been hit.
            UserGame hittedUserGame = firingUserGame.Game.UserGames.Where(x => x.Id == firedAtPiece.UserGameId).FirstOrDefault();

            // Gets piece of ship.
            IList<NavyBattlePiece> UnhitedShipPiece = await _db.NavyBattlePieces.Where(p => p.UserGameId == firedAtPiece.UserGameId && p.PieceState == PieceState.Ship).Take(2).AsNoTracking().ToListAsync();
            // Checks if there more than one piece of ship, if not then this usergame has lost. The piece state has to be yet saved to database.
            if (UnhitedShipPiece.Count() < 2)
            {
                hittedUserGame.PlayerState = PlayerState.Loser;
                _db.UserGames.Update(hittedUserGame);
                await _db.SaveChangesAsync(); // Save to database so that in endgame the check counts even the last loser.
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Changes state of piece acordingly, and return information if ship was hit
        /// </summary>
        /// <param name="firedAtPiece"></param>
        private bool ChangeStateOfPiece(NavyBattlePiece firedAtPiece)
        {
            bool output = false;
            //Fire :)
            PieceState newState;

            if (firedAtPiece.PieceState == PieceState.Water)
            {
                newState = PieceState.HitWater;
                firedAtPiece.Hidden = false;
            }
            else
            {
                newState = PieceState.HitShip;
                firedAtPiece.Hidden = false;
                output = true;
            }

            firedAtPiece.PieceState = newState;
            _db.NavyBattlePieces.Update(firedAtPiece);
            return output;
        }

        /// <summary>
        /// Checks if firing is valid
        /// </summary>
        /// <returns></returns>
        private bool IsValid(int? pieceId, NavyBattlePiece firedAtPiece, Game activeGame, UserGame activeUserGame, UserGame firingUserGame)
        {
            var activeUserId = GetUserId();
            //Checks if game isnt already done.
            if (activeGame.GameState == GameState.Ended)
            {
                return false;
            }
            //If user that fired isnt the one that is supossed to be firing.
            if (firingUserGame.ApplicationUserId != activeUserGame.ApplicationUserId)
            {
                return false;
            }
            //Checks if user is not trying to fire at his own piece.
            if (firedAtPiece.UserGameId == firingUserGame.Id)
            {
                return false;
            }
            //Checks if the game piece isnt already hit.
            if (firedAtPiece.PieceState == PieceState.HitShip || firedAtPiece.PieceState == PieceState.HitWater)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Sets next player to play.
        /// </summary>
        /// <param name="game"></param>
        private async Task ContinueGameAsync(UserGame firingUserGame)
        {
            firingUserGame.Game.UserRound++;
            //new user game firing
            List<UserGame> listUserGames = await _db.UserGames.Where(u => u.GameId == firingUserGame.Game.Id).OrderBy(u => u.Id).ToListAsync();
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
        public bool CreateNewGame(Guid userId)
        {
            try
            {
                Guid newGameId = Guid.NewGuid();
                var game = new Game() { OwnerId = userId, MaxPlayers = 2, GameSize = 10, Id = newGameId, CurrentPlayerId = userId };
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
                    Ship = piece.Ship,
                    Hidden = false
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

        public IList<NavyBattlePiece> GetDataForGameboard(Ship ship)
        {
            var navyBattlePieces = ConvertToNavyBattlePiece(ship.ShipPieces);
            return navyBattlePieces;
        }

        //nastaví hru
        public void Setgame(int maxPlayers, int gameSize)
        {
            Game game = _db.Games.Where(x => x.Id == CurrentGameId).FirstOrDefault();
            game.GameSize = gameSize;
            game.CurrentPlayerId = game.OwnerId;
            game.MaxPlayers = maxPlayers;
            game.GameState = GameState.ShipPlacement;
            _db.Games.Update(game);
            _db.SaveChanges();
            CreateUserGame();
            Guid userId = GetUserId();
            UserGame createdUserGame = _db.UserGames.Where(y => y.GameId == CurrentGameId && y.ApplicationUserId == userId)
                .Include(z => z.Game)
                .AsNoTracking()
                .FirstOrDefault();
            CreateBlankGameBoard(createdUserGame);
        }



        //dostupné lodě ze kterých si uživatel bude vybírat
        public List<Ship> GetShips()
        {
            return _db.Ships.Where(x => x.IsAllowed == true)
                .Include(x => x.ShipPieces)
                .AsNoTracking().ToList();
        }

        public ShipGame GetShipGame(int shipId)
        {
            return _db.ShipGames.Where(x => x.ShipId == shipId && x.GameId == CurrentGameId).AsNoTracking().FirstOrDefault();
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

        public IList<NavyBattlePiece> GetChosenShip(int shipId)
        {
            IList<NavyBattlePiece> result = new List<NavyBattlePiece>();
            ShipGame shipGame = _db.ShipGames.Where(x => x.ShipId == shipId && x.GameId == CurrentGameId)
                .Include(x => x.Ship)
                .ThenInclude(y => y.ShipPieces)
                .SingleOrDefault();

            result = ConvertToNavyBattlePiece(shipGame.Ship.ShipPieces);
            
            return result;
        }
        // upraví prázdné hrací pole a přidá lod
        public void PlaceAShip(int pieceId)
        {
            throw new NotImplementedException();
        }
        public IList<GameBoardData> PopulateGameBoards(IList<List<NavyBattlePiece>> chosenShips, int? shipId)
        {

            IList<GameBoardData> output = new List<GameBoardData>();

            if (shipId is null)
            {
                // inicialization of All gameboards for every choosen ship
                foreach (var listOfPieces in chosenShips)
                {
                    GameBoardData newBoard = new GameBoardData(listOfPieces, null, null, "GameSetup");
                    output.Add(newBoard);
                }
            }
            else //Pokud je vybraná lod tak se již nezobrazuje v nabídce
            {
                foreach (var listOfPieces in chosenShips)
                {
                    if (listOfPieces[0].Ship.Id != shipId)
                    {
                        GameBoardData newBoard = new GameBoardData(listOfPieces, null, null, "GameSetup");
                        output.Add(newBoard);
                    }
                }
            }
            return output;
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
                        TypeId = 1,
                        Hidden = true
                    };
                    _db.NavyBattlePieces.Add(navyBattlePiece);
                    _db.SaveChanges();
                }
            }
        }


        public UserGame GetUserGame()
        {
            var userId = GetUserId();
            var output = _db.UserGames.Where(x => x.ApplicationUserId == userId && x.GameId == CurrentGameId).Include(x => x.Game).AsNoTracking().FirstOrDefault();
            return output;
        }

        public IList<NavyBattlePiece> GetGameBoard()
        {
            var userGame = GetUserGame();
            var output = _db.NavyBattlePieces.Where(x => x.UserGameId == userGame.Id).AsNoTracking().ToList();
            return output;
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
            Guid userId = GetUserId();
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
            Guid userId = GetUserId();
            Game setupGame = _db.Games.Where(o => o.OwnerId == userId && o.GameState == GameState.Setup).AsNoTracking().SingleOrDefault();
            if (setupGame is null)
            {
                CreateNewGame(userId);
            }
            else
            {
                SaveGame("Game", setupGame.Id);
            }
        }
        public void JoinShipPlacement()
        {
            var userGame = GetUserGame();
            if (userGame is null)
            {
                CreateUserGame();
                var newUserGame = GetUserGame();
                CreateBlankGameBoard(newUserGame);
            }
        }

        public IList<ApplicationUser> GetTopUsers()
        {
            IList<ApplicationUser> applicationUsers = _db.ApplicationUsers.OrderByDescending(o => o.Wins).Take(10).AsNoTracking().ToList();

            return applicationUsers;
        }

        public ApplicationUser GetLoggedInUser()
        {
            Guid userId = GetUserId();
            return _db.ApplicationUsers.Where(o => o.Id == userId).AsNoTracking().SingleOrDefault();
            //throw new NotImplementedException();
        }
        #endregion



        #region IAdministration
        public IList<ApplicationUser> GetAllUsers()
        {
            IList<ApplicationUser> applicationUsers = _db.ApplicationUsers.AsNoTracking().ToList();

            return applicationUsers;
        }

        /// <summary>
        /// Seraches users by email or playername
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public IList<ApplicationUser> SearchUser(string searchTerm)
        {
            IList<ApplicationUser> applicationUsers = new List<ApplicationUser>();
            searchTerm = searchTerm.Trim();
            if (searchTerm.Contains("@"))
            {
                applicationUsers = _db.ApplicationUsers.Where(x => x.Email.Contains(searchTerm)).AsNoTracking().ToList();
            }
            else
            {
                applicationUsers = _db.ApplicationUsers.Where(x => x.PlayerName.Contains(searchTerm)).AsNoTracking().ToList();

            }
            return applicationUsers;
        }
        public ApplicationUser GetUserDetail(Guid userId)
        {
            ApplicationUser applicationUser = _db.ApplicationUsers.Where(x => x.Id == userId).AsNoTracking().FirstOrDefault();

            return applicationUser;
        }
        public IList<Game> GetUsersGames(Guid userId)
        {
            ApplicationUser applicationUser = _db.ApplicationUsers.Where(x => x.Id == userId)
               .Include(x => x.UserGames).ThenInclude(y => y.Game).ThenInclude(y => y.Owner)
               .Include(x => x.UserGames).ThenInclude(y => y.Game).ThenInclude(y => y.CurrentPlayer)
                .FirstOrDefault();

            IList<Game> output = new List<Game>();
            foreach (var userGame in applicationUser.UserGames)
            {
                output.Add(userGame.Game);
            }
            return output;
        }
        public void UpdatePlayerName(string playerName, Guid id)
        {
            ApplicationUser applicationUser = _db.ApplicationUsers.Where(x => x.Id == id).FirstOrDefault();
            applicationUser.PlayerName = playerName;
            _db.ApplicationUsers.Update(applicationUser);
            _db.SaveChanges();
        }
        public bool DeleteUser(Guid id)
        {
            bool result = false;
            try
            {
                ApplicationUser applicationUser = _db.ApplicationUsers.Where(x => x.Id == id).FirstOrDefault();
                _db.ApplicationUsers.Remove(applicationUser);
                _db.SaveChanges();
                result = true;
            }
            catch
            {

                result = false;
            }
            return result;
        }
        public void AllowShip(int id)
        {
            var ship = _db.Ships.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
            ship.IsAllowed = true;
            _db.Ships.Update(ship);
            _db.SaveChanges();
        }
        public void DisallowShip(int id)
        {
            var ship = _db.Ships.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
            ship.IsAllowed = false;
            _db.Ships.Update(ship);
            _db.SaveChanges();
        }

        public IList<Ship> GetAllShips()
        {
            return _db.Ships
                .Include(x => x.ShipPieces)
                .AsNoTracking().ToList();
        }
        #endregion
    }
}
