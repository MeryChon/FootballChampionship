using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballChampionship.Migrations
{
    public partial class CreateChampionshipsSpecifyFks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchResult_Team_WinningTeamId",
                table: "MatchResult");

            migrationBuilder.AddColumn<int>(
                name: "ChampionshipId",
                table: "Match",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Championship",
                columns: table => new
                {
                    ChampionshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desciprtion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship", x => x.ChampionshipId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_ChampionshipId",
                table: "Match",
                column: "ChampionshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Championship_ChampionshipId",
                table: "Match",
                column: "ChampionshipId",
                principalTable: "Championship",
                principalColumn: "ChampionshipId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchResult_Team_WinningTeamId",
                table: "MatchResult",
                column: "WinningTeamId",
                principalTable: "Team",
                principalColumn: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Championship_ChampionshipId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchResult_Team_WinningTeamId",
                table: "MatchResult");

            migrationBuilder.DropTable(
                name: "Championship");

            migrationBuilder.DropIndex(
                name: "IX_Match_ChampionshipId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "ChampionshipId",
                table: "Match");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchResult_Team_WinningTeamId",
                table: "MatchResult",
                column: "WinningTeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
