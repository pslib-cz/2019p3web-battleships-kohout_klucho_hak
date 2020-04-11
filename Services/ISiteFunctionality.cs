using BattleShips.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    /// <summary>
    /// Logic, data creation and manipulation for non game related stuff. 
    /// 
    public interface ISiteFunctionality
    {


        public void RemoveGame(Guid gameId);
        public void RemoveUser(string userId);

        /// <summary>
        /// games = list her do Pages/GameList
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>list</returns>
        IList<Game> GetGames(string userId);
        IList<ApplicationUser> UsersByScore();
        public ApplicationUser GetLoggedInUser();
    }
}
