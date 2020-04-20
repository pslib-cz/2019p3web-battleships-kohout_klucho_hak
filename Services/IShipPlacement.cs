using BattleShips.Data;
using System;
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
        Game GetGame(Guid _currentGameId);

        /// <summary>
        /// po rozmístění lodí vytvoří novou mezitabulku (UserGame)
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="userId"></param>
        void CreateUserGame(Guid gameId, string userId);
        
        /// <summary>
        /// podle velikosti hry vytvoří prázdné hrací pole při načtení stránky
        /// </summary>
        /// <param name="game"></param>
        void CreateBlankGameBoard(Game game);

       

        /// <summary>
        /// upraví prázdné hrací pole podle rozmístění lodí a uloží ho do databáze
        /// </summary>
        /// <param name="userGameId"></param>
        /// <returns></returns>
        void ShipPlacement(int userGameId);

        /// <summary>
        /// vrátí lodě, které jsou dostupné v dané hře, pomocí listu mezitabulek shipGame
        /// </summary>
        /// <param name="shipGame"></param>
        /// <returns></returns>
        IList<Ship> GetGameShips(IList<ShipGame> shipGame);


        /// <summary>
        /// vrátí mezitabulky shipGames
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        IList<ShipGame> GetShipGames(Game game);

        
    }
}
