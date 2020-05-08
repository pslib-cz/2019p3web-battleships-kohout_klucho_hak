using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(20, ErrorMessage = "You need to keep the name to max of 20 characters.")]
        [MinLength(3, ErrorMessage = "You need to enter at least 3 characters for an Username")]
        [DisplayName("Username")]
        public string PlayerName { get; set; }

        public int Wins { get; set; }

        public int TotalPlayedGames { get; set; }


        ////public double WinRate => ((Wins / TotalPlayedGames) * 100);
        //[NotMapped]
        //private double _winRate;

        //[NotMapped]
        //public double WinRate
        //{
        //    get { return _winRate; }
        //    set 
        //    {
        //        if(TotalPlayedGames !=0 || Wins !=0)
        //        {
        //            _winRate = ((Wins / TotalPlayedGames) * 100);
        //        }
        //        else
        //        {
        //            _winRate = 0;
        //        }
        //    }
        //}
    }
}
