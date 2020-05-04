using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Data
{
    public enum GameState
    {
        Setup,
        ShipPlacement,
        Battle,
        Ended
    }

    public enum PieceState
    {
        Water,
        Ship,
        HitWater,
        HitShip,
        Margin
    }

    public enum PlayerState
    {
        PlacingShips,
        Playing,
        Loser,
        Winner
    }
}