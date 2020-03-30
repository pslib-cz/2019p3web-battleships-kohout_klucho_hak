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
        //TODO tady bdue gameboard data, spojím zde s partial view gameboard

        public IList<UserGame> UserGames { get; set; }

        

        IGameBattle _gameBattle;
        

        public InGameModel(IGameBattle gameBattle, IGameEnd gameEnd)
        {
            _gameBattle = gameBattle;
            
        }

        public void OnGet(Guid id)
        {
            Game = _gameBattle.GetGame(id);
            UserGames = _gameBattle.GetUserGames(Game.Id);

            //Gets list of NavyBattlePieces from UserGames list.
            //for (int i = 0; i < UserGames.Count; i++)
            //{
            //    NavyBattlePieces.Add(_gameBattle.GetBoards(UserGames[i].Id));
            //}

        }
    }
}