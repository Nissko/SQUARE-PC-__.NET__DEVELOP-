using Microsoft.EntityFrameworkCore;
using squarePC.Application.Common.Interfaces;
using squarePC.Domain.Aggregates.CpuAggregate;
using squarePC.Domain.Enums.CpuEnums;
using squarePC.Infrastructure.Configurations.Cpu;

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
        public DbSet<CpuMainInfoEntity> CpuMainInfos { get; set; }
        public DbSet<CpuCoreAndArchitectureEntity> CpuCoreAndArchitectures { get; set; }
        public DbSet<CpuClocksAndOcEntity> CpuClocksAndOcs { get; set; }
        public DbSet<CpuTdpInfoEntity> CpuTdpInfos { get; set; }
        public DbSet<CpuRamInfoEntity> CpuRamInfos { get; set; }
        public DbSet<CpuBusAndControllersEntity> CpuBusAndControllers { get; set; }
        public DbSet<CpuGpuCoreInfoEntity> CpuGpuCoreInfos { get; set; }
        public DbSet<CpuFamilyEnum> CpuFamilies { get; set; }
        public DbSet<CpuMemoryTypeEnum> CpuMemoryTypes { get; set; }
        public DbSet<CpuSocketEnum> CpuSockets { get; set; }

        #endregion
        

        public void Migrate()
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CpuConfiguration());
            modelBuilder.ApplyConfiguration(new CpuMainInfoConfiguration());
            modelBuilder.ApplyConfiguration(new CpuCoreAndArchitectureConfiguration());
            modelBuilder.ApplyConfiguration(new CpuClocksAndOcConfiguration());
            modelBuilder.ApplyConfiguration(new CpuTdpInfoConfiguration());
            modelBuilder.ApplyConfiguration(new CpuRamInfoConfiguration());
            modelBuilder.ApplyConfiguration(new CpuBusAndControllerConfiguration());
            modelBuilder.ApplyConfiguration(new CpuGpuCoreInfoConfiguration());
            modelBuilder.ApplyConfiguration(new CpuFamilyConfiguration());
            modelBuilder.ApplyConfiguration(new CpuMemoryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CpuSocketConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SquarePcContext).Assembly);
        }

        public SquarePcContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;User Id=postgres;Password=0000;Port=5432;Database=squarePcDB;");
        }
        
        protected static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
        {
            return new DbContextOptionsBuilder<T>()
                .Options;
        }
    }
}
