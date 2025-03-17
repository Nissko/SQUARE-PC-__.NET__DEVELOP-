/*
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace squarePC.Infrastructure.Configurations.Cpu
{
    class CpuMainInfoConfiguration
        : IEntityTypeConfiguration<CpuMainInfoEntity>
    {
        public void Configure(EntityTypeBuilder<CpuMainInfoEntity> cpuConfiguration)
        {
            cpuConfiguration.ToTable("CpuMainInfos");

            cpuConfiguration.HasKey(o => o.Id);

            cpuConfiguration
                .Property<string>("_name")
                .HasColumnName("Name");
            
            cpuConfiguration.HasOne(c => c.CpuFamily)
                .WithMany()
                .HasForeignKey("_familyCpuId");
            
            cpuConfiguration
                .Property<string>("_model")
                .HasColumnName("Model");
            
            cpuConfiguration.HasOne(c => c.CpuSocket)
                .WithMany()
                .HasForeignKey("_socketId");
            
            cpuConfiguration
                .Property<string>("_codeManufacture")
                .HasColumnName("CodeManufacture");
            
            cpuConfiguration
                .Property<DateTime>("_releaseDate")
                .HasColumnName("ReleaseDate");
            
            cpuConfiguration
                .Property<string>("_warranty")
                .HasColumnName("Warranty");
        }
    }
}
*/

