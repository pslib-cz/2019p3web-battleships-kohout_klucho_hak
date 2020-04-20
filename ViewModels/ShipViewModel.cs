using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.ViewModels
{
    public class ShipViewModel
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Name of the ship")]
        public string Name { get; set; }

    }
}
