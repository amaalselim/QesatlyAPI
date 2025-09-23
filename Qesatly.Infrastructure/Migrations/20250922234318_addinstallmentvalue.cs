using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qesatly.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addinstallmentvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "InstallmentValue",
                table: "contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstallmentValue",
                table: "contracts");
        }
    }
}
