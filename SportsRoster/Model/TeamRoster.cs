using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRoster.Model
{
    public class TeamRoster
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamLocation { get; set; }
        public int PlayerId { get; set; }
        public string PlayerFName { get; set; }
        public string PlayerLName { get; set; }
        
    }
}
