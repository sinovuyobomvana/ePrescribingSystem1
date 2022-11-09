using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class doc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doctor",
                table: "ConditionDiagnosis");

            migrationBuilder.AddColumn<string>(
                name: "DoctorID",
                table: "ConditionDiagnosis",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConditionDiagnosis_DoctorID",
                table: "ConditionDiagnosis",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionDiagnosis_AspNetUsers_DoctorID",
                table: "ConditionDiagnosis",
                column: "DoctorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConditionDiagnosis_AspNetUsers_DoctorID",
                table: "ConditionDiagnosis");

            migrationBuilder.DropIndex(
                name: "IX_ConditionDiagnosis_DoctorID",
                table: "ConditionDiagnosis");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "ConditionDiagnosis");

            migrationBuilder.AddColumn<string>(
                name: "Doctor",
                table: "ConditionDiagnosis",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
