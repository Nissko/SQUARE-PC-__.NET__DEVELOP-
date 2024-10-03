using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Infrastructure.Configurations.Cpu
{
    class CpuGpuCoreInfoConfiguration
        : IEntityTypeConfiguration<CpuGpuCoreInfoEntity>
    {
        public void Configure(EntityTypeBuilder<CpuGpuCoreInfoEntity> cpuConfiguration)
        {
            cpuConfiguration.ToTable("CpuGpuCoreInfos");

            cpuConfiguration.HasKey(o => o.Id);
            
            cpuConfiguration.Property<Guid>("CpuId");
            
            cpuConfiguration
                .Property<bool>("_hasGpuCore")
                .HasColumnName("HasGpuCore");
            
            cpuConfiguration
                .Property<string>("_cpuModelGraphCore")
                .HasColumnName("ModelGraphCore");
            
            cpuConfiguration
                .Property<int>("_cpuMaxClockGraphCore")
                .HasColumnName("MaxClockGraphCore");
            
            cpuConfiguration
                .Property<int>("_cpuGraphBlocks")
                .HasColumnName("GraphBlocks");
            
            cpuConfiguration
                .Property<int>("_cpuShadingUnits")
                .HasColumnName("ShadingUnits");
        }
    }
}

