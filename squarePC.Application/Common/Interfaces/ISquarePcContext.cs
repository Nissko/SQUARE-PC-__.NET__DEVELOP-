using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using squarePC.Domain.Aggregates.CpuAggregate;
using squarePC.Domain.Aggregates.Image;
using CpuEntity = squarePC.Domain.Aggregates.CpuAggregate.CpuEntity;

namespace squarePC.Application.Common.Interfaces
{
    public interface ISquarePcContext
    {
        DatabaseFacade Database { get; }
        
        #region CPU

        public DbSet<CpuEntity> Cpus { get; set; }
        public DbSet<CpuImageEntity> CpuImages { get; set; }

        #endregion
        
        public DbSet<ImageProductsEntity> ImageProducts { get; set; }

        void Migrate();
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}