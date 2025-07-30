using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace internship.features.core.Migrations
{
    /// <inheritdoc />
    public partial class AddDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fictures_Teams_AwayTeamId",
                table: "Fictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Fictures_Teams_HomeTeamId",
                table: "Fictures");

            migrationBuilder.AddForeignKey(
                name: "FK_Fictures_Teams_AwayTeamId",
                table: "Fictures",
                column: "AwayTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Fictures_Teams_HomeTeamId",
                table: "Fictures",
                column: "HomeTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fictures_Teams_AwayTeamId",
                table: "Fictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Fictures_Teams_HomeTeamId",
                table: "Fictures");

            migrationBuilder.AddForeignKey(
                name: "FK_Fictures_Teams_AwayTeamId",
                table: "Fictures",
                column: "AwayTeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fictures_Teams_HomeTeamId",
                table: "Fictures",
                column: "HomeTeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
