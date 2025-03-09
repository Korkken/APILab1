using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APILab1.Migrations
{
    /// <inheritdoc />
    public partial class fixeddb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cVs_personInfos_PersonId",
                table: "cVs");

            migrationBuilder.DropForeignKey(
                name: "FK_educations_personInfos_PersonId",
                table: "educations");

            migrationBuilder.DropForeignKey(
                name: "FK_workExperience_personInfos_PersonId",
                table: "workExperience");

            migrationBuilder.DropIndex(
                name: "IX_educations_PersonId",
                table: "educations");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "educations");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "workExperience",
                newName: "PersonId_FK");

            migrationBuilder.RenameIndex(
                name: "IX_workExperience_PersonId",
                table: "workExperience",
                newName: "IX_workExperience_PersonId_FK");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "cVs",
                newName: "PersonId_FK");

            migrationBuilder.RenameIndex(
                name: "IX_cVs_PersonId",
                table: "cVs",
                newName: "IX_cVs_PersonId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_educations_PersonId_FK",
                table: "educations",
                column: "PersonId_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_cVs_personInfos_PersonId_FK",
                table: "cVs",
                column: "PersonId_FK",
                principalTable: "personInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_educations_personInfos_PersonId_FK",
                table: "educations",
                column: "PersonId_FK",
                principalTable: "personInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workExperience_personInfos_PersonId_FK",
                table: "workExperience",
                column: "PersonId_FK",
                principalTable: "personInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cVs_personInfos_PersonId_FK",
                table: "cVs");

            migrationBuilder.DropForeignKey(
                name: "FK_educations_personInfos_PersonId_FK",
                table: "educations");

            migrationBuilder.DropForeignKey(
                name: "FK_workExperience_personInfos_PersonId_FK",
                table: "workExperience");

            migrationBuilder.DropIndex(
                name: "IX_educations_PersonId_FK",
                table: "educations");

            migrationBuilder.RenameColumn(
                name: "PersonId_FK",
                table: "workExperience",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_workExperience_PersonId_FK",
                table: "workExperience",
                newName: "IX_workExperience_PersonId");

            migrationBuilder.RenameColumn(
                name: "PersonId_FK",
                table: "cVs",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_cVs_PersonId_FK",
                table: "cVs",
                newName: "IX_cVs_PersonId");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "educations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_educations_PersonId",
                table: "educations",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_cVs_personInfos_PersonId",
                table: "cVs",
                column: "PersonId",
                principalTable: "personInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_educations_personInfos_PersonId",
                table: "educations",
                column: "PersonId",
                principalTable: "personInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workExperience_personInfos_PersonId",
                table: "workExperience",
                column: "PersonId",
                principalTable: "personInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
