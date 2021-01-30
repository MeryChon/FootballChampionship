using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballChampionship.Migrations
{
    public partial class MatchToMatchResultRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_MatchResult_MatchResultId",
                table: "Match");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_MatchResult_MatchResultId",
                table: "Match",
                column: "MatchResultId",
                principalTable: "MatchResult",
                principalColumn: "MatchResultId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_MatchResult_MatchResultId",
                table: "Match");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_MatchResult_MatchResultId",
                table: "Match",
                column: "MatchResultId",
                principalTable: "MatchResult",
                principalColumn: "MatchResultId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
