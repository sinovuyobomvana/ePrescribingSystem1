using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class updatedModelsV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "practiceNum",
                table: "MedicalPractice",
                newName: "PracticeID");

            migrationBuilder.AddColumn<string>(
                name: "PracticeNumber",
                table: "MedicalPractice",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PracticeNumber",
                table: "MedicalPractice");

            migrationBuilder.RenameColumn(
                name: "PracticeID",
                table: "MedicalPractice",
                newName: "practiceNum");
        }
    }
}
