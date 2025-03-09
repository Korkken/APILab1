using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APILab1.Migrations
{
    /// <inheritdoc />
    public partial class updatedTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cVs_personInfos_PersonId_FK",
                table: "cVs");

            migrationBuilder.DropForeignKey(
                name: "FK_educations_cVs_CVId",
                table: "educations");

            migrationBuilder.DropForeignKey(
                name: "FK_educations_personInfos_PersonId_FK",
                table: "educations");

            migrationBuilder.DropForeignKey(
                name: "FK_workExperience_cVs_CVId",
                table: "workExperience");

            migrationBuilder.DropForeignKey(
                name: "FK_workExperience_personInfos_PersonId_FK",
                table: "workExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_personInfos",
                table: "personInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_educations",
                table: "educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cVs",
                table: "cVs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workExperience",
                table: "workExperience");

            migrationBuilder.RenameTable(
                name: "personInfos",
                newName: "PersonInfos");

            migrationBuilder.RenameTable(
                name: "educations",
                newName: "Educations");

            migrationBuilder.RenameTable(
                name: "cVs",
                newName: "CVs");

            migrationBuilder.RenameTable(
                name: "workExperience",
                newName: "WorkExperiences");

            migrationBuilder.RenameIndex(
                name: "IX_educations_PersonId_FK",
                table: "Educations",
                newName: "IX_Educations_PersonId_FK");

            migrationBuilder.RenameIndex(
                name: "IX_educations_CVId",
                table: "Educations",
                newName: "IX_Educations_CVId");

            migrationBuilder.RenameIndex(
                name: "IX_cVs_PersonId_FK",
                table: "CVs",
                newName: "IX_CVs_PersonId_FK");

            migrationBuilder.RenameIndex(
                name: "IX_workExperience_PersonId_FK",
                table: "WorkExperiences",
                newName: "IX_WorkExperiences_PersonId_FK");

            migrationBuilder.RenameIndex(
                name: "IX_workExperience_CVId",
                table: "WorkExperiences",
                newName: "IX_WorkExperiences_CVId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInfos",
                table: "PersonInfos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CVs",
                table: "CVs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkExperiences",
                table: "WorkExperiences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_PersonInfos_PersonId_FK",
                table: "CVs",
                column: "PersonId_FK",
                principalTable: "PersonInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_CVs_CVId",
                table: "Educations",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_PersonInfos_PersonId_FK",
                table: "Educations",
                column: "PersonId_FK",
                principalTable: "PersonInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_CVs_CVId",
                table: "WorkExperiences",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_PersonInfos_PersonId_FK",
                table: "WorkExperiences",
                column: "PersonId_FK",
                principalTable: "PersonInfos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_PersonInfos_PersonId_FK",
                table: "CVs");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_CVs_CVId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_PersonInfos_PersonId_FK",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_CVs_CVId",
                table: "WorkExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_PersonInfos_PersonId_FK",
                table: "WorkExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInfos",
                table: "PersonInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CVs",
                table: "CVs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkExperiences",
                table: "WorkExperiences");

            migrationBuilder.RenameTable(
                name: "PersonInfos",
                newName: "personInfos");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "educations");

            migrationBuilder.RenameTable(
                name: "CVs",
                newName: "cVs");

            migrationBuilder.RenameTable(
                name: "WorkExperiences",
                newName: "workExperience");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_PersonId_FK",
                table: "educations",
                newName: "IX_educations_PersonId_FK");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_CVId",
                table: "educations",
                newName: "IX_educations_CVId");

            migrationBuilder.RenameIndex(
                name: "IX_CVs_PersonId_FK",
                table: "cVs",
                newName: "IX_cVs_PersonId_FK");

            migrationBuilder.RenameIndex(
                name: "IX_WorkExperiences_PersonId_FK",
                table: "workExperience",
                newName: "IX_workExperience_PersonId_FK");

            migrationBuilder.RenameIndex(
                name: "IX_WorkExperiences_CVId",
                table: "workExperience",
                newName: "IX_workExperience_CVId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_personInfos",
                table: "personInfos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_educations",
                table: "educations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cVs",
                table: "cVs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workExperience",
                table: "workExperience",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cVs_personInfos_PersonId_FK",
                table: "cVs",
                column: "PersonId_FK",
                principalTable: "personInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_educations_cVs_CVId",
                table: "educations",
                column: "CVId",
                principalTable: "cVs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_educations_personInfos_PersonId_FK",
                table: "educations",
                column: "PersonId_FK",
                principalTable: "personInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_workExperience_cVs_CVId",
                table: "workExperience",
                column: "CVId",
                principalTable: "cVs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_workExperience_personInfos_PersonId_FK",
                table: "workExperience",
                column: "PersonId_FK",
                principalTable: "personInfos",
                principalColumn: "Id");
        }
    }
}
