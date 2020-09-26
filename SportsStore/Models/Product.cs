using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

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
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
