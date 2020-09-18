using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Speaker
    {
        [Key]//identifying the ID as Key
        public int Id { get; set; }
        /// <summary>
        ///  Add the name of the speaker
        /// </summary>


        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Biographical infromation about our speaker
        /// </summary>
        [StringLength(4000)]
        public string Bio { get; set; }

        /// <summary>
        /// Where you can learn more about our speaker
        /// </summary>
        [StringLength(1000)]
        public virtual string Website { get; set; }
    }
}
