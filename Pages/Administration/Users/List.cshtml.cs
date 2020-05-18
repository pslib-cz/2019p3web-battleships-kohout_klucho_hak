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
    public class ListModel : PageModel
    {
        private readonly IAdministration _administration;

        public IList<ApplicationUser> Users { get; set; }

        public ListModel(IAdministration administration)
        {
            _administration = administration;
        }
        public void OnGet(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) == false)
            {

                Users = _administration.SearchUser(searchTerm);
            }
            else
            {
                Users = _administration.GetAllUsers();
            }

        }
        public IActionResult OnPost()
        {
            return RedirectToPage("./Create");
        }

    }
}