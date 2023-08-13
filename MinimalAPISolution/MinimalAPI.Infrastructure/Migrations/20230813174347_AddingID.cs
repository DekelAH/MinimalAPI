using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("0358c277-0720-483a-8ba8-261620be5f3c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("767ad7f1-cb29-45bc-8d6d-5b92a7542b4f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("7f335988-2af0-4718-9198-daadbfd45b54"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductName", "ProductPrice", "ProductQuantity" },
                values: new object[,]
                {
                    { new Guid("02eebf2b-ab51-4ea5-b2f7-0c2d288a384b"), "Table Cloth", 62.0, 1 },
                    { new Guid("3e679362-8bb1-42f7-95d2-0da5a620265f"), "Chair", 82.900000000000006, 6 },
                    { new Guid("a8a46194-525f-448d-b274-5a0551c84419"), "Dining Table", 322.94, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("02eebf2b-ab51-4ea5-b2f7-0c2d288a384b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3e679362-8bb1-42f7-95d2-0da5a620265f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a8a46194-525f-448d-b274-5a0551c84419"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductName", "ProductPrice", "ProductQuantity" },
                values: new object[,]
                {
                    { new Guid("0358c277-0720-483a-8ba8-261620be5f3c"), "Dining Table", 322.94, 1 },
                    { new Guid("767ad7f1-cb29-45bc-8d6d-5b92a7542b4f"), "Table Cloth", 62.0, 1 },
                    { new Guid("7f335988-2af0-4718-9198-daadbfd45b54"), "Chair", 82.900000000000006, 6 }
                });
        }
    }
}
