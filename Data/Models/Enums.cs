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
        [Display(Name = "piece board-piece-water")]
        Water,
        [Display(Name = "bg-piece board-piece-ship")]
        Ship,
        [Display(Name = "bg-piece board-piece-water")]
        HitWater,
        [Display(Name = "bg-piece board-piece-ship")]
        HitShip,
        [Display(Name = "table-piece board-piece-margin")]
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