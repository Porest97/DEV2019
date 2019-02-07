using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stats2019.Models;

namespace Stats2019.Models
{
    public class Stats2019Context : DbContext
    {
        public Stats2019Context (DbContextOptions<Stats2019Context> options)
            : base(options)
        {
        }

        public DbSet<Stats2019.Models.Matches> Matches { get; set; }

        public DbSet<Stats2019.Models.Arena> Arena { get; set; }

        public DbSet<Stats2019.Models.Person> Person { get; set; }

        public DbSet<Stats2019.Models.Team> Team { get; set; }

        public DbSet<Stats2019.Models.Series> Series { get; set; }
    }
}
