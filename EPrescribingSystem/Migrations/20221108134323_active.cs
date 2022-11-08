using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class active : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveIngredientID2",
                table: "MedicationInteraction");

            migrationBuilder.AddColumn<int>(
                name: "ActID",
                table: "MedicationInteraction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicationInteraction_ActID",
                table: "MedicationInteraction",
                column: "ActID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationInteraction_ActiveIngredient_ActID",
                table: "MedicationInteraction",
                column: "ActID",
                principalTable: "ActiveIngredient",
                principalColumn: "ActiveIngredientID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicationInteraction_ActiveIngredient_ActID",
                table: "MedicationInteraction");

            migrationBuilder.DropIndex(
                name: "IX_MedicationInteraction_ActID",
                table: "MedicationInteraction");

            migrationBuilder.DropColumn(
                name: "ActID",
                table: "MedicationInteraction");

            migrationBuilder.AddColumn<int>(
                name: "ActiveIngredientID2",
                table: "MedicationInteraction",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
