using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRoster.Model
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        [StringLength(400)]
        public string TName { get; set; }
        [Required]
        [StringLength(400)]
        public string TLocation { get; set; }

    }
}
