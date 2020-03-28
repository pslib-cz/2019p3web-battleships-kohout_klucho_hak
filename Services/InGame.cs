using BattleShips.Data;
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
    public class InGame : IGameSetup, IGameBattle, IGameEnd
    {
        //todo seed database
        //todo admin setup /user setup
        //
        //session (která hra je aktivní u hráče) Ihttpcontextaccesor singleton
        private readonly ApplicationDbContext _db;
        public InGame(ApplicationDbContext db)
        {
            _db = db;
        }

        public Boolean Fire(int posX, int posY, int userGameId)
        {
            throw new NotImplementedException();
        }

        public bool Fire(int battlePieceId)
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

        public Game GetGame(Guid id)
        {
            throw new NotImplementedException();
            //return _db.Games.Where(m => m.Id == id).AsNoTracking().SingleOrDefault();
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

        public void Surrender(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
