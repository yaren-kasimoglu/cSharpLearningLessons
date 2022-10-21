using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlakDukkani_MaratonEFCore.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 1,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 18, 31, 14, 5, DateTimeKind.Local).AddTicks(1743));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 2,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 18, 31, 14, 5, DateTimeKind.Local).AddTicks(1757));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 3,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 18, 31, 14, 5, DateTimeKind.Local).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 1,
                column: "AlbumId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 2,
                column: "AlbumId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 3,
                column: "AlbumId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 1,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 18, 30, 4, 460, DateTimeKind.Local).AddTicks(6953));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 2,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 18, 30, 4, 460, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 3,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 18, 30, 4, 460, DateTimeKind.Local).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 1,
                column: "AlbumId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 2,
                column: "AlbumId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 3,
                column: "AlbumId",
                value: 0);
        }
    }
}
