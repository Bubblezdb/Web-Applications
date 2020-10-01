using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRoster.Model
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        [StringLength(400)]
        public string FName { get; set; }
        [Required]
        [StringLength(400)]
        public string LName { get; set; }

        [ForeignKey("TeamId")]
        public int TeamId { get; set; }
        public Team team { get; set; }
        //needs a team object with team ID to as a foreign key
    }
}
