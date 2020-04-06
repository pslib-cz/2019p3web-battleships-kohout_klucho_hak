using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Data;
using BattleShips.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BattleShips.ViewModels;

namespace BattleShips
{
    //[Authorize]
    public class InGameModel : PageModel
    {
        public Game Game { get; set; }
        //TODO tady bdue gameboard data, spojím zde s partial view gameboard (list typu gameboard data)
        //
        public IList<GameBoardData> GameBoards { get; set; }
        public IList<UserGame> UserGames { get; set; }

        

        IGameBattle _gameBattle;
        

        public InGameModel(IGameBattle gameBattle)
        {
            _gameBattle = gameBattle;
            
        }

        public void OnGet(Guid id)
        {
            Game = _gameBattle.GetGame(id);
            UserGames = _gameBattle.GetUserGames(Game.Id);
            
           

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pieceId"> Id of picked navybattlepiece</param>
        public void OnPostFire(int pieceId)
        {
            
            _gameBattle.Fire(pieceId); 
        }
    }
}