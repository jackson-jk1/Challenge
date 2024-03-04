using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Challenge.Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SupplierCode = table.Column<string>(type: "TEXT", nullable: false),
                    SupplierDescription = table.Column<string>(type: "TEXT", nullable: false),
                    SupplierCNPJ = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ExpiryDate", "IsActive", "ManufactureDate", "SupplierCNPJ", "SupplierCode", "SupplierDescription" },
                values: new object[] { 1, "ProductEntity 1", new DateTime(2025, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(817), true, new DateTime(2024, 3, 3, 16, 35, 40, 853, DateTimeKind.Local).AddTicks(4735), "12.345.678/0001-90", "1", "Supplier 1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ExpiryDate", "IsActive", "ManufactureDate", "SupplierCNPJ", "SupplierCode", "SupplierDescription" },
                values: new object[] { 2, "ProductEntity 2", new DateTime(2025, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4724), true, new DateTime(2024, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4717), "98.765.432/0001-09", "2", "Supplier 2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ExpiryDate", "IsActive", "ManufactureDate", "SupplierCNPJ", "SupplierCode", "SupplierDescription" },
                values: new object[] { 3, "ProductEntity 3", new DateTime(2025, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4740), true, new DateTime(2024, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4739), "12.345.678/0001-90", "3", "Supplier 3" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ExpiryDate", "IsActive", "ManufactureDate", "SupplierCNPJ", "SupplierCode", "SupplierDescription" },
                values: new object[] { 4, "ProductEntity 4", new DateTime(2025, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4744), true, new DateTime(2024, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4742), "98.765.432/0001-09", "4", "Supplier 4" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ExpiryDate", "IsActive", "ManufactureDate", "SupplierCNPJ", "SupplierCode", "SupplierDescription" },
                values: new object[] { 5, "ProductEntity 5", new DateTime(2025, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4747), true, new DateTime(2024, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4746), "12.345.678/0001-90", "5", "Supplier 5" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ExpiryDate", "IsActive", "ManufactureDate", "SupplierCNPJ", "SupplierCode", "SupplierDescription" },
                values: new object[] { 6, "ProductEntity 6", new DateTime(2025, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4751), true, new DateTime(2024, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4749), "98.765.432/0001-09", "6", "Supplier 6" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ExpiryDate", "IsActive", "ManufactureDate", "SupplierCNPJ", "SupplierCode", "SupplierDescription" },
                values: new object[] { 7, "ProductEntity 7", new DateTime(2025, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4754), true, new DateTime(2024, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4753), "12.345.678/0001-90", "7", "Supplier 7" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ExpiryDate", "IsActive", "ManufactureDate", "SupplierCNPJ", "SupplierCode", "SupplierDescription" },
                values: new object[] { 8, "ProductEntity 8", new DateTime(2025, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4757), true, new DateTime(2024, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4756), "98.765.432/0001-09", "8", "Supplier 8" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ExpiryDate", "IsActive", "ManufactureDate", "SupplierCNPJ", "SupplierCode", "SupplierDescription" },
                values: new object[] { 9, "ProductEntity 9", new DateTime(2025, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4761), true, new DateTime(2024, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4760), "12.345.678/0001-90", "9", "Supplier 9" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ExpiryDate", "IsActive", "ManufactureDate", "SupplierCNPJ", "SupplierCode", "SupplierDescription" },
                values: new object[] { 10, "ProductEntity 10", new DateTime(2025, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4764), true, new DateTime(2024, 3, 3, 16, 35, 40, 855, DateTimeKind.Local).AddTicks(4763), "98.765.432/0001-09", "10", "Supplier 10" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
