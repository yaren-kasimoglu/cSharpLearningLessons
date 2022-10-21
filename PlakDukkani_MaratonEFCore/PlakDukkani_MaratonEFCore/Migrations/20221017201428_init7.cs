using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlakDukkani_MaratonEFCore.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "AdminName",
                table: "Admin",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 1,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 17, 23, 14, 28, 619, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 2,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 17, 23, 14, 28, 619, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 3,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 17, 23, 14, 28, 619, DateTimeKind.Local).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 4,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 17, 23, 14, 28, 619, DateTimeKind.Local).AddTicks(7979));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 5,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 17, 23, 14, 28, 619, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 6,
                column: "CikisTarihi",
                value: new DateTime(2022, 10, 17, 23, 14, 28, 619, DateTimeKind.Local).AddTicks(7981));

            migrationBuilder.CreateIndex(
                name: "IX_Admin_AdminName",
                table: "Admin",
                column: "AdminName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Admin_AdminName",
                table: "Admin");

            migrationBuilder.AlterColumn<string>(
                name: "AdminName",
                table: "Admin",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "AdminName", "Password" },
                values: new object[] { 1, "Yaren", "123" });

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
    }
}
