using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APILab1.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPropertyNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_educations_personInfos_PersonId_FK",
                table: "educations");

            migrationBuilder.DropForeignKey(
                name: "FK_workExperience_personInfos_PersonId_FK",
                table: "workExperience");

            migrationBuilder.RenameColumn(
                name: "StartÅr",
                table: "workExperience",
                newName: "StartYear");

            migrationBuilder.RenameColumn(
                name: "SlutÅr",
                table: "workExperience",
                newName: "EndYear");

            migrationBuilder.RenameColumn(
                name: "Jobbtitel",
                table: "workExperience",
                newName: "WorkDescription");

            migrationBuilder.RenameColumn(
                name: "Företag",
                table: "workExperience",
                newName: "JobTitle");

            migrationBuilder.RenameColumn(
                name: "Beskrivning",
                table: "workExperience",
                newName: "Company");

            migrationBuilder.RenameColumn(
                name: "Namn",
                table: "personInfos",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Kontaktuppgifter",
                table: "personInfos",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Beskrivning",
                table: "personInfos",
                newName: "ContactDetails");

            migrationBuilder.RenameColumn(
                name: "StartDatum",
                table: "educations",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "SlutDatum",
                table: "educations",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "Skola",
                table: "educations",
                newName: "School");

            migrationBuilder.RenameColumn(
                name: "Examen",
                table: "educations",
                newName: "Degree");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId_FK",
                table: "workExperience",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId_FK",
                table: "educations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_educations_personInfos_PersonId_FK",
                table: "educations",
                column: "PersonId_FK",
                principalTable: "personInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_workExperience_personInfos_PersonId_FK",
                table: "workExperience",
                column: "PersonId_FK",
                principalTable: "personInfos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_educations_personInfos_PersonId_FK",
                table: "educations");

            migrationBuilder.DropForeignKey(
                name: "FK_workExperience_personInfos_PersonId_FK",
                table: "workExperience");

            migrationBuilder.RenameColumn(
                name: "WorkDescription",
                table: "workExperience",
                newName: "Jobbtitel");

            migrationBuilder.RenameColumn(
                name: "StartYear",
                table: "workExperience",
                newName: "StartÅr");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "workExperience",
                newName: "Företag");

            migrationBuilder.RenameColumn(
                name: "EndYear",
                table: "workExperience",
                newName: "SlutÅr");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "workExperience",
                newName: "Beskrivning");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "personInfos",
                newName: "Namn");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "personInfos",
                newName: "Kontaktuppgifter");

            migrationBuilder.RenameColumn(
                name: "ContactDetails",
                table: "personInfos",
                newName: "Beskrivning");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "educations",
                newName: "StartDatum");

            migrationBuilder.RenameColumn(
                name: "School",
                table: "educations",
                newName: "Skola");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "educations",
                newName: "SlutDatum");

            migrationBuilder.RenameColumn(
                name: "Degree",
                table: "educations",
                newName: "Examen");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId_FK",
                table: "workExperience",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId_FK",
                table: "educations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
