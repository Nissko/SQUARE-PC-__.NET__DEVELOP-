using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Infrastructure.Configurations.Cpu
{
    class CpuRamInfoConfiguration
        : IEntityTypeConfiguration<CpuRamInfoEntity>
    {
        public void Configure(EntityTypeBuilder<CpuRamInfoEntity> cpuConfiguration)
        {
            cpuConfiguration.ToTable("CpuRamInfos");

            cpuConfiguration.HasKey(o => o.Id);

            cpuConfiguration.HasOne(c => c.MemoryType)
                .WithMany()
                .HasForeignKey("_memoryTypeId");
            
            cpuConfiguration
                .Property<int>("_maxValueMemory")
                .HasColumnName("MaxValueMemory");
            
            cpuConfiguration
                .Property<int>("_maxChannelMemory")
                .HasColumnName("MaxChannelMemory");
            
            cpuConfiguration
                .Property<int>("_clockMemory")
                .HasColumnName("ClockMemory");
            
            cpuConfiguration
                .Property<bool>("_supportECC")
                .HasColumnName("SupportECC");
        }
    }
}