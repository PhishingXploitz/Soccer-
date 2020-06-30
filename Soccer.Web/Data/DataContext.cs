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
    }
}
