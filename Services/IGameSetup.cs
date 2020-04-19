using BattleShips.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    /// <summary>
    /// Logic, data creation and manipulation for create new game.
    /// </summary>
    public interface IGameSetup
    {

        public bool CreateNewGame(string userId, int maxPlayers, int boardSize);

        IList<ShipGame> CreateFleet(Guid gameId, int shipId);

        public void ShipPlacement(int userGameid);


    }
}
