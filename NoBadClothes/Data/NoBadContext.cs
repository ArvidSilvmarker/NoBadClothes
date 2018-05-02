using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NoBadClothes
{
    public class NoBadContext : DbContext
    {
        public DbSet<Station> Stations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = db-nobadclothes; Trusted_Connection = True; ");
        }
    }
}
