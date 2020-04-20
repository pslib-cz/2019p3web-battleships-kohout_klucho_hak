using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BattleShips.Pages.CreateGame
{
    public class AdminGameSetupModel : PageModel
    {

        public IList<Ship> SetupShips { get; set; }

        public void OnGet()
        {

        }
    }
}