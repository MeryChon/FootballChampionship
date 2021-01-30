using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballChampionship.Migrations
{
    public partial class MoveResultsToMatchEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_MatchResult_MatchResultId",
                table: "Match");

            migrationBuilder.DropTable(
                name: "MatchResult");

            migrationBuilder.DropIndex(
                name: "IX_Match_MatchResultId",
                table: "Match");

            migrationBuilder.RenameColumn(
                name: "MatchResultId",
                table: "Match",
                newName: "WinningTeamId");

            migrationBuilder.AddColumn<int>(
                name: "ResultType",
                table: "Match",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Match_WinningTeamId",
                table: "Match",
                column: "WinningTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_WinningTeamId",
                table: "Match",
                column: "WinningTeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_WinningTeamId",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_WinningTeamId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "ResultType",
                table: "Match");

            migrationBuilder.RenameColumn(
                name: "WinningTeamId",
                table: "Match",
                newName: "MatchResultId");

            migrationBuilder.CreateTable(
                name: "MatchResult",
                columns: table => new
                {
                    MatchResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    ResultType = table.Column<int>(type: "int", nullable: false),
                    WinningTeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchResult", x => x.MatchResultId);
                    table.ForeignKey(
                        name: "FK_MatchResult_Team_WinningTeamId",
                        column: x => x.WinningTeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatchResultId",
                table: "Match",
                column: "MatchResultId",
                unique: true,
                filter: "[MatchResultId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResult_WinningTeamId",
                table: "MatchResult",
                column: "WinningTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_MatchResult_MatchResultId",
                table: "Match",
                column: "MatchResultId",
                principalTable: "MatchResult",
                principalColumn: "MatchResultId");
        }
    }
}
