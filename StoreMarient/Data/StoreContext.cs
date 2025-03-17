
using Microsoft.EntityFrameworkCore;
using StoreMarient.Entities;
using StoreMarient.EntitiesConfig.Base;

namespace StoreMarient.Data
{
    public class StoreContext : DbContext
    {
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();

        public DbSet<Piece> Pieces => Set<Piece>();

        public DbSet<Phone> Phones => Set<Phone>();
        public DbSet<PhoneType> PhoneTypes => Set<PhoneType>();

        public DbSet<Mica> Micas => Set<Mica>();
        public DbSet<CoverType> CoverTypes => Set<CoverType>();

        public DbSet<Cover> Covers => Set<Cover>();

        public DbSet<CoverStock> CoverStocks => Set<CoverStock>();

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Seed();

            ProductDBConfig.SetEntityBuilder(modelBuilder);
            CategoryDBConfig.SetEntityBuilder(modelBuilder);
            PieceDBConfig.SetEntityBuilder(modelBuilder);
            PhoneDBConfig.SetEntityBuilder(modelBuilder);
            PhoneTypeDBConfig.SetEntityBuilder(modelBuilder);
            MicaDBConfig.SetEntityBuilder(modelBuilder);
            CoverTypeDBConfig.SetEntityBuilder(modelBuilder);
            CoverDBConfig.SetEntityBuilder(modelBuilder);
            CoverStockDBConfig.SetEntityBuilder(modelBuilder);
        }
    }
}

