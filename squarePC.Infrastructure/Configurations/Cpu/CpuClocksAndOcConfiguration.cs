using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CpuEntity = squarePC.Domain.Aggregates.CpuAggregate.CpuEntity;

namespace squarePC.Infrastructure.Configurations.Cpu
{
    class CpuClocksAndOcConfiguration
        : IEntityTypeConfiguration<CpuEntity>
    {
        public void Configure(EntityTypeBuilder<CpuEntity> cpuConfiguration)
        {
            cpuConfiguration.ToTable("CpuClocksAndOcs");

            cpuConfiguration.HasKey(o => o.Id);
            
            cpuConfiguration
                .Property<decimal>("_baseClock")
                .HasColumnName("BaseClock");
            
            cpuConfiguration
                .Property<decimal>("_turboClock")
                .HasColumnName("TurboClock");
            
            cpuConfiguration
                .Property<decimal>("_baseClockECore")
                .HasColumnName("BaseClockECore");
            
            cpuConfiguration
                .Property<decimal>("_turboClockECore")
                .HasColumnName("TurboClockECore");
            
            cpuConfiguration
                .Property<bool>("_freeMultiplier")
                .HasColumnName("FreeMultiplier");
        }
    }
}