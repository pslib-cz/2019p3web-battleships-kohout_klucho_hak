using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Data;
using BattleShips.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BattleShips.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISiteFunctionality _siteFunctionality;

        public IList<ApplicationUser> TopPlayers { get; set; } //top 10 hraču

        public ApplicationUser LoggedInUser { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ISiteFunctionality siteFunctionality)
        {
            _logger = logger;
            _siteFunctionality = siteFunctionality;
        }

        public void OnGet()
        {
            TopPlayers = _siteFunctionality.GetTopUsers();
            LoggedInUser = _siteFunctionality.GetLoggedInUser();
        }
    }
}
