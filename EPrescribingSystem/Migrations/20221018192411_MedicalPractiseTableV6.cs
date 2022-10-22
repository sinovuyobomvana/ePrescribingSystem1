using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class MedicalPractiseTableV6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "symptoms",
                table: "ConditionDiagnosis",
                newName: "ICD_10_CODE");

            migrationBuilder.RenameColumn(
                name: "ConditionName",
                table: "ConditionDiagnosis",
                newName: "Diagnosis");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Pharmacy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "MedicalPractice",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Province",
                table: "Pharmacy");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "MedicalPractice");

            migrationBuilder.RenameColumn(
                name: "ICD_10_CODE",
                table: "ConditionDiagnosis",
                newName: "symptoms");

            migrationBuilder.RenameColumn(
                name: "Diagnosis",
                table: "ConditionDiagnosis",
                newName: "ConditionName");
        }
    }
}
