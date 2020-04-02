using BattleShips.Data;
using BattleShips.Helpers;
using Microsoft.AspNetCore.Http;
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
        //todo seed database
        //todo admin setup /user setup
        //Todo jeden service


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





        public void SaveGame(string key, Guid guid)
        {
            _session.Set(key, guid);
        }

        public Guid LoadGame(string key)
        {
            Guid result = _session.Get<Guid>(key);
            if (typeof(Guid).IsClass && result == null) result = (Guid)Activator.CreateInstance(typeof(Guid));
            return result;
        }
        public void Fire(int battlePieceId, PieceState currentState)//Change state of the piece.
        {
            NavyBattlePiece piece = _db.NavyBattlePieces.Where(m => m.Id == battlePieceId).AsNoTracking().SingleOrDefault();
            PieceState newState;
            switch (currentState)
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
                    newState = currentState;
                    break;
            }
            piece.PieceState = newState;
            //TODO Save changes to database right way
            _db.SaveChanges();
            throw new NotImplementedException();
        }
        public PieceState GetPieceState(int battlePieceId)
        {

            throw new NotImplementedException();
        }
        public IList<ShipPiece> Fleet(int userGameId, Guid gameId)
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
        
        public Game GetGame(Guid _currentGameId)
        {
            _currentGameId = CurrentGameId;
            throw new NotImplementedException();
            //return _db.Games.Where(m => m.Id == _currentGameId).AsNoTracking().SingleOrDefault();
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

        public IList<UserGame> GetUserGames(Guid gameId)
        {
            throw new NotImplementedException();
            //return _db.UserGames.Where(m => m.GameId == gameId ).AsNoTracking().ToList();
        }

        public void ShipPlacement(int userGameid)
        {
            throw new NotImplementedException();
        }


        public IList<NavyBattlePiece> GetNavyBattlePieces(int userGameId)
        {
            throw new NotImplementedException();
            //return _db.NavyBattlePieces.Where(m => m.UserGameId == userGameId ).AsNoTracking().ToList();
        }
    }
}
