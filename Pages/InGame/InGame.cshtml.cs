using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Data;
using BattleShips.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BattleShips
{
    public class InGameModel : PageModel
    {
        public Game Game { get; set; }

        /// <summary>
        /// List of current pieces.
        /// </summary>
        public IList<NavyBattlePiece> NavyBattlePieces { get; set; }

        IGameBattle _gameBattle;
        IGameEnd _gameEnd;

        public InGameModel(IGameBattle gameBattle, IGameEnd gameEnd)
        {
            _gameBattle = gameBattle;
            _gameEnd = gameEnd;
        }

        public void OnGet(Guid id)
        {
            Game = _gameBattle.GetGame(id);


        }
    }
}