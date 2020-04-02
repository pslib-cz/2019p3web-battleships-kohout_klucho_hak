using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Services;
using BattleShips.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BattleShips
{
    public class ShipPlacementModel : PageModel
    {

        public int BoardSize;

        public ShipPlacementModel()
        {

        }


        public void OnGet()
        {
          
        }
    }
}