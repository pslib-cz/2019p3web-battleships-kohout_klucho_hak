using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Data;
using BattleShips.Services;
using BattleShips.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BattleShips
{
    public class GameListModel : PageModel
    {
        [TempData]
        public string MessageSuccess { get; set; }
        [TempData]
        public string MessageError { get; set; }

        public IList<Game> Games { get; set; }

        ISiteFunctionality _siteFunctionality;

        public GameListModel(ISiteFunctionality siteFunctionality)
        {
            _siteFunctionality = siteFunctionality;
            GameLists = new List<GameListViewModel>();
        }

        public List<GameListViewModel> GameLists { get; set; }

        public void OnGet()
        {
            //ApplicationUser loggedInUser = _siteFunctionality.GetLoggedInUser();
            //Games = _siteFunctionality.GetGames(loggedInUser.Id);
        }

        public IActionResult OnGetRemove(int id)
        {
            //chybí metoda RemoveGame(id)
            if (false)
            {
                MessageSuccess = "Game was deleted.";
            }

            else
            {
                MessageError = "Game wasn't deleted.";
            }
            return RedirectToPage("./GameList");
        }
    }
}