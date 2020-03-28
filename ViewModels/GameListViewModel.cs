using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.ViewModels
{
    public class GameListViewModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }


        [Display(Name = "GameCreatedAt")]
        public string GameCreatedAt { get; set; }

        //enum
        [Display(Name = "GameState")]
        public string GameState { get; set; }


        [Display(Name = "Player1")]
        public string Player1 { get; set; }


        [Display(Name = "Player2")]
        public string Player2 { get; set; }


    
    }
}
