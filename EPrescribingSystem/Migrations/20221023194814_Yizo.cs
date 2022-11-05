using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class Yizo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Pharmacy_PharmacyModelPharmacyID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PharmacyModelPharmacyID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PharmacyID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PharmacyModelPharmacyID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Pharmacy",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Pharmacy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_ApplicationUserId",
                table: "Pharmacy",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacy_AspNetUsers_ApplicationUserId",
                table: "Pharmacy",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacy_AspNetUsers_ApplicationUserId",
                table: "Pharmacy");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacy_ApplicationUserId",
                table: "Pharmacy");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Pharmacy");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Pharmacy");

            migrationBuilder.AddColumn<string>(
                name: "PharmacyID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PharmacyModelPharmacyID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PharmacyModelPharmacyID",
                table: "AspNetUsers",
                column: "PharmacyModelPharmacyID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Pharmacy_PharmacyModelPharmacyID",
                table: "AspNetUsers",
                column: "PharmacyModelPharmacyID",
                principalTable: "Pharmacy",
                principalColumn: "PharmacyID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
