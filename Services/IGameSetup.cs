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

        /// <summary>
        /// odstraní mezitabulku (propojení ship a game)
        /// </summary>
        /// <param name="shipGameId"></param>
        void DeleteShipGame(int shipGameId);

        /// <summary>
        /// vrátí list zakliknutých lodí
        /// </summary>
        /// <returns></returns>
        IList<List<NavyBattlePiece>> GetChosenShips();

        /// <summary>
        /// nastaví hru
        /// </summary>
        /// <param name="maxPlayers"></param>
        /// <param name="gameSize"></param>
        void Setgame(int maxPlayers, int gameSize);

        /// <summary>
        /// dostupné lodě ze kterých si uživatel bude vybírat
        /// </summary>
        /// <returns></returns>
        List<Ship> GetShips();

        //z ShipPiece udělat NavyBattlePiece
        IEnumerable GetShipPieces(int ShipId);

        //TODO - VOJTA - DisplayShips
        IEnumerable<IEnumerable<ShipPiece>> DisplayShips(ShipPiece shipPiece);



    }
}
