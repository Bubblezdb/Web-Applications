using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    /* Entity Framework Core provides access to the database through context classes. 
     * Remember to add the associated namespace: using Microsoft.EntityFrameworkCore;*/
    public class StoreDbContext: DbContext 
        /* the base class DbContect provides access to the Entity Framework Core's underlying 
         functionality. To view the actual properties and method within DbContext
        right click on it, and go to Definition. */
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        /*This property creates the table Products from the Products properties in Product.cs
         make sure to add the services in the Start.cs
         */
        public DbSet<Order> Orders { get; set; }
    }
}
