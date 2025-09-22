using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qesatly.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientsId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "clientId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_ClientsId",
                table: "products",
                column: "ClientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_clients_ClientsId",
                table: "products",
                column: "ClientsId",
                principalTable: "clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_clients_ClientsId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_ClientsId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ClientsId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "clientId",
                table: "products");
        }
    }
}
