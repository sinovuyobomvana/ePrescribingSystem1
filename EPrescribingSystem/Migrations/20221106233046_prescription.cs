using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class prescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Effect",
                table: "ContraIndication");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ContraIndication");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ContraIndication");

            migrationBuilder.RenameColumn(
                name: "Descritpion",
                table: "Prescription",
                newName: "Instruction");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Prescription",
                newName: "PrescriptionDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "DispensingDate",
                table: "Prescription",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRepeatsLeft",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Pharmacy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber",
                table: "Pharmacy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ActiveIngredientID",
                table: "ContraIndication",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConditionID",
                table: "ContraIndication",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ConditionDiagnosis",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContraIndication_ActiveIngredientID",
                table: "ContraIndication",
                column: "ActiveIngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_ContraIndication_ConditionID",
                table: "ContraIndication",
                column: "ConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionDiagnosis_ApplicationUserId",
                table: "ConditionDiagnosis",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionDiagnosis_AspNetUsers_ApplicationUserId",
                table: "ConditionDiagnosis",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContraIndication_ActiveIngredient_ActiveIngredientID",
                table: "ContraIndication",
                column: "ActiveIngredientID",
                principalTable: "ActiveIngredient",
                principalColumn: "ActiveIngredientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContraIndication_ConditionDiagnosis_ConditionID",
                table: "ContraIndication",
                column: "ConditionID",
                principalTable: "ConditionDiagnosis",
                principalColumn: "ConditionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConditionDiagnosis_AspNetUsers_ApplicationUserId",
                table: "ConditionDiagnosis");

            migrationBuilder.DropForeignKey(
                name: "FK_ContraIndication_ActiveIngredient_ActiveIngredientID",
                table: "ContraIndication");

            migrationBuilder.DropForeignKey(
                name: "FK_ContraIndication_ConditionDiagnosis_ConditionID",
                table: "ContraIndication");

            migrationBuilder.DropIndex(
                name: "IX_ContraIndication_ActiveIngredientID",
                table: "ContraIndication");

            migrationBuilder.DropIndex(
                name: "IX_ContraIndication_ConditionID",
                table: "ContraIndication");

            migrationBuilder.DropIndex(
                name: "IX_ConditionDiagnosis_ApplicationUserId",
                table: "ConditionDiagnosis");

            migrationBuilder.DropColumn(
                name: "DispensingDate",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "NumberOfRepeatsLeft",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "ActiveIngredientID",
                table: "ContraIndication");

            migrationBuilder.DropColumn(
                name: "ConditionID",
                table: "ContraIndication");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ConditionDiagnosis");

            migrationBuilder.RenameColumn(
                name: "PrescriptionDate",
                table: "Prescription",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Instruction",
                table: "Prescription",
                newName: "Descritpion");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Pharmacy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber",
                table: "Pharmacy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Effect",
                table: "ContraIndication",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ContraIndication",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ContraIndication",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
