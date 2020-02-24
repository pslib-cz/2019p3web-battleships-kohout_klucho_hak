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

        public int MaxPlayers { get; set; }

        public int GameSize { get; set; }
        public int OwnerId { get; set; }
        
        [ForeignKey("OwnerId")]
        public IdentityUser IdentityUser { get; set; }

        public int CurrentPlayerId { get; set; }
        [ForeignKey("CurrentPlayerId")]
        public IdentityUser CurrentPlayerIdentity { get; set; }

        public enum GameState
        {
            Setup = 0,
            Battle = 1,
            End = 2
        }
       

    }
}
