using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1c01ac57-153f-467a-b7c4-f82335692b4c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("7eefe19f-6334-46b2-acc6-80e71ad215a3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("f44ffc65-3aa7-451b-8411-167f9b87b182"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("1c01ac57-153f-467a-b7c4-f82335692b4c"), "Dining Table", 322.94, 1 },
                    { new Guid("7eefe19f-6334-46b2-acc6-80e71ad215a3"), "Table Cloth", 62.0, 1 },
                    { new Guid("f44ffc65-3aa7-451b-8411-167f9b87b182"), "Chair", 82.900000000000006, 6 }
                });
        }
    }
}
