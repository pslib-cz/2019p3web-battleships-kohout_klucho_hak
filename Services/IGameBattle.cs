using BattleShips.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    /// <summary>
    /// Logic, data creation and manipulation for Battle stage of the game. (2. stage of the game. Players take turns and fight eachother.)
    /// </summary>
    public interface IGameBattle
    {
        /// <summary>
        /// Returns currently active Game.
        /// </summary>
        /// <returns></returns>
        Task<Game> GetGameAsync();


        Task FireAsync(int pieceId);

        /// <summary>
        /// Returns Ilist of UserGames in currently active Game.
        /// </summary>
        /// <returns></returns>
        Task<IList<UserGame>> GetUserGamesWithUserAsync();

        /// <summary>
        /// Gets list of navybattlepieces based on UserGameId.
        /// </summary>
        /// <param name="userGameId"></param>
        /// <returns></returns>
        Task<IList<NavyBattlePiece>> GetNavyBattlePiecesAsync(int userGameId);
    }
}
