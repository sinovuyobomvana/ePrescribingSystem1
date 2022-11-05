using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class SuburbV8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SuburbID",
                table: "MedicalPractice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPractice_SuburbID",
                table: "MedicalPractice",
                column: "SuburbID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalPractice_Suburb_SuburbID",
                table: "MedicalPractice",
                column: "SuburbID",
                principalTable: "Suburb",
                principalColumn: "SuburbID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalPractice_Suburb_SuburbID",
                table: "MedicalPractice");

            migrationBuilder.DropIndex(
                name: "IX_MedicalPractice_SuburbID",
                table: "MedicalPractice");

            migrationBuilder.AlterColumn<int>(
                name: "SuburbID",
                table: "MedicalPractice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
