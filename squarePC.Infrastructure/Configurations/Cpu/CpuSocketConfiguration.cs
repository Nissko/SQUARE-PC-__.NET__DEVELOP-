using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squarePC.Domain.Enums.CpuEnums;

namespace squarePC.Infrastructure.Configurations.Cpu
{
    class CpuSocketConfiguration
        : IEntityTypeConfiguration<CpuSocketEnum>
    {
        public void Configure(EntityTypeBuilder<CpuSocketEnum> cpuConfiguration)
        {
            cpuConfiguration.ToTable("CpuSockets");

            cpuConfiguration.Property(o=>o.Id)
                .ValueGeneratedNever();

            cpuConfiguration
                .Property(o => o.Name)
                .HasMaxLength(250);
        }
    }
}