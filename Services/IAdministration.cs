using BattleShips.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    public interface IAdministration
    {
        IList<ApplicationUser> GetAllUsers();
        IList<ApplicationUser> SearchUser(string searchTerm);
        ApplicationUser GetUserDetail(Guid userId);

        IList<Game> GetUsersGames(Guid userId);

        void UpdatePlayerName(string PlayerName, Guid id);
        bool DeleteUser(Guid id);
    }
}
