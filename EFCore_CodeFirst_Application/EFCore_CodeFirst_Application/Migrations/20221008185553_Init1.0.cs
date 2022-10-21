using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_CodeFirst_Application.Migrations
{
    public partial class Init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "CityId", "CountryName" },
                values: new object[] { 1, 0, "Türkiye" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "CityId", "CountryName" },
                values: new object[] { 2, 0, "Rusya" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "CityId", "CountryName" },
                values: new object[] { 3, 0, "ABD" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "CityName", "CountryId" },
                values: new object[,]
                {
                    { 1, "Adana", 1 },
                    { 2, "Adıyaman", 1 },
                    { 3, "Afyon", 1 },
                    { 4, "Ağrı", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 1);
        }
    }
}
