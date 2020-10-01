using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    /* Models are written in C#, just like all other C# programs.
     * This model provides the database content. Writing out the table content within ASP.Net
     * before creating the Database is called the "Code-First" method. 
     * If the database was created and then scaffolded into the ASP.Net program is called the
     * "Database-First" method.
     */
    public class Product
    {
        public long ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue,ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }
    }
}
