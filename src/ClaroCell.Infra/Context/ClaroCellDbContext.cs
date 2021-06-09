using ClaroCell.Domain.Entities;
using ClaroCell.Infra.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroCell.Infra.Context
{
    public class ClaroCellDbContext : DbContext
    {
        public ClaroCellDbContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CellMapping).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMapping).Assembly);
        }
    }
}
