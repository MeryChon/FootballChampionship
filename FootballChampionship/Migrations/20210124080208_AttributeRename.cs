using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballChampionship.Migrations
{
    public partial class AttributeRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeamName",
                table: "Team",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Team_TeamName",
                table: "Team",
                newName: "IX_Team_Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Team",
                newName: "TeamName");

            migrationBuilder.RenameIndex(
                name: "IX_Team_Name",
                table: "Team",
                newName: "IX_Team_TeamName");
        }
    }
}
