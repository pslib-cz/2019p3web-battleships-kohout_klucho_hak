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
  

        private readonly IGameSetup _igamesetup;
        private readonly ISiteFunctionality _siteFunctionality;

        public ShipViewModel Ship { get; set; }
        public int GameSize { get; set; }
        public int MaxPlayers { get; set; }
        public List<Ship> SetupShips { get; set; }
        IList<List<NavyBattlePiece>> ChosenShips { get; set; }

        public IList<GameBoardData> GameBoards { get; set; } = new List<GameBoardData>();



        public GameSetupModel(IGameSetup igamesetup, ISiteFunctionality siteFunctionality)
        {
            _igamesetup = igamesetup;
            _siteFunctionality = siteFunctionality;
        }

      
        //při načtení stránky
        public void OnGet(int? id)
        {
            _siteFunctionality.SetupGame();
            SetupShips = new List<Ship>();
            SetupShips = _igamesetup.GetShips();
            if (id!= null)
            {
                _igamesetup.CreateShipGame(id);
            }

            ChosenShips = _igamesetup.GetChosenShips();


            //inicialization of All gameboards for every choosen ship
            foreach (var listOfPieces in ChosenShips)
            {
                GameBoardData newBoard = new GameBoardData(listOfPieces, null, "GameSetup");
                GameBoards.Add(newBoard);
            }
        }

        //ukládání dat
        public IActionResult OnPostSetGame(int maxPlayers, int gameSize)
        {
            _igamesetup.Setgame(maxPlayers, gameSize);
            return RedirectToPage("./ShipPlacement");
        }

    }
}