using BattleShips.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    /// <summary>
    /// Logic, data creation and manipulation for Start stage of the game. (1. stage of the game. Users join the game, game begins when all player are ready, players place their ships)
    /// </summary>
    public interface IGameSetup
    {

        public Game GetGame(int id);
        public UserGame GetUserGame(string userId, int gameId);

        /// <summary>
        /// Loads pre set ships for a game.
        /// </summary>
        /// <param name="userGameId"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        IList<ShipPiece> Fleet(int userGameId, int gameId);

       /// <summary>
       /// Sets players fleet.
       /// </summary>
        public void ShipPlacement(int userGameid);

        

    }
}
