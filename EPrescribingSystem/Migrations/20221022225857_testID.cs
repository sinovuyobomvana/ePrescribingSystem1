using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class testID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalPractice_Suburb_SuburbID",
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

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalPractice_Suburb_SuburbID",
                table: "MedicalPractice",
                column: "SuburbID",
                principalTable: "Suburb",
                principalColumn: "SuburbID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalPractice_Suburb_SuburbID",
                table: "MedicalPractice");

            migrationBuilder.AlterColumn<int>(
                name: "SuburbID",
                table: "MedicalPractice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalPractice_Suburb_SuburbID",
                table: "MedicalPractice",
                column: "SuburbID",
                principalTable: "Suburb",
                principalColumn: "SuburbID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
