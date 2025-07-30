using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace internship.features.core.Migrations
{
    /// <inheritdoc />
    public partial class AddJunctionTournament : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JunctionTournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JunctionTournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JunctionTournaments_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JunctionTournaments_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JunctionTournaments_TeamId",
                table: "JunctionTournaments",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_JunctionTournaments_TournamentId",
                table: "JunctionTournaments",
                column: "TournamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JunctionTournaments");
        }
    }
}
