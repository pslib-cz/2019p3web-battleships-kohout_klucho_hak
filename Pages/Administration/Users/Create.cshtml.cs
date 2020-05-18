using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BattleShips.Pages.Administration.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}