using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class disease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContraIndication_ConditionDiagnosis_ConditionID",
                table: "ContraIndication");

            migrationBuilder.DropColumn(
                name: "Effect",
                table: "MedicationInteraction");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MedicationInteraction");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "MedicationInteraction");

            migrationBuilder.RenameColumn(
                name: "ConditionID",
                table: "ContraIndication",
                newName: "DiseaseID");

            migrationBuilder.RenameIndex(
                name: "IX_ContraIndication_ConditionID",
                table: "ContraIndication",
                newName: "IX_ContraIndication_DiseaseID");

            migrationBuilder.AddColumn<int>(
                name: "ActiveIngredientID",
                table: "MedicationInteraction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActiveIngredientID2",
                table: "MedicationInteraction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Disease",
                columns: table => new
                {
                    DiseaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ICD_10_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease", x => x.DiseaseID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicationInteraction_ActiveIngredientID",
                table: "MedicationInteraction",
                column: "ActiveIngredientID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContraIndication_Disease_DiseaseID",
                table: "ContraIndication",
                column: "DiseaseID",
                principalTable: "Disease",
                principalColumn: "DiseaseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationInteraction_ActiveIngredient_ActiveIngredientID",
                table: "MedicationInteraction",
                column: "ActiveIngredientID",
                principalTable: "ActiveIngredient",
                principalColumn: "ActiveIngredientID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContraIndication_Disease_DiseaseID",
                table: "ContraIndication");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicationInteraction_ActiveIngredient_ActiveIngredientID",
                table: "MedicationInteraction");

            migrationBuilder.DropTable(
                name: "Disease");

            migrationBuilder.DropIndex(
                name: "IX_MedicationInteraction_ActiveIngredientID",
                table: "MedicationInteraction");

            migrationBuilder.DropColumn(
                name: "ActiveIngredientID",
                table: "MedicationInteraction");

            migrationBuilder.DropColumn(
                name: "ActiveIngredientID2",
                table: "MedicationInteraction");

            migrationBuilder.RenameColumn(
                name: "DiseaseID",
                table: "ContraIndication",
                newName: "ConditionID");

            migrationBuilder.RenameIndex(
                name: "IX_ContraIndication_DiseaseID",
                table: "ContraIndication",
                newName: "IX_ContraIndication_ConditionID");

            migrationBuilder.AddColumn<string>(
                name: "Effect",
                table: "MedicationInteraction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MedicationInteraction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "MedicationInteraction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContraIndication_ConditionDiagnosis_ConditionID",
                table: "ContraIndication",
                column: "ConditionID",
                principalTable: "ConditionDiagnosis",
                principalColumn: "ConditionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
