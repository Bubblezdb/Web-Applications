using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsRoster.Model;

namespace SportsRoster.Model
{
    public class TeamDBContext: DbContext
    {
        public TeamDBContext(DbContextOptions<TeamDBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamRoster>().HasKey(i => new { i.TeamId, i.PlayerId });
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<SportsRoster.Model.TeamRoster> TeamRoster { get; set; }
    }
}
