using BattleShips.Data;
using BattleShips.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    /// <summary>
    /// Holds logic, data manipulation and creation for all stages of the already created game.
    /// </summary>
    public class InGame : IGameSetup, IGameBattle, ISiteFunctionality, IBattleShipGameLoaderSaver, IShipPlacement
    {
        //TODO Robert smazat migrace vytvořené pro SQL server a udělat nové
        //TODO Robert vytvořít Seed.cshtml, kde se naseedují základní data, ships, ship pieces, nějací uživatelé, game, usergames, navybattlepieces (minimální data pro otestování hry, založení hry)
        //TODO Robert podle tutorialu dodělá identity, vytvořit admin a normální user
        //TODO Robert GameList, Index
        //TODO Vojta AdminGameSetup.cshtml - Zde admin nastaví jaké ships a parametry můžou uživatelé nastavovat při vytváření hry, GameSetup.cshtml - Zde uživatelé nastaví svoje hry (načítat seznam dostupných ships z databáze (IList<Ships> setupShips {get; set;}))
        //TODO Vojta Dodělat ShipPlacement
        //TODO upozornění



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



        #region IBattleShipGameLoaderSaver (Sessions) (Kohout)
        public Guid LoadGame(string key)
        {
            Guid result = _session.Get<Guid>(key);
            if (typeof(Guid).IsClass && result == null) result = (Guid)Activator.CreateInstance(typeof(Guid));
            return result;
        }

        public void SaveGame(string key, Guid guid)
        {
            _session.Set(key, guid);
        }
        #endregion



        #region IGameBattle (Kohout)
        public Game GetGame(Guid _currentGameId)
        {
            //_currentGameId = CurrentGameId;

            return _db.Games.Where(m => m.Id == _currentGameId).AsNoTracking().SingleOrDefault();
        }

        public IList<UserGame> GetUserGamesWithUser(Guid gameId)
        {
            return _db.UserGames
                .Where(m => m.GameId == gameId)
                .Include(m => m.ApplicationUser)
                .AsNoTracking().ToList();
        }

        //TODO - Srovnat pro vypsání jako 2D IEnumerable
        public IList<NavyBattlePiece> GetNavyBattlePieces(int userGameId)
        {
            return _db.NavyBattlePieces.Where(m => m.UserGameId == userGameId).AsNoTracking().ToList();
        }


        #region Firing
        //TODO - Přepsat metodu fire, přebíra jeden battlePieceID
        public void Fire(List<int> navyBattlePieceIds, Game firedInGame, IList<UserGame> userGames)
        {
            //List of pieces that user fired at
            IList<NavyBattlePiece> firedAtPieces = GetFiredAtBattlePiece(navyBattlePieceIds);

            //Gets UserGame that is firing.
            UserGame firingUserGame = _db.UserGames.Where(m => m.UserId == firedInGame.CurrentPlayerId).AsNoTracking().SingleOrDefault();

            //Checks if pieces that user fired at are correct
            if (TryFiring(firedInGame, firedAtPieces, firingUserGame))
            {
                //Fires at each piece
                foreach (var piece in firedAtPieces)
                {
                    PieceState newState;
                    switch (piece.PieceState)
                    {

                        case PieceState.Water:
                            newState = PieceState.HittedWater;
                            break;
                        case PieceState.Ship:
                            newState = PieceState.HittedShip;
                            break;
                        case PieceState.Margin:
                            newState = PieceState.HittedWater;
                            break;

                        default:
                            newState = piece.PieceState;
                            break;
                    }
                    piece.PieceState = newState;

                  
                    _db.SaveChanges();
                }
                //If the game ended, when everybody lost but one, and sets states of players
                if (TryGameEnd(firedInGame))
                {
                    GameEnd(firingUserGame, firedInGame);
                }
                //Else continue in game and change active player and player states
                else
                {
                    ContinueGame(firingUserGame, userGames, firedInGame);
                }
            }
        }


        /// <summary>
        /// Changes active player and player states
        /// </summary>
        /// <param name="firingUserGame"></param>
        /// <param name="userGames"></param>
        /// <param name="firedInGame"></param>
        private void ContinueGame(UserGame firingUserGame, IList<UserGame> userGames, Game firedInGame)
        {
            //new user game firing
            List<UserGame> listUserGames = new List<UserGame>(userGames);//Convert IList to list
            UserGame nextPlayer = new UserGame();

            int index = listUserGames.FindIndex(u => u.Id == firingUserGame.Id);//Gets index of user game that is currently plaing
            
            //Populate next player if index not outOFRange
            if (index + 2 < userGames.Count())
            {
                nextPlayer = userGames[index + 1];
            }
            //Next round
            else
            {
                nextPlayer = userGames[0];
            }

            nextPlayer.PlayerState = PlayerState.Firing;
            firingUserGame.PlayerState = PlayerState.Waiting;
            firedInGame.GameRound++;
            firedInGame.CurrentPlayerId = nextPlayer.ApplicationUser.Id;
            _db.SaveChanges();
        }


        /// <summary>
        /// Gets all the pieces that user is trying to fire at
        /// </summary>
        /// <param name="navyBattlePieceIds"></param>
        /// <returns></returns>
        private IList<NavyBattlePiece> GetFiredAtBattlePiece(List<int> navyBattlePieceIds)
        {
            IList<NavyBattlePiece> output = new List<NavyBattlePiece>();
            foreach (var battlePieceId in navyBattlePieceIds)
            {
                NavyBattlePiece piece = _db.NavyBattlePieces.Where(m => m.Id == battlePieceId).SingleOrDefault(); //Piece at which user is trying to fire.
                output.Add(piece);
            }
            return output;
        }


        /// <summary>
        /// Checks if user has choosen correct pieces to fire at.
        /// </summary>
        /// <param name="firedInGame"></param>
        /// <param name="firedAtPieces"></param>
        /// <param name="firingUserGame"></param>
        /// <returns></returns>
        private bool TryFiring(Game firedInGame, IList<NavyBattlePiece> firedAtPieces, UserGame firingUserGame)
        {
            //Checks if it is users turn
            if (firingUserGame.PlayerState == PlayerState.Firing)
            {
                //Checks if user is trying to fire in active game.
                if (firedInGame.Id == LoadGame("Game"))
                {
                    //Checks if user fired at all enemy boards
                    if(firedAtPieces.Count == (firedInGame.MaxPlayers -1))
                    {
                        int numberOfSuccesfulChecks = 0;
                        foreach (var piece in firedAtPieces)
                        {
                            //Checks if the game piece isnt already hit.
                            if (piece.PieceState != PieceState.HittedShip || piece.PieceState == PieceState.HittedWater)
                            {

                                //Checks if user is not trying to fire at his own piece.
                                if (piece.UserGameId != firingUserGame.Id)
                                {
                                    numberOfSuccesfulChecks++;
                                }
                            }
                        }
                        if (numberOfSuccesfulChecks == firedAtPieces.Count())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;

        }

        
        /// <summary>
        /// Checks if game ended.
        /// </summary>
        /// <param name="game"></param>
        private bool TryGameEnd(Game game)
        {
            //TODO TryGameEnd metoda dodělat
            //Check if the game ended
            if (false)
            {
                return true;
            }
            else return false;

            //throw new NotImplementedException();
        }


        /// <summary>
        /// Ends Game
        /// </summary>
        /// <param name="winnerUserGame"></param>
        /// <param name="game"></param>
        private void GameEnd(UserGame winnerUserGame, Game game)
        {
            //Sets winners and loosers
            IList<UserGame> userGames = GetUserGamesWithUser(game.Id);
            foreach (var user in userGames)
            {
                if (user != winnerUserGame)
                {
                    user.PlayerState = PlayerState.Loser;
                    user.ApplicationUser.TotalPlayedGames++;
                }
                else user.PlayerState = PlayerState.Winner;
                user.ApplicationUser.Wins++;
            }

            game.GameState = GameState.Ended;
            _db.SaveChanges();
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

        public ApplicationUser GetLoggedInUser()
        {
            string userId = _hca.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _db.ApplicationUsers.Where(o => o.Id == userId).AsNoTracking().SingleOrDefault();
            //throw new NotImplementedException();
        }




        #endregion


    }
}
