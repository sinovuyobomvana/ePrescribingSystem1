using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class medicationTableV10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medication_ContraIndication_ContraIndicationID",
                table: "Medication");

            migrationBuilder.DropIndex(
                name: "IX_Medication_ContraIndicationID",
                table: "Medication");

            migrationBuilder.RenameColumn(
                name: "ContraIndicationID",
                table: "Medication",
                newName: "Strength");

            migrationBuilder.AddColumn<int>(
                name: "ActiveIngredientID",
                table: "Medication",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medication_ActiveIngredientID",
                table: "Medication",
                column: "ActiveIngredientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_ActiveIngredient_ActiveIngredientID",
                table: "Medication",
                column: "ActiveIngredientID",
                principalTable: "ActiveIngredient",
                principalColumn: "ActiveIngredientID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medication_ActiveIngredient_ActiveIngredientID",
                table: "Medication");

            migrationBuilder.DropIndex(
                name: "IX_Medication_ActiveIngredientID",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "ActiveIngredientID",
                table: "Medication");

            migrationBuilder.RenameColumn(
                name: "Strength",
                table: "Medication",
                newName: "ContraIndicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_ContraIndicationID",
                table: "Medication",
                column: "ContraIndicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_ContraIndication_ContraIndicationID",
                table: "Medication",
                column: "ContraIndicationID",
                principalTable: "ContraIndication",
                principalColumn: "ContraIndicationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
