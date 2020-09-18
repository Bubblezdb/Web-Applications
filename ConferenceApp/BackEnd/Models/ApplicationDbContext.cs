using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BackEnd.Models
{
    public class ApplicationDbContext : DbContext//must have this interface or options will error
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
        public DbSet<Speaker>Speaker { get; set; }
    }
}
