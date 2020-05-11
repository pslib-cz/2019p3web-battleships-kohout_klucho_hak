using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Nazev tridy když je to voda")]
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