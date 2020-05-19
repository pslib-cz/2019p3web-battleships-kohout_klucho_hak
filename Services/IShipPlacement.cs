using BattleShips.Data;
using BattleShips.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    /// <summary>
    /// Logic, data creation and manipulation for shipPlacement.
    /// </summary>
    public interface IShipPlacement
    {
        /// <summary>
        /// vrátí danou hru
        /// </summary>
        /// <param name="_currentGameId"></param>
        /// <returns></returns>
        Game GetGame();

        /// <summary>
        /// po rozmístění lodí vytvoří novou mezitabulku (UserGame)
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="userId"></param>
        void CreateUserGame();
        
        /// <summary>
        /// podle velikosti hry vytvoří prázdné hrací pole při načtení stránky
        /// </summary>
        /// <param name="game"></param>
        void CreateBlankGameBoard(UserGame userGame);

        void PlaceAShip(int pieceId);
        public UserGame GetUserGame();

        IList<NavyBattlePiece> GetGameBoard();
        void JoinShipPlacement();
        IList<GameBoardData> PopulateGameBoards(IList<List<NavyBattlePiece>> chosenShips, int? shipId);
        IList<NavyBattlePiece> GetChosenShip(int shipId);


        /// <summary>
        /// for ship placement
        /// </summary>
        void Refresh();
        void Deploy();
        void SaveShip(string key, int? shipId);



    }
}
