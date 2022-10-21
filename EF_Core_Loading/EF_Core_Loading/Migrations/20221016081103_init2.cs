using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_Loading.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CustomerName", "Email", "ModifiedDate", "Phone", "RecordDate" },
                values: new object[] { 1, "Yaren KAsımoğlu", "yk@gmail.com", new DateTime(2022, 10, 16, 11, 11, 3, 16, DateTimeKind.Local).AddTicks(9282), "5436097030", new DateTime(2022, 10, 16, 11, 11, 3, 16, DateTimeKind.Local).AddTicks(9296) });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CustomerName", "Email", "ModifiedDate", "Phone", "RecordDate" },
                values: new object[] { 2, "Erdi Şen", "eş@gmail.com", new DateTime(2022, 10, 16, 11, 11, 3, 16, DateTimeKind.Local).AddTicks(9297), "5436055030", new DateTime(2022, 10, 16, 11, 11, 3, 16, DateTimeKind.Local).AddTicks(9298) });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CustomerName", "Email", "ModifiedDate", "Phone", "RecordDate" },
                values: new object[] { 3, "Yunus Emre Teke", "yt@gmail.com", new DateTime(2022, 10, 16, 11, 11, 3, 16, DateTimeKind.Local).AddTicks(9299), "5436033030", new DateTime(2022, 10, 16, 11, 11, 3, 16, DateTimeKind.Local).AddTicks(9299) });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "CustomerId", "ModifiedDate", "OrderDate", "OrderNumber", "RecordDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(497), new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(499), "50000001", new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(499) },
                    { 2, 1, new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(500), new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(501), "50000002", new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(502) },
                    { 3, 1, new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(502), new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(503), "50000003", new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(503) },
                    { 4, 2, new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(504), new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(504), "50000004", new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(505) },
                    { 5, 2, new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(505), new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(506), "50000005", new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(506) },
                    { 6, 2, new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(507), new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(508), "50000006", new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(508) },
                    { 7, 3, new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(509), new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(509), "50000007", new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(510) },
                    { 8, 3, new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(510), new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(511), "50000008", new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(511) },
                    { 9, 3, new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(512), new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(512), "50000009", new DateTime(2022, 10, 16, 11, 11, 3, 17, DateTimeKind.Local).AddTicks(513) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
