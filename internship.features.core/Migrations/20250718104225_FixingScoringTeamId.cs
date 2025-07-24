using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace internship.features.core.Migrations
{
    /// <inheritdoc />
    public partial class FixingScoringTeamId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Goals_ScoringTeamId",
                table: "Goals",
                column: "ScoringTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Teams_ScoringTeamId",
                table: "Goals",
                column: "ScoringTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Teams_ScoringTeamId",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Goals_ScoringTeamId",
                table: "Goals");
        }
    }
}
