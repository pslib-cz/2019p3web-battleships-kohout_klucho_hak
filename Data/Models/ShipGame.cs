using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Data
{
    public class ShipGame
    {
        [Key]
        public int Id { get; set; }

        public int ShipId { get; set; }

        [ForeignKey("ShipId")]
        public Ship Ship { get; set; }

        public Guid GameId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public bool IsPlaced { get; set; }
    }
}
