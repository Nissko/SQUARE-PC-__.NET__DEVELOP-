using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Infrastructure.Configurations.Cpu
{
    public class CpuImageConfiguration
        : IEntityTypeConfiguration<CpuImageEntity>
    {
        public void Configure(EntityTypeBuilder<CpuImageEntity> cpuImgConfiguration)
        {
            cpuImgConfiguration.ToTable("CpuImageProducts");

            cpuImgConfiguration.HasKey(o => o.Id);

            cpuImgConfiguration
                .HasOne(cp => cp.Cpu)
                .WithMany(p => p.CpuImages)
                .HasForeignKey("_cpuId");
            
            cpuImgConfiguration
                .HasOne(c=> c.Image)
                .WithMany(c=>c.CpuImages)
                .HasForeignKey("_imgId");
        }
    }
}