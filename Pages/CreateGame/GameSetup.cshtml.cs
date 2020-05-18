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
        private readonly IGameSetup _gameSetup;

        public ShipViewModel Ship { get; set; }

        [BindProperty]
        public int GameSize { get; set; }
        [BindProperty]
        public int MaxPlayers { get; set; }
        public List<Ship> AvailableShips { get; set; } = new List<Ship>();
        IList<List<NavyBattlePiece>> ChosenShips { get; set; }

        public IList<GameBoardData> GameBoards { get; set; } = new List<GameBoardData>();

        public IList<ShipsShipGamesViewModel> SetupShips { get; set; } = new List<ShipsShipGamesViewModel>();

        public GameSetupModel(IGameSetup gameSetup)
        {
            _gameSetup = gameSetup;
        }


        //při načtení stránky
        public void OnGet()
        {

            AvailableShips = _gameSetup.GetShips();
            foreach (var ship in AvailableShips)
            {
                var shipgame = _gameSetup.GetShipGame(ship.Id);
                var listOfPieces = _gameSetup.GetDataForGameboard(ship);
                ShipsShipGamesViewModel shipsShipGames = new ShipsShipGamesViewModel
                {
                    ShipGame = shipgame,
                    Ship = ship,
                    GameBoard = new GameBoardData(listOfPieces, null, null, "GameSetup")
                };

                SetupShips.Add(shipsShipGames);

            }

            ChosenShips = _gameSetup.GetChosenShips();

            //inicialization of All gameboards for every choosen ship
            foreach (var listOfPieces in ChosenShips)
            {
                GameBoardData newBoard = new GameBoardData(listOfPieces, null, null, "GameSetup");
                GameBoards.Add(newBoard);
            }
        }


        //ukládání dat
        public IActionResult OnPostSetGame(int maxPlayers, int gameSize)
        {
            _gameSetup.Setgame(maxPlayers, gameSize);
            return RedirectToPage("./ShipPlacement");
        }

        public IActionResult OnPostAddShip(int id)
        {
            _gameSetup.CreateShipGame(id);
            return RedirectToPage("./GameSetup");
        }
        public IActionResult OnPostDelete(int id)
        {
            _gameSetup.DeleteShipGame(id);
            return RedirectToPage("./GameSetup");
        }
    }
}