using System;
using Microsoft.EntityFrameworkCore;
using House.Core.Domain;

namespace House.Data
{
    public class HouseDbContext : DbContext
    {
        public HouseDbContext(DbContextOptions<HouseDbContext> options)
            : base(options) { }

        public DbSet<House_Fix> House { get; set; }

    }
}
