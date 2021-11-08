using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "InvoiceId", "IsGrocery", "Name", "Price" },
                values: new object[] { 1, null, false, "T-Shirts", 2450m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "InvoiceId", "IsGrocery", "Name", "Price" },
                values: new object[] { 2, null, true, "Bread", 520m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "InvoiceId", "IsGrocery", "Name", "Price" },
                values: new object[] { 3, null, true, "Meat", 1470m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "InvoiceId", "IsGrocery", "Name", "Price" },
                values: new object[] { 4, null, false, "Jeans", 2680m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "InvoiceId", "IsGrocery", "Name", "Price" },
                values: new object[] { 5, null, true, "Pasta", 1230m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "InvoiceId", "IsGrocery", "Name", "Price" },
                values: new object[] { 6, null, true, "Watermelon", 700m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "InvoiceId", "IsGrocery", "Name", "Price" },
                values: new object[] { 7, null, false, "Singlet", 1130m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "InvoiceId", "IsGrocery", "Name", "Price" },
                values: new object[] { 8, null, true, "Apple", 300m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "InvoiceId", "IsGrocery", "Name", "Price" },
                values: new object[] { 9, null, false, "Boxers", 575m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
