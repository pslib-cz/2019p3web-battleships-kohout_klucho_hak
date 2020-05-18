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
        [Display(Name = "board-piece-water piece")]
        Water,
        [Display(Name = "board-piece-ship piece")]
        Ship,
        [Display(Name = "board-piece-water piece")]
        HitWater,
        [Display(Name = "board-piece-ship piece")]
        HitShip,
        [Display(Name = "board-piece-margin piece")]
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