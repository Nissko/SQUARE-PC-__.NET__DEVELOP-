using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using squarePC.Domain.Aggregates.ConfigurationAggregate;
using squarePC.Domain.Aggregates.CpuAggregate;
using squarePC.Domain.Enums.CpuEnums;

namespace squarePC.Application.Common.Interfaces
{
    public interface ISquarePcContext
    {
        DatabaseFacade Database { get; }
        
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

        void Migrate();
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}