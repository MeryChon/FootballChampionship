using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballChampionship.Migrations
{
    public partial class TeamChampionshipScoreCompositePk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamChampionshipScore",
                table: "TeamChampionshipScore");

            migrationBuilder.DropIndex(
                name: "IX_TeamChampionshipScore_ChampionshipId",
                table: "TeamChampionshipScore");

            migrationBuilder.DropColumn(
                name: "TeamChampionshipScoreId",
                table: "TeamChampionshipScore");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamChampionshipScore",
                table: "TeamChampionshipScore",
                columns: new[] { "ChampionshipId", "TeamId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamChampionshipScore",
                table: "TeamChampionshipScore");

            migrationBuilder.AddColumn<int>(
                name: "TeamChampionshipScoreId",
                table: "TeamChampionshipScore",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamChampionshipScore",
                table: "TeamChampionshipScore",
                column: "TeamChampionshipScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamChampionshipScore_ChampionshipId",
                table: "TeamChampionshipScore",
                column: "ChampionshipId");
        }
    }
}
