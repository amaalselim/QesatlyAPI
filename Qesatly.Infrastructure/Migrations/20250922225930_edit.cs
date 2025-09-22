using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qesatly.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "guarantorAddress",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "guarantorNationalNumber",
                table: "clients");

            migrationBuilder.AlterColumn<string>(
                name: "NationalNumber",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NationalNumber",
                table: "clients",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "guarantorAddress",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "guarantorNationalNumber",
                table: "clients",
                type: "int",
                nullable: true);
        }
    }
}
