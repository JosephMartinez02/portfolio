using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvangelionDatabase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evangelion",
                columns: table => new
                {
                    EvangelionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EVAName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Picture = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evangelion", x => x.EvangelionID);
                });

            migrationBuilder.CreateTable(
                name: "Pilot",
                columns: table => new
                {
                    PilotID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Picture = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilot", x => x.PilotID);
                });

            migrationBuilder.CreateTable(
                name: "PilotEvangelion",
                columns: table => new
                {
                    PilotID = table.Column<int>(type: "INTEGER", nullable: false),
                    EvangelionID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotEvangelion", x => new { x.EvangelionID, x.PilotID });
                    table.ForeignKey(
                        name: "FK_PilotEvangelion_Evangelion_EvangelionID",
                        column: x => x.EvangelionID,
                        principalTable: "Evangelion",
                        principalColumn: "EvangelionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PilotEvangelion_Pilot_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilot",
                        principalColumn: "PilotID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PilotEvangelion_PilotID",
                table: "PilotEvangelion",
                column: "PilotID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PilotEvangelion");

            migrationBuilder.DropTable(
                name: "Evangelion");

            migrationBuilder.DropTable(
                name: "Pilot");
        }
    }
}
