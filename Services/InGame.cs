using BattleShips.Data;
using BattleShips.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    /// <summary>
    /// Holds logic, data manipulation and creation for all stages of the already created game.
    /// </summary>
    public class InGame : IGameSetup, IGameBattle, IGameEnd, IBattleShipGameLoaderSaver, ICreation
    {
        //TODO Robert smazat migrace vytvořené pro SQL server a udělat nové
        //TODO Robert vytvořít Seed.cshtml, kde se naseedují základní data, ships, ship pieces, nějací uživatelé, game, usergames, navybattlepieces (minimální data pro otestování hry, založení hry)
        //TODO Robert podle tutorialu dodělá identity, vytvořit admin a normální user
        //TODO Robert GameList, Index
        //TODO Vojta AdminGameSetup.cshtml - Zde admin nastaví jaké ships a parametry můžou uživatelé nastavovat při vytváření hry, GameSetup.cshtml - Zde uživatelé nastaví svoje hry (načítat seznam dostupných ships z databáze (IList<Ships> setupShips {get; set;}))
        //TODO Vojta Dodělat ShipPlacement
        //TODO zjistit jestli se má přidat player, popřípadě upravit



        private readonly ApplicationDbContext _db;
        private readonly ISession _session;
        private readonly IHttpContextAccessor _hca; //Will be used for example when getting user: _hca.HttpContext.User;
        public Guid CurrentGameId { get; private set; }
        public InGame(ApplicationDbContext db, IHttpContextAccessor hca)
        {
            _db = db;
            _session = hca.HttpContext.Session;
            _hca = hca ;
            CurrentGameId = LoadGame("Game");
        }


        #region ICreation (Klucho)
        public bool CreateNewGame(string userId, int maxPlayers, int boardSize)
        {
            try
            {
                Guid newGameId = Guid.NewGuid();
                //SaveGame("Game", newGameId)
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
        #endregion


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
            _currentGameId = CurrentGameId;

            return _db.Games.Where(m => m.Id == _currentGameId).AsNoTracking().SingleOrDefault();
        }

        public void Fire(int battlePieceId)//Change state of the piece.
        { 
            NavyBattlePiece piece = _db.NavyBattlePieces.Where(m => m.Id == battlePieceId).SingleOrDefault(); //Piece at which user is trying to fire.
            Guid activeGameId = LoadGame("Game"); //Active game Guid.
            Game game = GetGame(activeGameId); //Active game.
            UserGame userGame = _db.UserGames.Where(m => m.IdentityUser.Id == game.CurrentPlayerId).AsNoTracking().SingleOrDefault();//Gets UserGame that is firing.
            Game firedGame = _db.Games.Where(m => m.Id == userGame.GameId).AsNoTracking().SingleOrDefault(); ; //Game where user fired.
            Boolean canFire = false;

            //Checks if user is trying to fire in active game.
            if(activeGameId == firedGame.Id)
            {
                //Checks if the game piece isnt already hit.
                if(piece.PieceState != PieceState.HittedShip || piece.PieceState == PieceState.HittedWater)
                {
                    //Checks if user is not trying to fire at his own piece.
                    if(piece.UserGameId != userGame.Id)
                    {
                        canFire = true;
                    }

                }
            }
            
            if (canFire)
            {
                PieceState newState;
                switch (piece.PieceState)
                {

                    case PieceState.Water:
                        newState = PieceState.HittedWater;
                        break;
                    case PieceState.Ship:
                        Console.WriteLine("Case 2");
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
        }

        public IList<UserGame> GetUserGames(Guid gameId)
        {
            return _db.UserGames.Where(m => m.GameId == gameId).AsNoTracking().ToList();
        }

        public IList<NavyBattlePiece> GetNavyBattlePieces(int userGameId)
        {
            return _db.NavyBattlePieces.Where(m => m.UserGameId == userGameId).AsNoTracking().ToList();
        }

 
        #endregion


        public IList<ShipPiece> Fleet(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public void GameEnd(int winnerId, Guid gameId)
        {
            throw new NotImplementedException();
        }


        public IList<NavyBattlePiece> GetBoards(int userGameId)
        {
            throw new NotImplementedException();
        }
        
       

        public void RemoveGame(Guid gameId)
        {
            var game = _db.Games.SingleOrDefault(g => g.Id == gameId);
            _db.Games.Remove(game);
            _db.SaveChanges();
        }

        public UserGame GetUserGame(string userId, Guid gameId)
        {
            throw new NotImplementedException();
        }


        public void ShipPlacement(int userGameid)
        {
            throw new NotImplementedException();
        }


       
    }
}
