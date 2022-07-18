using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class updatedTablesV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Suburb_SuburbModelSuburbID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SuburbModelSuburbID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SuburbModelSuburbID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "SuburbID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SuburbID",
                table: "AspNetUsers",
                column: "SuburbID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Suburb_SuburbID",
                table: "AspNetUsers",
                column: "SuburbID",
                principalTable: "Suburb",
                principalColumn: "SuburbID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Suburb_SuburbID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SuburbID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "SuburbID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SuburbModelSuburbID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SuburbModelSuburbID",
                table: "AspNetUsers",
                column: "SuburbModelSuburbID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Suburb_SuburbModelSuburbID",
                table: "AspNetUsers",
                column: "SuburbModelSuburbID",
                principalTable: "Suburb",
                principalColumn: "SuburbID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
