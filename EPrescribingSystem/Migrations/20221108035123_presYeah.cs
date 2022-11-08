using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class presYeah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_AspNetUsers_ApplicationUserId",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Prescription");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Prescription",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_ApplicationUserId",
                table: "Prescription",
                newName: "IX_Prescription_ApplicationUserID");

            migrationBuilder.AddColumn<string>(
                name: "Doctor",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_AspNetUsers_ApplicationUserID",
                table: "Prescription",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_AspNetUsers_ApplicationUserID",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Doctor",
                table: "Prescription");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Prescription",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_ApplicationUserID",
                table: "Prescription",
                newName: "IX_Prescription_ApplicationUserId");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_AspNetUsers_ApplicationUserId",
                table: "Prescription",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
