using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace internship.features.core.Migrations
{
    /// <inheritdoc />
    public partial class RemoveGoalIdfromGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Goals_GoalId",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Goals_GoalId",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "GoalId",
                table: "Goals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalId",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Goals_GoalId",
                table: "Goals",
                column: "GoalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Goals_GoalId",
                table: "Goals",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
