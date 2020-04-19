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
    public class GameSetupModel : PageModel
    {
        public ApplicationDbContext _db;

        public IGameSetup _igamesetup;

        public ShipViewModel Ship { get; set; }
        public int boardSize { get; set; }
        public List<Ship> Ships { get; set; }


        public GameSetupModel(ApplicationDbContext db, IGameSetup igamesetup)
        {
            _db = db;
            _igamesetup = igamesetup;
        }

      

        public void OnGet()
        {

        }
    }
}