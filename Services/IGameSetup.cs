using BattleShips.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    /// <summary>
    /// Logic, data creation and manipulation for create new game.
    /// </summary>
    public interface IGameSetup
    {
        /// <summary>
        /// vytváří hru
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="maxPlayers"></param>
        /// <param name="boardSize"></param>
        /// <returns></returns>
        bool CreateNewGame(string userId);

        /// <summary>
        /// vytvoří list dostupných lodí pro rozmístění (mezitabulka zakliknutých lodí)
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="shipId"></param>
        /// <returns></returns>
        void CreateShipGame(int? shipId);


        void DeleteShipGame(int shipGameId);

        IList<List<NavyBattlePiece>> GetChosenShips();

        void Setgame(int maxPlayers, int gameSize);



        /// <summary>
        /// dostupné lodě ze kterých si uživatel bude vybírat
        /// </summary>
        /// <returns></returns>
        List<Ship> GetShips();

        IEnumerable GetShipPieces(int ShipId);

        IEnumerable<IEnumerable<ShipPiece>> DisplayShips(ShipPiece shipPiece);



    }
}
