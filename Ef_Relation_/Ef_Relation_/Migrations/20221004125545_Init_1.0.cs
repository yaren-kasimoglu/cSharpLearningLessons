using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ef_Relation_.Migrations
{
    public partial class Init_10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentAddress");
        }
    }
}
