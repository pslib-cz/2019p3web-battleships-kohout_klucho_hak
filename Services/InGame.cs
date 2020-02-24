using BattleShips.Data;
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
        public void Fire(int posX, int posY, string userId)
        {
            throw new NotImplementedException();
        }

        public IList<ShipPiece> Fleet(int userGameId, int gameId)
        {
            throw new NotImplementedException();
        }

        public void GameEnd(int winnerId, int gameId)
        {
            throw new NotImplementedException();
        }

        public IList<NavyBattlePiece> GetBoards()
        {
            throw new NotImplementedException();
        }

        public Game GetGame(int id)
        {
            throw new NotImplementedException();
        }

        public UserGame GetUserGame(string userId, int gameId)
        {
            throw new NotImplementedException();
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
