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
    public class DeleteModel : PageModel
    {
        private readonly IAdministration _administration;

        [TempData]
        public string FormResult { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        public DeleteModel(IAdministration administration)
        {
            _administration = administration;
        }
        public ApplicationUser ApplicationUser { get; set; }
        public void OnGet()
        {
            ApplicationUser = _administration.GetUserDetail(Id);
        }

        public IActionResult OnPost()
        {
            if (_administration.DeleteUser(Id))
            {
                FormResult = "You have succesfuly removed user.";

                return RedirectToPage("./List");
            }
            else
            {
                FormResult = "User was not removed process failed.";
                return RedirectToPage("./Detail", new { id = Id });
            }
        }
    }
}