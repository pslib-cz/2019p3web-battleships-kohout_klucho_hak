using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Data;
using BattleShips.Services;
using BattleShips.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BattleShips
{
    [Authorize]
    public class GameListModel : PageModel
    {
        [TempData]
        public string MessageSuccess { get; set; }
        [TempData]
        public string MessageError { get; set; }

        public IList<Game> UsersGames { get; set; } = new List<Game>();

        public IList<Game> OtherGames { get; set; } = new List<Game>();

        public Guid UserId { get; set; }

        ISiteFunctionality _siteFunctionality;

        public GameListModel(ISiteFunctionality siteFunctionality)
        {
            _siteFunctionality = siteFunctionality;
        }


        public void OnGet()
        {
            UsersGames = _siteFunctionality.GetUsersGames();
            OtherGames = _siteFunctionality.GetOtherGames();
            UserId = _siteFunctionality.GetUserId();
        }

        public IActionResult OnPostRemoveGame(Guid id)
        {
            bool result = _siteFunctionality.RemoveGame(id);
            if (result)
            {
                MessageSuccess = "Game was deleted.";
            }

            else
            {
                MessageError = "Game wasn't deleted.";
            }
            return RedirectToPage("./GameList");
        }

        public IActionResult OnPostJoinShipPlacement(Guid id)
        {
            _siteFunctionality.SaveGame("Game", id);
            
            return RedirectToPage("../CreateGame/ShipPlacement");
        }
        public IActionResult OnPostPlayGame(Guid id)
        {
            _siteFunctionality.SaveGame("Game", id);
            return RedirectToPage("../InGame/InGame");
        }

        public IActionResult OnPostCreateNewGame()
        {
            _siteFunctionality.SetupGame();
            return RedirectToPage("../CreateGame/GameSetup");
        }

    }
}