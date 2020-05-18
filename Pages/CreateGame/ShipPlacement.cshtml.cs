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
    public class ShipPlacementModel : PageModel
    {
        private readonly IShipPlacement _shipPlacement;
        private readonly IGameSetup _gameSetup;

        IList<List<NavyBattlePiece>> ChosenShips { get; set; }
        public IList<GameBoardData> GameBoards { get; set; } = new List<GameBoardData>();
        public GameBoardData Board { get; set; }
        public UserGame UserGame { get; set; }
        public IList<NavyBattlePiece> BoardPieces { get; set; }
        public ShipPlacementModel(IShipPlacement shipPlacement, IGameSetup gameSetup)
        {
            _shipPlacement = shipPlacement;
            _gameSetup = gameSetup;
        }

        public void OnGet(int? id)
        {
            _shipPlacement.JoinShipPlacement();
            if (id != null)
            {

            }
            #region Load GameBoard and Ships
            ChosenShips = _gameSetup.GetChosenShips();
            UserGame = _shipPlacement.GetUserGame();
            BoardPieces = _shipPlacement.GetGameBoard();

            // inicialization of All gameboards for every choosen ship
            foreach (var listOfPieces in ChosenShips)
            {
                GameBoardData newBoard = new GameBoardData(listOfPieces, null, null, "GameSetup");
                GameBoards.Add(newBoard);
            }

            // Get new board
            Board = new GameBoardData(BoardPieces, UserGame);
            #endregion

        }

        public void OnPostChooseAShip(int shipId)
        {

        }
    }
}