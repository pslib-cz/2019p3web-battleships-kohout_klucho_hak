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
        public int UserRound { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public ApplicationUser Owner { get; set; }

        public Guid CurrentPlayerId { get; set; }
        [ForeignKey("CurrentPlayerId")]
        public ApplicationUser CurrentPlayer { get; set; }

        [Required]
        public GameState GameState { get; set; }

        public ICollection<UserGame> UserGames { get; set; }
    }
}
