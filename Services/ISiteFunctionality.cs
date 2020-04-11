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
    }
}
