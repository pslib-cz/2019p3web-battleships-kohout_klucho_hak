﻿using BattleShips.Data;
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
        /// Method for firing, based on position changes properties of NavyBattlePiece, checks if current user is firing.
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="userId"></param>
        public Boolean Fire(int posX, int posY, int userGameId);

        /// <summary>
        /// Method for surrender.
        /// </summary>
        /// <param name="userId"></param>
        public void Surrender(string userId);

        /// <summary>
        /// Gets list of UserGames in game.
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        IList<UserGame> GetUserGames(Guid gameId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Loads boards from database.</returns>
        IList<NavyBattlePiece> GetBoards(int userGameId);




    }
}
