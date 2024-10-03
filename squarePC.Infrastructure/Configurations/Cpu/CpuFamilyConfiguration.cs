using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squarePC.Domain.Enums.CpuEnums;

namespace squarePC.Infrastructure.Configurations.Cpu
{
    class CpuFamilyConfiguration
        : IEntityTypeConfiguration<CpuFamilyEnum>
    {
        public void Configure(EntityTypeBuilder<CpuFamilyEnum> cpuConfiguration)
        {
            cpuConfiguration.ToTable("CpuFamilies");

            cpuConfiguration.Property(o=>o.Id)
                .ValueGeneratedNever();

            cpuConfiguration
                .Property(o => o.Name)
                .HasMaxLength(250);
        }
    }
}