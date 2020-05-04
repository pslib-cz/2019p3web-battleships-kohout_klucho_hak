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
    [Authorize]
    public class InGameModel : PageModel
    {
        public Game Game { get; set; }
        public string FireResult { get; set; }
        public IList<GameBoardData> GameBoards { get; set; } = new List<GameBoardData>();
        public IList<UserGame> UserGames { get; set; }
        public List<int> NavyBattlePiecesId { get; set; }

        private IGameBattle _gameBattle;


        public InGameModel(IGameBattle gameBattle )
        {
            _gameBattle = gameBattle;

        }

        public void OnGet(int? id)
        {
            Game = _gameBattle.GetGame();
            UserGames = _gameBattle.GetUserGamesWithUser();
            if (id != null)
            {
                FireResult = _gameBattle.Fire(id);
         
            }  

            //inicialization of All gameboards for every player in the given game.
            for (int board = 0; board < UserGames.Count(); board++)
            {
                IList<NavyBattlePiece> navyBattlePieces = _gameBattle.GetNavyBattlePieces(UserGames[board].Id);
                GameBoardData newBoard = new GameBoardData(navyBattlePieces, UserGames[board]);
                GameBoards.Add(newBoard);
            }
        }
    }
}