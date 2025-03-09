using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APILab1.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kontaktuppgifter = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cVs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cVs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cVs_personInfos_PersonId",
                        column: x => x.PersonId,
                        principalTable: "personInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Examen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId_FK = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CVId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_educations_cVs_CVId",
                        column: x => x.CVId,
                        principalTable: "cVs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_educations_personInfos_PersonId",
                        column: x => x.PersonId,
                        principalTable: "personInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workExperience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jobbtitel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Företag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartÅr = table.Column<int>(type: "int", nullable: false),
                    SlutÅr = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CVId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workExperience_cVs_CVId",
                        column: x => x.CVId,
                        principalTable: "cVs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_workExperience_personInfos_PersonId",
                        column: x => x.PersonId,
                        principalTable: "personInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cVs_PersonId",
                table: "cVs",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_educations_CVId",
                table: "educations",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_educations_PersonId",
                table: "educations",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_workExperience_CVId",
                table: "workExperience",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_workExperience_PersonId",
                table: "workExperience",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "educations");

            migrationBuilder.DropTable(
                name: "workExperience");

            migrationBuilder.DropTable(
                name: "cVs");

            migrationBuilder.DropTable(
                name: "personInfos");
        }
    }
}
