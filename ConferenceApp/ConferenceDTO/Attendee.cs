using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ConferenceDTO
{
    public class Attendee
    {
        [Key]//identifying the ID as Key
        public int Id { get; set; }
       

        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }

        
        [StringLength(200)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string UserName { get; set; }

        [StringLength(256)]
        public virtual string EmailAddress { get; set; }
    }
}
