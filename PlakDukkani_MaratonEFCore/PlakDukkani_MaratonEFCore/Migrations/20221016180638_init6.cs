using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlakDukkani_MaratonEFCore.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 1,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 21, 6, 37, 916, DateTimeKind.Local).AddTicks(7391));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 2,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 21, 6, 37, 916, DateTimeKind.Local).AddTicks(7405));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 3,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 21, 6, 37, 916, DateTimeKind.Local).AddTicks(7407));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 4,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 21, 6, 37, 916, DateTimeKind.Local).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 5,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 21, 6, 37, 916, DateTimeKind.Local).AddTicks(7409));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 6,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 21, 6, 37, 916, DateTimeKind.Local).AddTicks(7410));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 19, 4, 22, 143, DateTimeKind.Local).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 3,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 16, 19, 4, 22, 143, DateTimeKind.Local).AddTicks(6005));

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
        }
    }
}
