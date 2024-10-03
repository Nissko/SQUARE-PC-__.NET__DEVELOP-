using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squarePC.Domain.Enums.CpuEnums;

namespace squarePC.Infrastructure.Configurations.Cpu
{
    class CpuMemoryTypeConfiguration
        : IEntityTypeConfiguration<CpuMemoryTypeEnum>
    {
        public void Configure(EntityTypeBuilder<CpuMemoryTypeEnum> cpuConfiguration)
        {
            cpuConfiguration.ToTable("CpuMemories");

            cpuConfiguration.Property(o=>o.Id)
                .ValueGeneratedNever();

            cpuConfiguration
                .Property(o => o.Name)
                .HasMaxLength(250);
        }
    }
}