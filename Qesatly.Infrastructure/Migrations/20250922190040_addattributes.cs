using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qesatly.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addattributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "installments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "installments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "installments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "installments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "installments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DownPayment",
                table: "contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "contracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InstallmentCount",
                table: "contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "contracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "clientId",
                table: "contracts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "insertRate",
                table: "contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "contracts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cardphoto",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Isguarantor",
                table: "clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NationalNumber",
                table: "clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "guarantorAddress",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "guarantorCardphoto",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "guarantorName",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "guarantorNationalNumber",
                table: "clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "guarantorPhone",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_installments_ContractId",
                table: "installments",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_clientId",
                table: "contracts",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_productId",
                table: "contracts",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_contracts_clients_clientId",
                table: "contracts",
                column: "clientId",
                principalTable: "clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_contracts_products_productId",
                table: "contracts",
                column: "productId",
                principalTable: "products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_installments_contracts_ContractId",
                table: "installments",
                column: "ContractId",
                principalTable: "contracts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contracts_clients_clientId",
                table: "contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_contracts_products_productId",
                table: "contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_installments_contracts_ContractId",
                table: "installments");

            migrationBuilder.DropIndex(
                name: "IX_installments_ContractId",
                table: "installments");

            migrationBuilder.DropIndex(
                name: "IX_contracts_clientId",
                table: "contracts");

            migrationBuilder.DropIndex(
                name: "IX_contracts_productId",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "installments");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "installments");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "installments");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "installments");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "installments");

            migrationBuilder.DropColumn(
                name: "DownPayment",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "InstallmentCount",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "clientId",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "insertRate",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "Cardphoto",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "Isguarantor",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "NationalNumber",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "guarantorAddress",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "guarantorCardphoto",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "guarantorName",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "guarantorNationalNumber",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "guarantorPhone",
                table: "clients");
        }
    }
}
