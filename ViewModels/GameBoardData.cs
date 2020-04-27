﻿using BattleShips.Data;
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
        //TODO pagehandlery, page kam budou a hrefy mířit
        public IList<NavyBattlePiece> NavyBattlePieces { get; set; }
        public Game Game { get; set; }
        public UserGame UserGame { get; set; }

        /// <param name="gameBattle"></param>
        /// <summary>
        /// Overloaded constructor for inicialization of data.(IList<NavyBattlePieces>)
        /// </summary>
        public GameBoardData(UserGame userGame, IList<NavyBattlePiece> navyBattlePieces)
        {
            UserGame = userGame;
            Game = userGame.Game;
            NavyBattlePieces = navyBattlePieces;
        }

        /// <summary>
        /// Creates IEnumerable<IEnumerable<NavyBattlePiece>>, from IList<NavyBattlePiece> NavyBattlePieces so that it can be presented easily as a board in view.
        /// </summary>
        /// <param name="navyBattlePieces"> IList of NavyBattlePieces belonging to one specific board.</param>
        /// <returns>IEnumerable<IEnumerable<NavyBattlePiece>></returns>
        public IEnumerable<IEnumerable<NavyBattlePiece>> MakeGameBoard(IList<NavyBattlePiece> navyBattlePieces)
        {
            IList<List<NavyBattlePiece>> result = new List<List<NavyBattlePiece>>();

            int index = 0;
            for (int row = 0; row < Game.GameSize; row++)
            {
                List<NavyBattlePiece> resultRow = new List<NavyBattlePiece>();
                
                for (int piece = 0; piece < Game.GameSize; piece++)
                {
                    NavyBattlePiece currentPiece = navyBattlePieces.ElementAt(index);
                    resultRow.Add(currentPiece);
                    index++;
                }
                result.Add(resultRow);
            }
            return result;
        }
    }
}
