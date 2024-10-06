using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Infrastructure.Configurations.Cpu
{
    class CpuTdpInfoConfiguration
        : IEntityTypeConfiguration<CpuTdpInfoEntity>
    {
        public void Configure(EntityTypeBuilder<CpuTdpInfoEntity> cpuConfiguration)
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