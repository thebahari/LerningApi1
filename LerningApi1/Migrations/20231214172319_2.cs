using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LerningApi1.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "this is Shiraz city", "Shiraz" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "this is Tehran city", "Tehran" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "this is mashhad city", "MAshhad" });

            migrationBuilder.InsertData(
                table: "PlaceOfCity",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 1, 1, "this is Garden", "eram" });

            migrationBuilder.InsertData(
                table: "PlaceOfCity",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 2, 1, "this is mansion", "emarat shapoori" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlaceOfCity",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlaceOfCity",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
