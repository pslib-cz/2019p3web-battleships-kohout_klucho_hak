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
        Game GetGame(Guid _currentGameId);

        void CreateUserGame(Guid gameId, string userId);

        void CreateGameBoard(int userGameId, IList<NavyBattlePiece> shipPieces);

        IList<NavyBattlePiece> ShipPlacement(int userGameId);

        IList<Ship> GetShips(IList<ShipGame> shipGame);

        IList<ShipGame> GetShipGames(Game game);
    }
}
