using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace squarePC.Infrastructure.Persistence.Providers.Migrations.SquarePcDbContext_v0._0._2
{
    /// <inheritdoc />
    public partial class _002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CpuImageProducts");

            migrationBuilder.DropTable(
                name: "ImageProducts");
        }
    }
}
