using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class @null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Pharmacy_PharmacyID",
                table: "Prescription");

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyID",
                table: "Prescription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Pharmacy_PharmacyID",
                table: "Prescription",
                column: "PharmacyID",
                principalTable: "Pharmacy",
                principalColumn: "PharmacyID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Pharmacy_PharmacyID",
                table: "Prescription");

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyID",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Pharmacy_PharmacyID",
                table: "Prescription",
                column: "PharmacyID",
                principalTable: "Pharmacy",
                principalColumn: "PharmacyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
