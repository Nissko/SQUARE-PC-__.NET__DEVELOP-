using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace squarePC.Infrastructure.Persistence.Providers.Migrations.SquarePcDbContext_v0._0._0
{
    /// <inheritdoc />
    public partial class _000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CpuBusAndControllers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CountLinesPciExpress = table.Column<int>(type: "integer", nullable: false),
                    PciExpressControllerVersion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpuBusAndControllers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CpuClocksAndOcs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BaseClock = table.Column<decimal>(type: "numeric", nullable: false),
                    BaseClockECore = table.Column<decimal>(type: "numeric", nullable: false),
                    FreeMultiplier = table.Column<bool>(type: "boolean", nullable: false),
                    TurboClock = table.Column<decimal>(type: "numeric", nullable: false),
                    TurboClockECore = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpuClocksAndOcs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CpuCoreAndArchitectures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AllCores = table.Column<int>(type: "integer", nullable: false),
                    AllThreads = table.Column<int>(type: "integer", nullable: false),
                    CacheL2 = table.Column<string>(type: "text", nullable: false),
                    CacheL3 = table.Column<string>(type: "text", nullable: false),
                    CoreName = table.Column<string>(type: "text", nullable: false),
                    ECores = table.Column<int>(type: "integer", nullable: false),
                    PCores = table.Column<int>(type: "integer", nullable: false),
                    TechnoProcess = table.Column<int>(type: "integer", nullable: false),
                    Virtualization = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpuCoreAndArchitectures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CpuFamilies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpuFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CpuGpuCoreInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GraphBlocks = table.Column<int>(type: "integer", nullable: false),
                    MaxClockGraphCore = table.Column<int>(type: "integer", nullable: false),
                    ModelGraphCore = table.Column<string>(type: "text", nullable: false),
                    ShadingUnits = table.Column<int>(type: "integer", nullable: false),
                    HasGpuCore = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpuGpuCoreInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CpuMemories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpuMemories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CpuSockets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpuSockets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CpuTdpInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TDP = table.Column<int>(type: "integer", nullable: false),
                    BaseTDP = table.Column<int>(type: "integer", nullable: false),
                    MaxTempCPU = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpuTdpInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CpuRamInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    _memoryTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClockMemory = table.Column<int>(type: "integer", nullable: false),
                    MaxChannelMemory = table.Column<int>(type: "integer", nullable: false),
                    MaxValueMemory = table.Column<int>(type: "integer", nullable: false),
                    SupportECC = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpuRamInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CpuRamInfos_CpuMemories__memoryTypeId",
                        column: x => x._memoryTypeId,
                        principalTable: "CpuMemories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CpuMainInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    _familyCpuId = table.Column<Guid>(type: "uuid", nullable: false),
                    _socketId = table.Column<Guid>(type: "uuid", nullable: false),
                    CodeManufacture = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Warranty = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpuMainInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CpuMainInfos_CpuFamilies__familyCpuId",
                        column: x => x._familyCpuId,
                        principalTable: "CpuFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CpuMainInfos_CpuSockets__socketId",
                        column: x => x._socketId,
                        principalTable: "CpuSockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cpus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    _cpuMainInfoId = table.Column<Guid>(type: "uuid", nullable: false),
                    _cpuCoreAndArchitectureId = table.Column<Guid>(type: "uuid", nullable: false),
                    _cpuClocksAndOcId = table.Column<Guid>(type: "uuid", nullable: false),
                    _cpuTdpId = table.Column<Guid>(type: "uuid", nullable: false),
                    _cpuRamId = table.Column<Guid>(type: "uuid", nullable: false),
                    _cpuBusAndControllerId = table.Column<Guid>(type: "uuid", nullable: false),
                    _cpuGpuCoreId = table.Column<Guid>(type: "uuid", nullable: false),
                    CpuCount = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    InStock = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cpus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cpus_CpuBusAndControllers__cpuBusAndControllerId",
                        column: x => x._cpuBusAndControllerId,
                        principalTable: "CpuBusAndControllers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cpus_CpuClocksAndOcs__cpuClocksAndOcId",
                        column: x => x._cpuClocksAndOcId,
                        principalTable: "CpuClocksAndOcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cpus_CpuCoreAndArchitectures__cpuCoreAndArchitectureId",
                        column: x => x._cpuCoreAndArchitectureId,
                        principalTable: "CpuCoreAndArchitectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cpus_CpuGpuCoreInfos__cpuGpuCoreId",
                        column: x => x._cpuGpuCoreId,
                        principalTable: "CpuGpuCoreInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cpus_CpuMainInfos__cpuMainInfoId",
                        column: x => x._cpuMainInfoId,
                        principalTable: "CpuMainInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cpus_CpuRamInfos__cpuRamId",
                        column: x => x._cpuRamId,
                        principalTable: "CpuRamInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cpus_CpuTdpInfos__cpuTdpId",
                        column: x => x._cpuTdpId,
                        principalTable: "CpuTdpInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CpuImageProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    _cpuId = table.Column<Guid>(type: "uuid", nullable: false),
                    _imgId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpuImageProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CpuImageProducts_Cpus__cpuId",
                        column: x => x._cpuId,
                        principalTable: "Cpus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CpuImageProducts_ImageProducts__imgId",
                        column: x => x._imgId,
                        principalTable: "ImageProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CpuImageProducts__cpuId",
                table: "CpuImageProducts",
                column: "_cpuId");

            migrationBuilder.CreateIndex(
                name: "IX_CpuImageProducts__imgId",
                table: "CpuImageProducts",
                column: "_imgId");

            migrationBuilder.CreateIndex(
                name: "IX_CpuMainInfos__familyCpuId",
                table: "CpuMainInfos",
                column: "_familyCpuId");

            migrationBuilder.CreateIndex(
                name: "IX_CpuMainInfos__socketId",
                table: "CpuMainInfos",
                column: "_socketId");

            migrationBuilder.CreateIndex(
                name: "IX_CpuRamInfos__memoryTypeId",
                table: "CpuRamInfos",
                column: "_memoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cpus__cpuBusAndControllerId",
                table: "Cpus",
                column: "_cpuBusAndControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cpus__cpuClocksAndOcId",
                table: "Cpus",
                column: "_cpuClocksAndOcId");

            migrationBuilder.CreateIndex(
                name: "IX_Cpus__cpuCoreAndArchitectureId",
                table: "Cpus",
                column: "_cpuCoreAndArchitectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Cpus__cpuGpuCoreId",
                table: "Cpus",
                column: "_cpuGpuCoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Cpus__cpuMainInfoId",
                table: "Cpus",
                column: "_cpuMainInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cpus__cpuRamId",
                table: "Cpus",
                column: "_cpuRamId");

            migrationBuilder.CreateIndex(
                name: "IX_Cpus__cpuTdpId",
                table: "Cpus",
                column: "_cpuTdpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CpuImageProducts");

            migrationBuilder.DropTable(
                name: "Cpus");

            migrationBuilder.DropTable(
                name: "ImageProducts");

            migrationBuilder.DropTable(
                name: "CpuBusAndControllers");

            migrationBuilder.DropTable(
                name: "CpuClocksAndOcs");

            migrationBuilder.DropTable(
                name: "CpuCoreAndArchitectures");

            migrationBuilder.DropTable(
                name: "CpuGpuCoreInfos");

            migrationBuilder.DropTable(
                name: "CpuMainInfos");

            migrationBuilder.DropTable(
                name: "CpuRamInfos");

            migrationBuilder.DropTable(
                name: "CpuTdpInfos");

            migrationBuilder.DropTable(
                name: "CpuFamilies");

            migrationBuilder.DropTable(
                name: "CpuSockets");

            migrationBuilder.DropTable(
                name: "CpuMemories");
        }
    }
}
