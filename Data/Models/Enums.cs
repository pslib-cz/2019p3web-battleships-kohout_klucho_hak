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
        [Display(Name = "bg-primary")]
        Water,
        [Display(Name = "bg-dark")]
        Ship,
        [Display(Name = "bg-primary")]
        HitWater,
        [Display(Name = "bg-dark")]
        HitShip,
        [Display(Name = "table-secondary")]
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