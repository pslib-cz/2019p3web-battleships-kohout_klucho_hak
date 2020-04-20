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
    
        
        //TODO pagehandlery, page kam budou a hrefy mířit
        //velikost pole
        IGameBattle _gameBattle;
        public IList<NavyBattlePiece> NavyBattlePieces { get; set; }
    
        public Game Game { get; set; }
        
        public UserGame UserGame { get; set; }
        /// <summary>
        /// Constructor for inicialization of interface
        /// </summary>
        /// <param name="gameBattle"></param>
        public GameBoardData(IGameBattle gameBattle)
        {
            _gameBattle = gameBattle;
        }
        /// <summary>
        /// Overloaded constructor for inicialization of data.(IList<NavyBattlePieces>)
        /// </summary>
        public GameBoardData(UserGame userGame, Guid gameId)
        { 
            NavyBattlePieces = _gameBattle.GetNavyBattlePieces(userGame.Id);
            Game = _gameBattle.GetGame(gameId);
            UserGame = userGame;
        }

        //TODO test if MakeGameBoard works :)
        /// <summary>
        /// Creates IEnumerable<IEnumerable<NavyBattlePiece>>, from IList<NavyBattlePiece> NavyBattlePieces so that it can be presented easily as a board in view.
        /// </summary>
        /// <param name="navyBattlePieces"> IList of NavyBattlePieces belonging to one specific board.</param>
        /// <returns>IEnumerable<IEnumerable<NavyBattlePiece>></returns>
        public IEnumerable<IEnumerable<NavyBattlePiece>> MakeGameBoard(IList<NavyBattlePiece> navyBattlePieces)
        {
            IEnumerable<IEnumerable<NavyBattlePiece>> result = Enumerable.Empty<IEnumerable<NavyBattlePiece>>(); 

            var sortedNavyBattlePieces = // for example: If the gamesize is 10 => First 10 items (first row) of sortedNavyBattlePieces should be : NavyBattlePieces with y = 0(GroupBy), orderd by x => 0, 1, 2, 3 , 4, 5, 6, 7, 8, 9 (OrderBy and SelectMany)
                navyBattlePieces.OrderBy(x => x.PosX) // seřadit podle x
                                .GroupBy(y => y.PosY) //Group by PosY
                                .SelectMany(g => g); //flatten the groups

            for(int row = 0; row < Game.GameSize; row++)
            {
               IEnumerable<NavyBattlePiece> resultRow = Enumerable.Empty < NavyBattlePiece>();
                for(int piece = 0; piece < Game.GameSize; piece++)
                {
                    resultRow.Append(sortedNavyBattlePieces.ElementAt(piece));
                }
                result.Append(resultRow);
            }

            return result;
        }
    }
}
