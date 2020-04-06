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
        //TODO pagehandlery, page kam budou a hrefy mířit
        //velikost pole
        IGameBattle _gameBattle;
        public IList<NavyBattlePiece> NavyBattlePieces { get; set; }
        //public IEnumerable<IEnumerable<NavyBattlePiece>> BattleBoard { get; set; }
        public Game Game { get; set; }
   
        /// <summary>
        /// Načtu navybattlepieces
        /// </summary>
        public GameBoardData(IGameBattle gameBattle, UserGame userGame, Guid gameId)
        {
            _gameBattle = gameBattle;
            NavyBattlePieces = _gameBattle.GetNavyBattlePieces(userGame.Id);
            Game = _gameBattle.GetGame(gameId);
            
        }

   

        //Foreach Orderby podle souřadnice y, groupby přes y souřadnici
        public IEnumerable<IEnumerable<NavyBattlePiece>> MakeGameBoard(IList<NavyBattlePiece> navyBattlePieces)
        {
            IEnumerable<IEnumerable<NavyBattlePiece>> result = Enumerable.Empty<IEnumerable<NavyBattlePiece>>(); ;
           
            return result;


        }
    }
}
