using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoungWolves.Migrations
{
    public partial class AddingClubId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClubIdId",
                table: "Warriors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Warriors_ClubIdId",
                table: "Warriors",
                column: "ClubIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warriors_Clubs_ClubIdId",
                table: "Warriors",
                column: "ClubIdId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warriors_Clubs_ClubIdId",
                table: "Warriors");

            migrationBuilder.DropIndex(
                name: "IX_Warriors_ClubIdId",
                table: "Warriors");

            migrationBuilder.DropColumn(
                name: "ClubIdId",
                table: "Warriors");
        }
    }
}
