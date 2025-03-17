using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CpuEntity = squarePC.Domain.Aggregates.CpuAggregate.CpuEntity;

namespace squarePC.Infrastructure.Configurations.Cpu
{
    class CpuTdpInfoConfiguration
        : IEntityTypeConfiguration<CpuEntity>
    {
        public void Configure(EntityTypeBuilder<CpuEntity> cpuConfiguration)
        {
            cpuConfiguration.ToTable("CpuTdpInfos");

            cpuConfiguration.HasKey(o => o.Id);

            cpuConfiguration
                .Property<int>("_TDP")
                .HasColumnName("TDP");
            
            cpuConfiguration
                .Property<int>("_baseTDP")
                .HasColumnName("BaseTDP");
            
            cpuConfiguration
                .Property<int>("_maxTempCPU")
                .HasColumnName("MaxTempCPU");
        }
    }
}