using BattleShips.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.ViewModels
{
    public class ShipsShipGamesViewModel
    {
        public Ship Ship { get; set; }
        public ShipGame ShipGame { get; set; }

        public GameBoardData GameBoard { get; set; }
    }
}
