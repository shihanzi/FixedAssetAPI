using FixedAssetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FixedAssetAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Custodian> Custodions { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Disposal> Disposals { get; set; }
        public DbSet<Valuation> Valuations { get; set; }

    }
}
