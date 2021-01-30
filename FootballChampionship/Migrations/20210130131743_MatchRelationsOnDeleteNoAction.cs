using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballChampionship.Migrations
{
    public partial class MatchRelationsOnDeleteNoAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_FirstTeamId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_WinningTeamId",
                table: "Match");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_FirstTeamId",
                table: "Match",
                column: "FirstTeamId",
                principalTable: "Team",
                principalColumn: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_WinningTeamId",
                table: "Match",
                column: "WinningTeamId",
                principalTable: "Team",
                principalColumn: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_FirstTeamId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_WinningTeamId",
                table: "Match");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_FirstTeamId",
                table: "Match",
                column: "FirstTeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_WinningTeamId",
                table: "Match",
                column: "WinningTeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
