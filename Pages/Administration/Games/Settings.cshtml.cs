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

namespace BattleShips.Pages.Administration.Games
{
    [Authorize(Roles = "Admin")]
    public class SettingsModel : PageModel
    {
        private readonly IAdministration _administration;
        private readonly IGameSetup _gameSetup;

        public IList<Ship> Ships { get; set; }
        public IList<ShipsShipGamesViewModel> SetupShips { get; set; } = new List<ShipsShipGamesViewModel>();

        public SettingsModel(IAdministration administration, IGameSetup gameSetup)
        {
            _administration = administration;
            _gameSetup = gameSetup;
        }
        public void OnGet()
        {
            Ships = _administration.GetAllShips();
            foreach (var ship in Ships)
            {
                var listOfPieces = _gameSetup.GetDataForGameboard(ship);
                ShipsShipGamesViewModel shipsShipGames = new ShipsShipGamesViewModel
                {
                    Ship = ship,
                    GameBoard = new GameBoardData(listOfPieces, null, null, "GameSetup")
                };

                SetupShips.Add(shipsShipGames);
            }
        }

        public IActionResult OnPostAllowShip(int shipId)
        {
            _administration.AllowShip(shipId);
            return RedirectToPage("./Settings");
        }
        public IActionResult OnPostDisallowShip(int shipId)
        {
            _administration.DisallowShip(shipId);
            return RedirectToPage("./Settings");
        }
    }
}