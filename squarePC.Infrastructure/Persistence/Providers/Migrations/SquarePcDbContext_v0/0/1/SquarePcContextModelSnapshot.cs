﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using squarePC.Infrastructure;

#nullable disable

namespace squarePC.Infrastructure.Persistence.Providers.Migrations.SquarePcDbContext_v0._0._1
{
    [DbContext(typeof(SquarePcContext))]
    partial class SquarePcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("squarePC.Domain.Aggregates.CpuAggregate.CpuBusAndControllersEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CpuId")
                        .HasColumnType("uuid");

                    b.Property<int>("_countLinesPciExpress")
                        .HasColumnType("integer")
                        .HasColumnName("CountLinesPciExpress");

                    b.Property<string>("_pciExpressControllerVersion")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("PciExpressControllerVersion");

                    b.HasKey("Id");

                    b.ToTable("CpuBusAndControllers", (string)null);
                });

            modelBuilder.Entity("squarePC.Domain.Aggregates.CpuAggregate.CpuClocksAndOcEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("_baseClock")
                        .HasColumnType("numeric")
                        .HasColumnName("BaseClock");

                    b.Property<decimal>("_baseClockECore")
                        .HasColumnType("numeric")
                        .HasColumnName("BaseClockECore");

                    b.Property<bool>("_freeMultiplier")
                        .HasColumnType("boolean")
                        .HasColumnName("FreeMultiplier");

                    b.Property<decimal>("_turboClock")
                        .HasColumnType("numeric")
                        .HasColumnName("TurboClock");

                    b.Property<decimal>("_turboClockECore")
                        .HasColumnType("numeric")
                        .HasColumnName("TurboClockECore");

                    b.HasKey("Id");

                    b.ToTable("CpuClocksAndOcs", (string)null);
                });

            modelBuilder.Entity("squarePC.Domain.Aggregates.CpuAggregate.CpuCoreAndArchitectureEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("_allCores")
                        .HasColumnType("integer")
                        .HasColumnName("AllCores");

                    b.Property<int>("_allThreads")
                        .HasColumnType("integer")
                        .HasColumnName("AllThreads");

                    b.Property<string>("_cacheL2")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CacheL2");

                    b.Property<string>("_cacheL3")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CacheL3");

                    b.Property<string>("_coreName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CoreName");

                    b.Property<int>("_eCores")
                        .HasColumnType("integer")
                        .HasColumnName("ECores");

                    b.Property<int>("_pCores")
                        .HasColumnType("integer")
                        .HasColumnName("PCores");

                    b.Property<int>("_technoProcess")
                        .HasColumnType("integer")
                        .HasColumnName("TechnoProcess");

                    b.Property<bool>("_virtualization")
                        .HasColumnType("boolean")
                        .HasColumnName("Virtualization");

                    b.HasKey("Id");

                    b.ToTable("CpuCoreAndArchitectures", (string)null);
                });

            modelBuilder.Entity("squarePC.Domain.Aggregates.CpuAggregate.CpuEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("_cpuBusAndControllerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("_cpuClocksAndOcId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("_cpuCoreAndArchitectureId")
                        .HasColumnType("uuid");

                    b.Property<int>("_cpuCount")
                        .HasColumnType("integer")
                        .HasColumnName("CpuCount");

                    b.Property<Guid>("_cpuGpuCoreId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("_cpuMainInfoId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("_cpuPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("Price");

                    b.Property<Guid>("_cpuRamId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("_cpuTdpId")
                        .HasColumnType("uuid");

                    b.Property<bool>("_inStock")
                        .HasColumnType("boolean")
                        .HasColumnName("InStock");

                    b.HasKey("Id");

                    b.HasIndex("_cpuBusAndControllerId");

                    b.HasIndex("_cpuClocksAndOcId");

                    b.HasIndex("_cpuCoreAndArchitectureId");

                    b.HasIndex("_cpuGpuCoreId");

                    b.HasIndex("_cpuMainInfoId");

                    b.HasIndex("_cpuRamId");

                    b.HasIndex("_cpuTdpId");

                    b.ToTable("Cpus", (string)null);
                });

            modelBuilder.Entity("squarePC.Domain.Aggregates.CpuAggregate.CpuGpuCoreInfoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("_cpuGraphBlocks")
                        .HasColumnType("integer")
                        .HasColumnName("GraphBlocks");

                    b.Property<int>("_cpuMaxClockGraphCore")
                        .HasColumnType("integer")
                        .HasColumnName("MaxClockGraphCore");

                    b.Property<string>("_cpuModelGraphCore")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ModelGraphCore");

                    b.Property<int>("_cpuShadingUnits")
                        .HasColumnType("integer")
                        .HasColumnName("ShadingUnits");

                    b.Property<bool>("_hasGpuCore")
                        .HasColumnType("boolean")
                        .HasColumnName("HasGpuCore");

                    b.HasKey("Id");

                    b.ToTable("CpuGpuCoreInfos", (string)null);
                });

            modelBuilder.Entity("squarePC.Domain.Aggregates.CpuAggregate.CpuImageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("_cpuId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("_imgId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("_cpuId");

                    b.HasIndex("_imgId");

                    b.ToTable("CpuImageProducts", (string)null);
                });

            modelBuilder.Entity("squarePC.Domain.Aggregates.CpuAggregate.CpuMainInfoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("_codeManufacture")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CodeManufacture");

                    b.Property<Guid>("_familyCpuId")
                        .HasColumnType("uuid");

                    b.Property<string>("_model")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Model");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<DateTime>("_releaseDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ReleaseDate");

                    b.Property<Guid>("_socketId")
                        .HasColumnType("uuid");

                    b.Property<string>("_warranty")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Warranty");

                    b.HasKey("Id");

                    b.HasIndex("_familyCpuId");

                    b.HasIndex("_socketId");

                    b.ToTable("CpuMainInfos", (string)null);
                });

            modelBuilder.Entity("squarePC.Domain.Aggregates.CpuAggregate.CpuRamInfoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("_clockMemory")
                        .HasColumnType("integer")
                        .HasColumnName("ClockMemory");

                    b.Property<int>("_maxChannelMemory")
                        .HasColumnType("integer")
                        .HasColumnName("MaxChannelMemory");

                    b.Property<int>("_maxValueMemory")
                        .HasColumnType("integer")
                        .HasColumnName("MaxValueMemory");

                    b.Property<Guid>("_memoryTypeId")
                        .HasColumnType("uuid");

                    b.Property<bool>("_supportECC")
                        .HasColumnType("boolean")
                        .HasColumnName("SupportECC");

                    b.HasKey("Id");

                    b.HasIndex("_memoryTypeId");

                    b.ToTable("CpuRamInfos", (string)null);
                });

            modelBuilder.Entity("squarePC.Domain.Aggregates.CpuAggregate.CpuTdpInfoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("_TDP")
                        .HasColumnType("integer")
                        .HasColumnName("TDP");

                    b.Property<int>("_baseTDP")
                        .HasColumnType("integer")
                        .HasColumnName("BaseTDP");

                    b.Property<int>("_maxTempCPU")
                        .HasColumnType("integer")
                        .HasColumnName("MaxTempCPU");

                    b.HasKey("Id");

                    b.ToTable("CpuTdpInfos", (string)null);
                });

            modelBuilder.Entity("squarePC.Domain.Aggregates.Image.ImageProductsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("_displayOrder")
                        .HasColumnType("integer")
                        .HasColumnName("DisplayOrder");

                    b.Property<byte[]>("_image")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("Image");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("ImageProducts", (string)null);
                });

            modelBuilder.Entity("squarePC.Domain.Enums.CpuEnums.CpuFamilyEnum", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("CpuFamilies", (string)null);
                });

            modelBuilder.Entity("squarePC.Domain.Enums.CpuEnums.CpuMemoryTypeEnum", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("CpuMemories", (string)null);
                });

            modelBuilder.Entity("squarePC.Domain.Enums.CpuEnums.CpuSocketEnum", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("CpuSockets", (string)null);
                });

            modelBuilder.Entity("squarePC.Domain.Aggregates.CpuAggregate.CpuEntity", b =>
                {
                    b.HasOne("squarePC.Domain.Aggregates.CpuAggregate.CpuBusAndControllersEntity", "CpuBusAndController")
                        .WithMany()
                        .HasForeignKey("_cpuBusAndControllerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("squarePC.Domain.Aggregates.CpuAggregate.CpuClocksAndOcEntity", "CpuClocksAndOc")
                        .WithMany()
                        .HasForeignKey("_cpuClocksAndOcId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("squarePC.Domain.Aggregates.CpuAggregate.CpuCoreAndArchitectureEntity", "CpuCoreAndArchitecture")
                        .WithMany()
                        .HasForeignKey("_cpuCoreAndArchitectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("squarePC.Domain.Aggregates.CpuAggregate.CpuGpuCoreInfoEntity", "CpuGpuCore")
                        .WithMany()
                        .HasForeignKey("_cpuGpuCoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("squarePC.Domain.Aggregates.CpuAggregate.CpuMainInfoEntity", "CpuMainInfo")
                        .WithMany()
                        .HasForeignKey("_cpuMainInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("squarePC.Domain.Aggregates.CpuAggregate.CpuRamInfoEntity", "CpuRam")
                        .WithMany()
                        .HasForeignKey("_cpuRamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("squarePC.Domain.Aggregates.CpuAggregate.CpuTdpInfoEntity", "CpuTdp")
                        .WithMany()
                        .HasForeignKey("_cpuTdpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CpuBusAndController");

                    b.Navigation("CpuClocksAndOc");

                    b.Navigation("CpuCoreAndArchitecture");

                    b.Navigation("CpuGpuCore");

                    b.Navigation("CpuMainInfo");

                    b.Navigation("CpuRam");

                    b.Navigation("CpuTdp");
                });

            modelBuilder.Entity("squarePC.Domain.Aggregates.CpuAggregate.CpuImageEntity", b =>
                {
                    b.HasOne("squarePC.Domain.Aggregates.CpuAggregate.CpuEntity", "Cpu")
                        .WithMany("CpuImages")
                        .HasForeignKey("_cpuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("squarePC.Domain.Aggregates.Image.ImageProductsEntity", "Image")
                        .WithMany("CpuImages")
                        .HasForeignKey("_imgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cpu");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("squarePC.Domain.Aggregates.CpuAggregate.CpuMainInfoEntity", b =>
                {
                    b.HasOne("squarePC.Domain.Enums.CpuEnums.CpuFamilyEnum", "CpuFamily")
                        .WithMany()
                        .HasForeignKey("_familyCpuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("squarePC.Domain.Enums.CpuEnums.CpuSocketEnum", "CpuSocket")
                        .WithMany()
                        .HasForeignKey("_socketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CpuFamily");

                    b.Navigation("CpuSocket");
                });

            modelBuilder.Entity("squarePC.Domain.Aggregates.CpuAggregate.CpuRamInfoEntity", b =>
                {
                    b.HasOne("squarePC.Domain.Enums.CpuEnums.CpuMemoryTypeEnum", "MemoryType")
                        .WithMany()
                        .HasForeignKey("_memoryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MemoryType");
                });

            modelBuilder.Entity("squarePC.Domain.Aggregates.CpuAggregate.CpuEntity", b =>
                {
                    b.Navigation("CpuImages");
                });

            modelBuilder.Entity("squarePC.Domain.Aggregates.Image.ImageProductsEntity", b =>
                {
                    b.Navigation("CpuImages");
                });
#pragma warning restore 612, 618
        }
    }
}
