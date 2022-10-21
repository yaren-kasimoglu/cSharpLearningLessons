using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlakDukkani_MaratonEFCore.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 1,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 19, 4, 22, 143, DateTimeKind.Local).AddTicks(5988));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 2,
                columns: new[] { "CikisTarihi", "IndirimOrani" },
                values: new object[] { new DateTime(2022, 10, 16, 19, 4, 22, 143, DateTimeKind.Local).AddTicks(6003), 0.5m });

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 3,
                columns: new[] { "CikisTarihi", "IndirimOrani" },
                values: new object[] { new DateTime(2022, 10, 16, 19, 4, 22, 143, DateTimeKind.Local).AddTicks(6005), 0.75m });

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 4,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 19, 4, 22, 143, DateTimeKind.Local).AddTicks(6006));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 5,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 19, 4, 22, 143, DateTimeKind.Local).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 6,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 19, 4, 22, 143, DateTimeKind.Local).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 5,
                column: "AlbumId",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 1,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 18, 54, 23, 439, DateTimeKind.Local).AddTicks(6938));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 2,
                columns: new[] { "CikisTarihi", "IndirimOrani" },
                values: new object[] { new DateTime(2022, 10, 16, 18, 54, 23, 439, DateTimeKind.Local).AddTicks(6953), 0m });

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 3,
                columns: new[] { "CikisTarihi", "IndirimOrani" },
                values: new object[] { new DateTime(2022, 10, 16, 18, 54, 23, 439, DateTimeKind.Local).AddTicks(6954), 0m });

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 4,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 18, 54, 23, 439, DateTimeKind.Local).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 5,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 18, 54, 23, 439, DateTimeKind.Local).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 6,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 18, 54, 23, 439, DateTimeKind.Local).AddTicks(6957));

            migrationBuilder.UpdateData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 5,
                column: "AlbumId",
                value: null);
        }
    }
}
