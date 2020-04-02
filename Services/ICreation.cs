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
      
        public bool CreateNewGame(string userId, int maxPlayers, int boardSize);

  


    }
}
