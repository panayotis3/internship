using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace internship.features.core.Migrations
{
    /// <inheritdoc />
    public partial class AddCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamMemberId = table.Column<int>(type: "int", nullable: false),
                    FictureId = table.Column<int>(type: "int", nullable: false),
                    CardType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Minute = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Fictures_FictureId",
                        column: x => x.FictureId,
                        principalTable: "Fictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_TeamMembers_TeamMemberId",
                        column: x => x.TeamMemberId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_FictureId",
                table: "Cards",
                column: "FictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TeamMemberId",
                table: "Cards",
                column: "TeamMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
