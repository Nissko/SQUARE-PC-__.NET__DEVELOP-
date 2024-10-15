using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Infrastructure.Configurations.Cpu
{
    class CpuBusAndControllerConfiguration
        : IEntityTypeConfiguration<CpuBusAndControllersEntity>
    {
        public void Configure(EntityTypeBuilder<CpuBusAndControllersEntity> cpuConfiguration)
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