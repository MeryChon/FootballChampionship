using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballChampionship.Migrations
{
    public partial class AddNonCompositeMatchId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Match",
                table: "Match");

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "Match",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Match",
                table: "Match",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_FirstTeamId",
                table: "Match",
                column: "FirstTeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Match",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_FirstTeamId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Match");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Match",
                table: "Match",
                columns: new[] { "FirstTeamId", "SecondTeamId" });
        }
    }
}
