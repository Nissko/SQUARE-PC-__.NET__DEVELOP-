using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CpuEntity = squarePC.Domain.Aggregates.CpuAggregate.CpuEntity;

namespace squarePC.Infrastructure.Configurations.Cpu
{
    class CpuConfiguration
        : IEntityTypeConfiguration<CpuEntity>
    {
        public void Configure(EntityTypeBuilder<CpuEntity> cpuConfiguration)
        {
            cpuConfiguration.ToTable("Cpus");

            cpuConfiguration.HasKey(o => o.Id);

            cpuConfiguration
                .Property<decimal>("_cpuPrice")
                .HasColumnName("Price");
            
            cpuConfiguration
                .Property<bool>("_inStock")
                .HasColumnName("InStock");
            
            cpuConfiguration
                .Property<int>("_cpuCount")
                .HasColumnName("CpuCount");
            
            /*cpuConfiguration.HasOne(c=> c.CpuMainInfo)
                .WithMany()
                .HasForeignKey("_cpuMainInfoId");
            
            cpuConfiguration.HasOne(c=> c.CpuCoreAndArchitecture)
                .WithMany()
                .HasForeignKey("_cpuCoreAndArchitectureId");
            
            cpuConfiguration.HasOne(c=> c.CpuClocksAndOc)
                .WithMany()
                .HasForeignKey("_cpuClocksAndOcId");
            
            cpuConfiguration.HasOne(c=> c.CpuTdp)
                .WithMany()
                .HasForeignKey("_cpuTdpId");
            
            cpuConfiguration.HasOne(c=> c.CpuRam)
                .WithMany()
                .HasForeignKey("_cpuRamId");
            
            cpuConfiguration.HasOne(c=> c.CpuBusAndController)
                .WithMany()
                .HasForeignKey("_cpuBusAndControllerId");
            
            cpuConfiguration.HasOne(c=> c.CpuGpuCore)
                .WithMany()
                .HasForeignKey("_cpuGpuCoreId");*/
        }
    }
}