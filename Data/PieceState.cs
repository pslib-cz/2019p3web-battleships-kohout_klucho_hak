using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Data
{
    public enum PieceState
    {
        Water = 0,
        Ship = 1,
        HittedWater = 2,
        HittedShip = 3,
        Margin = 4
    }
}
