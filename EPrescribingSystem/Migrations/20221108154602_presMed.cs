using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class presMed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Instruction2",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instruction3",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Med2ID",
                table: "Prescription",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Medicine3ID",
                table: "Prescription",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRepeats2",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRepeats3",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRepeatsLeft2",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRepeatsLeft3",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Quantity2",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quantity3",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Med2ID",
                table: "Prescription",
                column: "Med2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicine3ID",
                table: "Prescription",
                column: "Medicine3ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medication_Med2ID",
                table: "Prescription",
                column: "Med2ID",
                principalTable: "Medication",
                principalColumn: "MedicationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medication_Medicine3ID",
                table: "Prescription",
                column: "Medicine3ID",
                principalTable: "Medication",
                principalColumn: "MedicationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medication_Med2ID",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medication_Medicine3ID",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Med2ID",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Medicine3ID",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Instruction2",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Instruction3",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Med2ID",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Medicine3ID",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "NumberOfRepeats2",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "NumberOfRepeats3",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "NumberOfRepeatsLeft2",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "NumberOfRepeatsLeft3",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Quantity2",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Quantity3",
                table: "Prescription");
        }
    }
}
