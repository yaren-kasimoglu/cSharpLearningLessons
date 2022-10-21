using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlakDukkani_MaratonEFCore.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Artist",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "AdminName", "Password" },
                values: new object[] { 1, "Yaren", "123" });

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
                columns: new[] { "CikisTarihi", "DevamDurumu" },
                values: new object[] { new DateTime(2022, 10, 16, 18, 54, 23, 439, DateTimeKind.Local).AddTicks(6953), false });

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 3,
                columns: new[] { "CikisTarihi", "DevamDurumu" },
                values: new object[] { new DateTime(2022, 10, 16, 18, 54, 23, 439, DateTimeKind.Local).AddTicks(6954), false });

            migrationBuilder.UpdateData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 2,
                column: "AlbumId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "AlbumId", "ArtistName" },
                values: new object[,]
                {
                    { 4, 4, "Various Artists" },
                    { 5, null, "Fazıl Say" }
                });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "AlbumId", "AlbumAdi", "ArtistId", "CikisTarihi", "DevamDurumu", "Fiyati", "IndirimOrani" },
                values: new object[] { 4, "Various Artists The Very Best of Jazz Love Songs Plak", 4, new DateTime(2022, 10, 16, 18, 54, 23, 439, DateTimeKind.Local).AddTicks(6955), false, 175.20m, 0m });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "AlbumId", "AlbumAdi", "ArtistId", "CikisTarihi", "DevamDurumu", "Fiyati", "IndirimOrani" },
                values: new object[] { 5, "Şu Dünyanın Sırrı", 5, new DateTime(2022, 10, 16, 18, 54, 23, 439, DateTimeKind.Local).AddTicks(6956), true, 22.50m, 0m });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "AlbumId", "AlbumAdi", "ArtistId", "CikisTarihi", "DevamDurumu", "Fiyati", "IndirimOrani" },
                values: new object[] { 6, "Akılla Bir Konuşmam Oldu", 5, new DateTime(2022, 10, 16, 18, 54, 23, 439, DateTimeKind.Local).AddTicks(6957), true, 14.90m, 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Artist",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                columns: new[] { "CikisTarihi", "DevamDurumu" },
                values: new object[] { new DateTime(2022, 10, 16, 18, 31, 14, 5, DateTimeKind.Local).AddTicks(1757), true });

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 3,
                columns: new[] { "CikisTarihi", "DevamDurumu" },
                values: new object[] { new DateTime(2022, 10, 16, 18, 31, 14, 5, DateTimeKind.Local).AddTicks(1758), true });

            migrationBuilder.UpdateData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 2,
                column: "AlbumId",
                value: 1);
        }
    }
}
