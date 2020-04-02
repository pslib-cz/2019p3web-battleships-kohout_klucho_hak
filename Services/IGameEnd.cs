using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    /// <summary>
    /// Logic, data creation and manipulation for END stage of the game. (3. stage of the game. Somebody has won the game, game and all its parts are deleted, points are added?)
    /// </summary>
    public interface IGameEnd
    {
        /// <summary>
        /// Deletes game and all its parts. Adds score for winner?
        /// </summary>
        /// <param name="winnerId"></param>
        /// <param name="gameId"></param>
        public void GameEnd(int winnerId, Guid gameId);

        public void RemoveGame(Guid gameId);
    }
}
