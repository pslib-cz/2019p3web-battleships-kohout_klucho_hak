using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Data
{
    public class UserGame
    {

        [Key]
        public int Id { get; set; }
        
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser IdentityUser { get; set; }

        public Guid GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        public enum PlayerState
        {
            PlacingShips = 0,
            Firing = 1,
            Waiting = 2
        }


    }
}
