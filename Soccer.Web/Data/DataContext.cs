using Microsoft.EntityFrameworkCore;
using Soccer.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Soccer.Web.Data
{
    public class DataContext: DbContext
    {

        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<TeamEntity> TeamEntities { get; set; }

        public DbSet<GroupDetailEntity> GroupDetails { get; set; }

        public DbSet<GroupEntity> Groups { get; set; }

        public DbSet<MatchEntity> Matches { get; set; }

        public DbSet<TeamEntity> Teams { get; set; }

        public DbSet<TournamentEnity> Tournaments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamEntity>().HasIndex(t => t.Name).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
