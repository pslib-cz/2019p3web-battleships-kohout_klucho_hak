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
     
        public IList<GameBoardData> GameBoards { get; set; }
        public IList<UserGame> UserGames { get; set; }
        public List<int> NavyBattlePiecesId { get; set; }



        IGameBattle _gameBattle;

        

        public InGameModel(IGameBattle gameBattle)
        {
            _gameBattle = gameBattle;
            
       
            
        }

        public void OnGet(Guid id)
        {
            Game = _gameBattle.GetGame(id);
            UserGames = _gameBattle.GetUserGamesWithUser(Game.Id);

            //inicialization of All gameboards for every player in the given game.
            for (int board = 0; board < UserGames.Count(); board++)
            {
                GameBoards[board] = new GameBoardData(UserGames[board], Game.Id);
            }


        }
        /// <summary>
        /// Tries to fire on given 
        /// </summary>
        /// <param name="pieceId"> Id of picked navybattlepiece</param>
        public IActionResult OnPostFire(int pieceId)
        {
            _gameBattle.Fire(NavyBattlePiecesId, Game, UserGames);
            return RedirectToPage("./InGame");    
        }
    }
}