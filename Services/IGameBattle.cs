using BattleShips.Data;
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
        public Game GetGame(Guid id);
        /// <summary>
        /// Method for firing based on choosen piece id.
        /// </summary>
        /// <param name="battlePieceId">Id of choosen piece.</param>
        public void Fire(int battlePieceId);
    

        /// <summary>
        /// Gets list of UserGames in game.
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        IList<UserGame> GetUserGames(Guid gameId);

        /// <summary>
        /// Gets list of navybattlepieces based on usergameid.
        /// </summary>
        /// <param name="userGameId"></param>
        /// <returns></returns>
        IList<NavyBattlePiece> GetNavyBattlePieces(int userGameId);



    }
}
