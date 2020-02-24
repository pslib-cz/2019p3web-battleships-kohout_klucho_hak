using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Data
{
    public class NavyBattlePiece
    {
        [Key]
        public int Id { get; set; }

        public int PosX { get; set; }

        public int PosY { get; set; }

        public int UserGameId { get; set; }

        [ForeignKey("userGameId")]
        public UserGame UserGame { get; set; }


        //Ship id
        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public Ship Ship { get; set; }

        public bool Hidden { get; set; }

        public enum PieceState
        {
            Water = 0,
            Ship = 1,
            HittedWater = 2,
            HittedShip = 3,
            Margin = 4
        }


    }
}
