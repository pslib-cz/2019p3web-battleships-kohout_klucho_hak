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
        Game GetGame(Guid id);
        /// <summary>
        /// Method for firing based on choosen pieces ids.
        /// </summary>
        /// <param name="navyBattlePieceIds"></param>
        /// <param name="firedInGame"></param>
        /// <param name="userGames"></param>
        void Fire(List<int> navyBattlePieceIds, Game firedInGame, IList<UserGame> userGames);




        /// <summary>
        /// Gets list of UserGames in game.
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        IList<UserGame> GetUserGamesWithUser(Guid gameId);

        /// <summary>
        /// Gets list of navybattlepieces based on usergameid.
        /// </summary>
        /// <param name="userGameId"></param>
        /// <returns></returns>
        IList<NavyBattlePiece> GetNavyBattlePieces(int userGameId);

    }
}
