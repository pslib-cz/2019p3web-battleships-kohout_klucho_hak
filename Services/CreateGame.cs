using BattleShips.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    /// <summary>
    /// Holds logic, data manipulation and creation for creation of new game.
    /// </summary>
    public class CreateGame : ICreation
    {

        readonly ApplicationDbContext _db;

        public CreateGame(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateNewGame(string userId, int maxPlayers, int boardSize)
        {
            try
            {
                Guid newGameId = Guid.NewGuid();
                //SaveGame("Game", newGameId)
                var game = new Game() { OwnerId = userId, MaxPlayers = maxPlayers, GameSize = boardSize, Id = newGameId };
                _db.Games.Add(game);
                _db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
