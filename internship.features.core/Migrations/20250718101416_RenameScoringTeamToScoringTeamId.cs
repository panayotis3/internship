using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace internship.features.core.Migrations
{
    /// <inheritdoc />
    public partial class RenameScoringTeamToScoringTeamId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScoringTeam",
                table: "Goals",
                newName: "ScoringTeamId");

            migrationBuilder.AddColumn<int>(
                name: "Minute",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Minute",
                table: "Goals");

            migrationBuilder.RenameColumn(
                name: "ScoringTeamId",
                table: "Goals",
                newName: "ScoringTeam");
        }
    }
}
