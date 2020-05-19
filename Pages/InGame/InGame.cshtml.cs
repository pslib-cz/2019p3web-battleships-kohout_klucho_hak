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
        private readonly IGameBattle _gameBattle;
        private readonly ISiteFunctionality _siteFunctionality;

        public Game Game { get; set; } = new Game();
        public string FireResult { get; set; }
        public IList<GameBoardData> GameBoards { get; set; } = new List<GameBoardData>();
        public IList<UserGame> UserGames { get; set; }
        public List<int> NavyBattlePiecesId { get; set; }
        public Guid LoggedInUserId { get; set; }

        public InGameModel(IGameBattle gameBattle, ISiteFunctionality siteFunctionality)
        {
            _gameBattle = gameBattle;
            _siteFunctionality = siteFunctionality;
        }

        public void OnGet(int? id)
        {
            Game = _gameBattle.GetGame();
            UserGames = _gameBattle.GetUserGamesWithUser();
            LoggedInUserId = _siteFunctionality.GetUserId();

            if (id != null)
            {
                int pieceId = id ?? default;
                _gameBattle.Fire(pieceId);
            }

            //inicialization of All gameboards for every player in the given game.
            for (int board = 0; board < UserGames.Count(); board++)
            {
                IList<NavyBattlePiece> navyBattlePieces = _gameBattle.GetNavyBattlePieces(UserGames[board].Id);
                GameBoardData newBoard = new GameBoardData(navyBattlePieces, UserGames[board], LoggedInUserId);
                GameBoards.Add(newBoard);
            }
        }
    }
}