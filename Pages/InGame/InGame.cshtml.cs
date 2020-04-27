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

        public IList<GameBoardData> GameBoards { get; set; } = new List<GameBoardData>();
        public IList<UserGame> UserGames { get; set; }
        public List<int> NavyBattlePiecesId { get; set; }

        private IGameBattle _gameBattle;
        //private IBattleShipGameLoaderSaver _gameLoaderSaver;


        public InGameModel(IGameBattle gameBattle /*IBattleShipGameLoaderSaver gameLoaderSaver*/)
        {
            _gameBattle = gameBattle;
           // _gameLoaderSaver = gameLoaderSaver;
        }

        public void OnGet(Guid id, int pieceId)
        {
            Game = _gameBattle.GetGame(id);
            UserGames = _gameBattle.GetUserGamesWithUser(Game.Id);
            //_gameLoaderSaver.SaveGame("Game", Game.Id);


            //inicialization of All gameboards for every player in the given game.
            for (int board = 0; board < UserGames.Count(); board++)
            {
                IList<NavyBattlePiece> navyBattlePieces =_gameBattle.GetNavyBattlePieces(UserGames[board].Id);        
                GameBoardData newBoard = new GameBoardData(UserGames[board], Game, navyBattlePieces);
                GameBoards.Add(newBoard);
            }
        }

        // TODO - Get list of selected navyBattlePieces
        /// <summary>
        /// Tries to fire on choosen pieces.
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostFire()
        {
            //Guid gameId = _gameLoaderSaver.LoadGame("Game");
            //Game = _gameBattle.GetGame(gameId);
            //UserGames = _gameBattle.GetUserGamesWithUser(Game.Id);
            //TODO populate NavyBattlePieceId list

            _gameBattle.Fire(NavyBattlePiecesId, Game, UserGames);
            return RedirectToPage("./InGame" /*new {id = gameId }*/);    
        }
    }
}