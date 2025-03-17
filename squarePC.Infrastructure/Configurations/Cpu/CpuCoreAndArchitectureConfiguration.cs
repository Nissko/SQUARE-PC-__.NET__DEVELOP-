using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CpuEntity = squarePC.Domain.Aggregates.CpuAggregate.CpuEntity;

namespace squarePC.Infrastructure.Configurations.Cpu
{
    class CpuCoreAndArchitectureConfiguration
        : IEntityTypeConfiguration<CpuEntity>
    {
        public void Configure(EntityTypeBuilder<CpuEntity> cpuConfiguration)
        {
            cpuConfiguration.ToTable("CpuCoreAndArchitectures");

            cpuConfiguration.HasKey(o => o.Id);

            cpuConfiguration
                .Property<int>("_allCores")
                .HasColumnName("AllCores");
            
            cpuConfiguration
                .Property<int>("_pCores")
                .HasColumnName("PCores");
            
            cpuConfiguration
                .Property<int>("_eCores")
                .HasColumnName("ECores");
            
            cpuConfiguration
                .Property<int>("_allThreads")
                .HasColumnName("AllThreads");
            
            cpuConfiguration
                .Property<string>("_cacheL2")
                .HasColumnName("CacheL2");
            
            cpuConfiguration
                .Property<string>("_cacheL3")
                .HasColumnName("CacheL3");
            
            cpuConfiguration
                .Property<int>("_technoProcess")
                .HasColumnName("TechnoProcess");
            
            cpuConfiguration
                .Property<string>("_coreName")
                .HasColumnName("CoreName");
            
            cpuConfiguration
                .Property<bool>("_virtualization")
                .HasColumnName("Virtualization");
        }
    }   
}