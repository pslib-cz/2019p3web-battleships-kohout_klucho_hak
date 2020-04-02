﻿using BattleShips.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    /// <summary>
    /// Logic, data creation and manipulation for Start stage of the game. (1. stage of the game. Users join the game, game begins when all player are ready, players place their ships)
    /// </summary>
    public interface IGameSetup
    {

        public Game GetGame(Guid id);

        public UserGame GetUserGame(string userId, Guid gameId);

        IList<ShipPiece> Fleet(Guid gameId);

        public void ShipPlacement(int userGameid);


    }
}
