using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Infrastructure.Configurations.Cpu
{
    class CpuClocksAndOcConfiguration
        : IEntityTypeConfiguration<CpuClocksAndOcEntity>
    {
        public void Configure(EntityTypeBuilder<CpuClocksAndOcEntity> cpuConfiguration)
        {
            cpuConfiguration.ToTable("CpuClocksAndOcs");

            cpuConfiguration.HasKey(o => o.Id);
            
            cpuConfiguration.Property<Guid>("CpuId");
            
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