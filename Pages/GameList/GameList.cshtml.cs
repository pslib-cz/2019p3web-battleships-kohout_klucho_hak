using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BattleShips
{
    public class GameListModel : PageModel
    {
        public GameListModel()
        {
            GameLists = new List<GameListViewModel>();
        }

        public List<GameListViewModel> GameLists { get; set; }

        public void OnGet()
        {

        }
    }
}