using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_webapi_erp.Data.Migrations
{
    /// <inheritdoc />
    public partial class seccondMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_CNPJ",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "GuidCompany",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "GuidClient",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "GuidCompany",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "GuidEmployee",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "GuidProduct",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Method",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "NumberEmployees",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Office",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Sale_GuidClient",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Sale_OrderNumber",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Sale_Price",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Sale_Status",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "StockMovement_GuidProduct",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "StockProduct_Description",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "StockProduct_GuidCompany",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "StockProduct_Name",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "StockProduct_Price",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Suppliers_CNPJ",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Suppliers_Name",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "TypeMovement",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "User",
                table: "BaseEntity");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "BaseEntity",
                newName: "Suppliers");

            migrationBuilder.RenameIndex(
                name: "IX_Person_Email",
                table: "User",
                newName: "IX_User_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Person_CPF",
                table: "User",
                newName: "IX_User_CPF");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "TEXT",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataNascimento",
                table: "User",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Suppliers",
                type: "TEXT",
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Suppliers",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Suppliers",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Suppliers",
                type: "TEXT",
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Suppliers",
                type: "TEXT",
                maxLength: 9,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 9,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Suppliers",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Association",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    User = table.Column<Guid>(type: "TEXT", nullable: false),
                    Company = table.Column<Guid>(type: "TEXT", nullable: false),
                    Office = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Association", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GuidCompany = table.Column<Guid>(type: "TEXT", nullable: false),
                    CEP = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CPF = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Owner = table.Column<Guid>(type: "TEXT", nullable: false),
                    NumberEmployees = table.Column<int>(type: "INTEGER", nullable: false),
                    CNPJ = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GuidCompany = table.Column<Guid>(type: "TEXT", nullable: false),
                    GuidProduct = table.Column<Guid>(type: "TEXT", nullable: false),
                    GuidClient = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GuidClient = table.Column<Guid>(type: "TEXT", nullable: false),
                    GuidEmployee = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Method = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockMovement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GuidProduct = table.Column<Guid>(type: "TEXT", nullable: false),
                    TypeMovement = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMovement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GuidCompany = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockProduct", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_CNPJ",
                table: "Company",
                column: "CNPJ",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Association");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "StockMovement");

            migrationBuilder.DropTable(
                name: "StockProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "BaseEntity");

            migrationBuilder.RenameIndex(
                name: "IX_User_Email",
                table: "Person",
                newName: "IX_Person_Email");

            migrationBuilder.RenameIndex(
                name: "IX_User_CPF",
                table: "Person",
                newName: "IX_Person_CPF");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Person",
                type: "TEXT",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataNascimento",
                table: "Person",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Person",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Person",
                type: "TEXT",
                maxLength: 9,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Person",
                type: "TEXT",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "GuidCompany",
                table: "Person",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<Guid>(
                name: "Company",
                table: "BaseEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentPrice",
                table: "BaseEntity",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "GuidClient",
                table: "BaseEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GuidCompany",
                table: "BaseEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GuidEmployee",
                table: "BaseEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GuidProduct",
                table: "BaseEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Method",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberEmployees",
                table: "BaseEntity",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Office",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "BaseEntity",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Owner",
                table: "BaseEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "BaseEntity",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BaseEntity",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Sale_GuidClient",
                table: "BaseEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sale_OrderNumber",
                table: "BaseEntity",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Sale_Price",
                table: "BaseEntity",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sale_Status",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StockMovement_GuidProduct",
                table: "BaseEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockProduct_Description",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StockProduct_GuidCompany",
                table: "BaseEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockProduct_Name",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "StockProduct_Price",
                table: "BaseEntity",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suppliers_CNPJ",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suppliers_Name",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeMovement",
                table: "BaseEntity",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User",
                table: "BaseEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_CNPJ",
                table: "BaseEntity",
                column: "CNPJ",
                unique: true);
        }
    }
}
