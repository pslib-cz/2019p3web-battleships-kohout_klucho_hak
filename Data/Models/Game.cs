using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Data
{
    public class Game
    {
 
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Please enter valid number of players!")]
        public int MaxPlayers { get; set; }
        [Required]
        [Range(0, 20, ErrorMessage = "Please enter valid size of game board!")]
        public int GameSize { get; set; }
        public int GameRound { get; set; }
        [Required]
        public string OwnerId { get; set; }
        
        [ForeignKey("OwnerId")]
        public ApplicationUser ApplicationUser { get; set; }

        public string CurrentPlayerId { get; set; }
        [ForeignKey("CurrentPlayerId")]
        public ApplicationUser CurrentPlayer { get; set; }

        [Required]
        public GameState GameState { get; set; }


    }
}
