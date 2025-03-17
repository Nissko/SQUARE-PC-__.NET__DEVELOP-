using Microsoft.EntityFrameworkCore;
using squarePC.Application.Common.Interfaces;
using squarePC.Domain.Aggregates.CpuAggregate;
using squarePC.Domain.Aggregates.Image;
using squarePC.Infrastructure.Configurations.Cpu;
using squarePC.Infrastructure.Configurations.Image.ProductImage;
using CpuEntity = squarePC.Domain.Aggregates.CpuAggregate.CpuEntity;

namespace squarePC.Infrastructure
{
    public class SquarePcContext : DbContext, ISquarePcContext
    {
        protected readonly string _defaultSchema = "SQUAREPC_MAIN";

        public SquarePcContext(DbContextOptions<SquarePcContext> options)
            : base(options)
        { }

        #region CPU

        public DbSet<CpuEntity> Cpus { get; set; }
        public DbSet<CpuImageEntity> CpuImages { get; set; }

        #endregion
        
        public DbSet<ImageProductsEntity> ImageProducts { get; set; }
        
        public void Migrate()
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CpuConfiguration());
            modelBuilder.ApplyConfiguration(new CpuImageConfiguration());

            modelBuilder.ApplyConfiguration(new ImageProductConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SquarePcContext).Assembly);
        }

        public SquarePcContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;User Id=postgres;Password=0000;Port=5432;Database=squarePcDB;")
                .UseLazyLoadingProxies();
        }
        
        protected static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
        {
            return new DbContextOptionsBuilder<T>()
                .Options;
        }
    }
}
