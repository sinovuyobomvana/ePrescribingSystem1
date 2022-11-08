using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class doctorID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doctor",
                table: "Prescription");

            migrationBuilder.AddColumn<string>(
                name: "DoctorID",
                table: "Prescription",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_DoctorID",
                table: "Prescription",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_AspNetUsers_DoctorID",
                table: "Prescription",
                column: "DoctorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_AspNetUsers_DoctorID",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_DoctorID",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "Prescription");

            migrationBuilder.AddColumn<string>(
                name: "Doctor",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
