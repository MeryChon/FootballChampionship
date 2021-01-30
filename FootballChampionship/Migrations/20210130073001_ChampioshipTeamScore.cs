using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballChampionship.Migrations
{
    public partial class ChampioshipTeamScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamChampionshipScore",
                columns: table => new
                {
                    TeamChampionshipScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionshipId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamChampionshipScore", x => x.TeamChampionshipScoreId);
                    table.ForeignKey(
                        name: "FK_TeamChampionshipScore_Championship_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalTable: "Championship",
                        principalColumn: "ChampionshipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamChampionshipScore_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamChampionshipScore_ChampionshipId",
                table: "TeamChampionshipScore",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamChampionshipScore_TeamId",
                table: "TeamChampionshipScore",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamChampionshipScore");
        }
    }
}
