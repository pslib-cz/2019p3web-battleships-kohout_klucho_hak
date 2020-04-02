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
        readonly ICreation _creation;

        public int BoardSize;



        public ShipPlacementModel(ICreation creation)
        {
            _creation = creation;

            NavyBattlePiecesCol = new List<NavyBattlePieceViewModel>();
            NavyBattlePiecesRow = new List<NavyBattlePieceViewModel>();


        }

        public List<NavyBattlePieceViewModel> NavyBattlePiecesCol { get; set; }
        public List<NavyBattlePieceViewModel> NavyBattlePiecesRow { get; set; }


        public void OnGet()
        {

        }
    }
}