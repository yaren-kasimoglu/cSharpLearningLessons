using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlakDukkani_MaratonEFCore.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album");

            migrationBuilder.AlterColumn<string>(
                name: "ArtistName",
                table: "Artist",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Artist",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AlbumAdi",
                table: "Album",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Admin",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AdminName",
                table: "Admin",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "AlbumId", "ArtistName" },
                values: new object[] { 1, 0, "Nina Simone" });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "AlbumId", "ArtistName" },
                values: new object[] { 2, 0, "Edith Piaf" });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "AlbumId", "ArtistName" },
                values: new object[] { 3, 0, "Cyndi Lauper" });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "AlbumId", "AlbumAdi", "ArtistId", "CikisTarihi", "DevamDurumu", "Fiyati", "IndirimOrani" },
                values: new object[] { 1, "The Nina Simone Collection Plak", 1, new DateTime(2022, 10, 16, 18, 30, 4, 460, DateTimeKind.Local).AddTicks(6953), true, 223.20m, 0m });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "AlbumId", "AlbumAdi", "ArtistId", "CikisTarihi", "DevamDurumu", "Fiyati", "IndirimOrani" },
                values: new object[] { 2, "Edith Piaf La Vie En Rose Plak", 2, new DateTime(2022, 10, 16, 18, 30, 4, 460, DateTimeKind.Local).AddTicks(6968), true, 172.00m, 0m });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "AlbumId", "AlbumAdi", "ArtistId", "CikisTarihi", "DevamDurumu", "Fiyati", "IndirimOrani" },
                values: new object[] { 3, "Cyndi Lauper She'S So Unusual Plak", 3, new DateTime(2022, 10, 16, 18, 30, 4, 460, DateTimeKind.Local).AddTicks(6970), true, 369.60m, 0m });

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album");

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "ArtistName",
                table: "Artist",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Artist",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AlbumAdi",
                table: "Album",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "AdminName",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
