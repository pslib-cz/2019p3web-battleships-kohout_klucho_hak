using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    public interface IBattleShipGameLoaderSaver
    {
        /// <summary>
        /// Saves game into session.
        /// </summary>
        /// <param name="key"> for example string "hra"..., is used in LoadOrCreate method</param>
        /// <param name="data">GUID hry</param>
        public void SaveGame(string key, Guid data);

        /// <summary>
        /// Loads game in session.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Guid of the game. If here is none than it returns default Guid which is zeros.</returns>
        public Guid LoadGame(string key);
    

    }
}
