using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CpuEntity = squarePC.Domain.Aggregates.CpuAggregate.CpuEntity;

namespace squarePC.Infrastructure.Configurations.Cpu
{
    class CpuBusAndControllerConfiguration
        : IEntityTypeConfiguration<CpuEntity>
    {
        public void Configure(EntityTypeBuilder<CpuEntity> cpuConfiguration)
        {
            cpuConfiguration.ToTable("CpuBusAndControllers");

            cpuConfiguration.HasKey(o => o.Id);

            cpuConfiguration
                .Property<string>("_pciExpressControllerVersion")
                .HasColumnName("PciExpressControllerVersion");
            
            cpuConfiguration
                .Property<int>("_countLinesPciExpress")
                .HasColumnName("CountLinesPciExpress");
        }
    }
}