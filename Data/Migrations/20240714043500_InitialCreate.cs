using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_webapi_erp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    User = table.Column<Guid>(type: "TEXT", nullable: true),
                    Company = table.Column<Guid>(type: "TEXT", nullable: true),
                    Office = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Owner = table.Column<Guid>(type: "TEXT", nullable: true),
                    NumberEmployees = table.Column<int>(type: "INTEGER", nullable: true),
                    CNPJ = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    GuidCompany = table.Column<Guid>(type: "TEXT", nullable: true),
                    GuidProduct = table.Column<Guid>(type: "TEXT", nullable: true),
                    GuidClient = table.Column<Guid>(type: "TEXT", nullable: true),
                    OrderNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Sale_GuidClient = table.Column<Guid>(type: "TEXT", nullable: true),
                    GuidEmployee = table.Column<Guid>(type: "TEXT", nullable: true),
                    Sale_OrderNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    Sale_Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Method = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Sale_Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    StockMovement_GuidProduct = table.Column<Guid>(type: "TEXT", nullable: true),
                    TypeMovement = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    CurrentPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    StockProduct_GuidCompany = table.Column<Guid>(type: "TEXT", nullable: true),
                    StockProduct_Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    StockProduct_Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: true),
                    StockProduct_Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Suppliers_Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CEP = table.Column<string>(type: "TEXT", maxLength: 9, nullable: true),
                    Suppliers_CNPJ = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CPF = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    GuidCompany = table.Column<Guid>(type: "TEXT", nullable: true),
                    CEP = table.Column<string>(type: "TEXT", maxLength: 9, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                    DataNascimento = table.Column<DateOnly>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_CNPJ",
                table: "BaseEntity",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_CPF",
                table: "Person",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_Email",
                table: "Person",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseEntity");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
