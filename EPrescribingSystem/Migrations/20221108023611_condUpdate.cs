using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class condUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicationID",
                table: "ConditionDiagnosis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConditionDiagnosis_MedicationID",
                table: "ConditionDiagnosis",
                column: "MedicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionDiagnosis_Medication_MedicationID",
                table: "ConditionDiagnosis",
                column: "MedicationID",
                principalTable: "Medication",
                principalColumn: "MedicationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConditionDiagnosis_Medication_MedicationID",
                table: "ConditionDiagnosis");

            migrationBuilder.DropIndex(
                name: "IX_ConditionDiagnosis_MedicationID",
                table: "ConditionDiagnosis");

            migrationBuilder.DropColumn(
                name: "MedicationID",
                table: "ConditionDiagnosis");
        }
    }
}
