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


        bool RemoveGame(Guid gameId);
        void RemoveUser(string userId);

        /// <summary>
        /// Gets the users Games
        /// </summary>
        /// <returns></returns>
        IList<Game> GetUsersGames();

        IList<ApplicationUser> UsersByScore();
        //public ApplicationUser GetLoggedInUser();

        /// <summary>
        /// Gets the rest of the joinable games
        /// </summary>
        /// <returns></returns>
        IList<Game> GetOtherGames();

        /// <summary>
        /// gets logged in users id
        /// </summary>
        /// <returns></returns>
        Guid GetUserId();

        /// <summary>
        /// guid = game id
        /// </summary>
        /// <param name="key"></param>
        /// <param name="guid"></param>
        void SaveGame(string key, Guid guid);

        /// <summary>
        /// If user doesnt have any setup game then new setup game is created and registered as currentGame otherwise an existing game is registered.
        /// </summary>
        void SetupGame();

        IList<ApplicationUser> GetTopUsers();
        ApplicationUser GetLoggedInUser();
       
    }
}
