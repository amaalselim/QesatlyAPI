using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qesatly.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_clients_ClientsId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_ClientsId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ClientsId",
                table: "products");

            migrationBuilder.CreateIndex(
                name: "IX_products_clientId",
                table: "products",
                column: "clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_clients_clientId",
                table: "products",
                column: "clientId",
                principalTable: "clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_clients_clientId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_clientId",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientsId",
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
    }
}
