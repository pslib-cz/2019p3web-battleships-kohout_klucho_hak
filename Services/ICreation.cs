using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    /// <summary>
    /// Logic, data creation and manipulation for creation of a new game.
    /// </summary>
    public interface ICreation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="maxPlayers"></param>
        /// <param name="boardSize"></param>
        public void CreateNewGame(string userId, int maxPlayers, int boardSize);
    }
}
