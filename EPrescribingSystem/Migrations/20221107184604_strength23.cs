using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class strength23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Strength",
                table: "Medication",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Strength2",
                table: "Medication",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Strength3",
                table: "Medication",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Strength2",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "Strength3",
                table: "Medication");

            migrationBuilder.AlterColumn<int>(
                name: "Strength",
                table: "Medication",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
