﻿using System;
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
        private readonly ISiteFunctionality _siteFunctionality;

        IList<List<NavyBattlePiece>> ChosenShips { get; set; }
        public IList<GameBoardData> GameBoards { get; set; } = new List<GameBoardData>();
        public GameBoardData ChoosenShip { get; set; }
        public GameBoardData Board { get; set; }
        public UserGame UserGame { get; set; }
        public IList<NavyBattlePiece> BoardPieces { get; set; }
        public Guid? LoggedInUserId { get; set; }
        public ShipPlacementModel(IShipPlacement shipPlacement, IGameSetup gameSetup, ISiteFunctionality siteFunctionality)
        {
            _shipPlacement = shipPlacement;
            _gameSetup = gameSetup;
            _siteFunctionality = siteFunctionality;
        }

        public void OnGet(int? id, int? shipId)
        {
            _shipPlacement.JoinShipPlacement();
            if (id != null)
            {
                int pieceId = id ?? default;
                _shipPlacement.PlaceAShip(pieceId);
            }


            #region Load GameBoard and Ships
            ChosenShips = _gameSetup.GetChosenShips();
            UserGame = _shipPlacement.GetUserGame();
            BoardPieces = _shipPlacement.GetGameBoard();
            LoggedInUserId = _siteFunctionality.GetUserId();

            GameBoards = _shipPlacement.PopulateGameBoards(ChosenShips, shipId);

            if (shipId != null)
            {
                _shipPlacement.SaveShip("Ship", shipId);
                int shipIdx = shipId ?? default;
                ChoosenShip = new GameBoardData(_shipPlacement.GetChosenShip(shipIdx));
            }

            // Get new board
            Board = new GameBoardData(BoardPieces, UserGame, LoggedInUserId, "ShipPlacement");
            #endregion

        }

        public IActionResult OnPostRefresh()
        {
            _shipPlacement.Refresh();
            return RedirectToPage("./ShipPlacement");
        }
        public IActionResult OnPostDeploy()
        {
            _shipPlacement.Deploy();
            return RedirectToPage("../InGame/InGame");
        }

    }
}