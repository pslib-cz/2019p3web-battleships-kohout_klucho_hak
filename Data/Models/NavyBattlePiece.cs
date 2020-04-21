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
        [Required]
        [Range(0, 20)]
        public int PosX { get; set; }
        [Required]
        [Range(0, 20)]
        public int PosY { get; set; }
        [Required]
        public int UserGameId { get; set; }

        [ForeignKey("UserGameId")]
        public UserGame UserGame { get; set; }


        //Ship id
        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public Ship Ship { get; set; }

        public bool Hidden { get; set; }
        [Required]
        public PieceState PieceState { get; set; }


    }
}
