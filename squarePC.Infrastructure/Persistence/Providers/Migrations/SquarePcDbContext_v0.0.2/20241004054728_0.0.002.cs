using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace squarePC.Infrastructure.Persistence.Providers.Migrations.SquarePcDbContext_v0._0._2
{
    /// <inheritdoc />
    public partial class _00002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CpuCount",
                table: "Cpus",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "Cpus",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Cpus",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CpuCount",
                table: "Cpus");

            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Cpus");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cpus");
        }
    }
}
