using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Data
{
    public enum PlayerState
    {
        PlacingShips = 0,
        Firing = 1,
        Waiting = 2,
        Loser = 3, 
        Winner = 4
    }
}
