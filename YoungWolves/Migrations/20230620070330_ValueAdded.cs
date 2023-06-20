using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoungWolves.Migrations
{
    public partial class ValueAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Warriors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Warriors");
        }
    }
}
