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
        public UserGame UserGame { get; set; }
        public string PageHandler { get; set; }
        public Ship Ship { get; set; }


        public GameBoardData(IList<NavyBattlePiece> navyBattlePieces, UserGame userGame = null, string pageHandler = "InGame")
        {
            if(userGame!=null)
            {
                UserGame = userGame;
                Game = userGame.Game;
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
            IList<List<NavyBattlePiece>> result = new List<List<NavyBattlePiece>>();
            IList<NavyBattlePiece> sortednavyBattlePieces = navyBattlePieces.OrderBy(m => m.PosY).ThenBy(m => m.PosX).ToList();

            int index = 0;
           
            if (Game == null)
            {
                int rowsNumber = 0;
                int columsNumber = 0;
                int itemCount = sortednavyBattlePieces.Count;
                NavyBattlePiece lastNavyBattlePiece = sortednavyBattlePieces[itemCount - 1];
                rowsNumber = lastNavyBattlePiece.PosY;
                Ship = lastNavyBattlePiece.Ship;
                //rowsNumber = Convert.ToInt32(Math.Sqrt(sortednavyBattlePieces.Count())); //In the case of GameSetup.
                foreach (var item in sortednavyBattlePieces)
                {
                    if (item.PosY == 0)
                    {
                        columsNumber++;
                    }
                }
                
               
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
            }
            else
            {
                for (int row = 0; row < Game.GameSize; row++)
                {
                    List<NavyBattlePiece> resultRow = new List<NavyBattlePiece>();

                    for (int piece = 0; piece < Game.GameSize; piece++)
                    {
                        NavyBattlePiece currentPiece = sortednavyBattlePieces.ElementAt(index);
                        resultRow.Add(currentPiece);
                        index++;
                    }
                    result.Add(resultRow);
                }
            }

            
            return result;
        }
    }
}
