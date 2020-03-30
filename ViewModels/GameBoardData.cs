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
        //TODO vytvořit list listu aby to šlo vykreslit
        //velikost pole
        IGameBattle _gameBattle;
        public IList<NavyBattlePiece> NavyBattlePieces { get; set; }
        /// <summary>
        /// Načtu navybattlepieces
        /// </summary>
        public GameBoardData(IGameBattle gameBattle, UserGame userGame)
        {
            _gameBattle = gameBattle;
            NavyBattlePieces = _gameBattle.GetNavyBattlePieces(userGame.Id);
        }

   

        //Foreach Orderby podle souřadnice y, groupby přes y souřadnici
        //public IEnumerable<IEnumerable<NavyBattlePiece>> MakeGameBoard()
        //{
           
       
        //}
    }
}
