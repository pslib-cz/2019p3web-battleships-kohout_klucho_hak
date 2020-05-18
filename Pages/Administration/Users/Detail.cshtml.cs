using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Data;
using BattleShips.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BattleShips.Pages.Administration.Users
{
    [Authorize(Roles = "Admin")]
    public class DetailModel : PageModel
    {
        private readonly IAdministration _administration;

        public ApplicationUser ApplicationUser { get; set; }
        public IList<Game> Games { get; set; }

        [BindProperty]
        public string PlayerName { get; set; }
        [BindProperty]
        public Guid Id { get; set; }

        public DetailModel(IAdministration administration)
        {
            _administration = administration;
        }
        public void OnGet(Guid id)
        {
            ApplicationUser = _administration.GetUserDetail(id);
            Games = _administration.GetUsersGames(ApplicationUser.Id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            _administration.UpdatePlayerName(PlayerName, Id);
            return RedirectToPage("./Detail", new { id = Id });
        }
    }
}