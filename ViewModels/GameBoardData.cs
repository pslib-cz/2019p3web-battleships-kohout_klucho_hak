using BattleShips.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Services;

namespace BattleShips.ViewModels
{
    /// <summary>
    /// Model partial view _GameBoardData
    /// </summary>
    public class GameBoardData
    {
        public IList<NavyBattlePiece> NavyBattlePieces { get; set; }
        public Game Game { get; set; }
        public UserGame UserGame { get; set; } = new UserGame();
        public string PageHandler { get; set; }
        public Ship Ship { get; set; } = new Ship();
        public Guid? LoggedInUserId { get; set; }
        public bool IsLoggedInUsersBoard { get; set; } = false;

        public GameBoardData(IList<NavyBattlePiece> navyBattlePieces,
                             UserGame userGame = null,
                             Guid? loggedInUserId = null,
                             string pageHandler = "InGame")
        {
            if (userGame != null)
            {
                UserGame = userGame;
                Game = userGame.Game;
                LoggedInUserId = loggedInUserId;
            }

            NavyBattlePieces = navyBattlePieces;
            PageHandler = pageHandler;
        }

        /// <summary>
        /// Creates IEnumerable<IEnumerable<NavyBattlePiece>>, from IList<NavyBattlePiece> NavyBattlePieces so that it can be presented easily as a board in view.
        /// </summary>
        /// <param name="navyBattlePieces"> IList of NavyBattlePieces belonging to one specific board.</param>
        /// <returns>IEnumerable<IEnumerable<NavyBattlePiece>></returns>
        public IEnumerable<IEnumerable<NavyBattlePiece>> MakeGameBoard(IList<NavyBattlePiece> navyBattlePieces)
        {
            // Sorts and configures pieces + board for display
            IList<NavyBattlePiece> sortednavyBattlePieces = ConfigurePieces(navyBattlePieces);

            // Gets information needed to find out rowNumber
            int itemCount = sortednavyBattlePieces.Count;
            NavyBattlePiece lastNavyBattlePiece = sortednavyBattlePieces[itemCount - 1];
            Ship = lastNavyBattlePiece.Ship;

            // Gets number of rows and colums
            int rowsNumber = lastNavyBattlePiece.PosY;
            int columsNumber = CountColums(sortednavyBattlePieces);

            // Creates 2D board for easy display
            IList<List<NavyBattlePiece>> result = CreateBoard(sortednavyBattlePieces, rowsNumber, columsNumber);
            return result;
        }

        private IList<List<NavyBattlePiece>> CreateBoard(IList<NavyBattlePiece> sortednavyBattlePieces, int rowsNumber, int columsNumber)
        {
            int index = 0;

            IList<List<NavyBattlePiece>> result = new List<List<NavyBattlePiece>>();
            for (int row = 0; row <= rowsNumber; row++)
            {
                List<NavyBattlePiece> resultRow = new List<NavyBattlePiece>();

                for (int piece = 0; piece < columsNumber; piece++)
                {
                    NavyBattlePiece currentPiece = sortednavyBattlePieces.ElementAt(index);
                    resultRow.Add(currentPiece);
                    index++;
                }
                result.Add(resultRow);
            }
            return result;
        }
        private int CountColums(IList<NavyBattlePiece> sortednavyBattlePieces)
        {
            int columsNumber = 0;
            foreach (var item in sortednavyBattlePieces)
            {
                if (item.PosY == 0)
                {
                    columsNumber++;
                }
            }
            return columsNumber;
        }
        
        /// <summary>
        /// Sorts and configures pieces for display.
        /// </summary>
        /// <param name="navyBattlePieces"></param>
        /// <returns></returns>
        private IList<NavyBattlePiece> ConfigurePieces(IList<NavyBattlePiece> navyBattlePieces)
        {
            IList<NavyBattlePiece> result = navyBattlePieces.OrderBy(m => m.PosY).ThenBy(m => m.PosX).ToList();
            if (UserGame != null)
            {
                if (UserGame.ApplicationUserId == LoggedInUserId)
                {
                    foreach (var piece in result)
                    {
                        piece.Hidden = false;

                    }
                    IsLoggedInUsersBoard = true;
                }
            }
            return result;
        }
    }
}
