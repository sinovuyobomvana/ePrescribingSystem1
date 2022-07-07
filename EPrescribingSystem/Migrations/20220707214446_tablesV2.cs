using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EPrescribingSystem.Migrations
{
    public partial class tablesV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SuburbModel_SuburbModelSuburbID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SuburbModel");

            migrationBuilder.DropTable(
                name: "CityModel");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SuburbModelSuburbID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SuburbModelSuburbID",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "ActiveIngredient",
                columns: table => new
                {
                    ActiveIngredientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveIngredient", x => x.ActiveIngredientID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "ConditionDiagnosis",
                columns: table => new
                {
                    ConditionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    symptoms = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionDiagnosis", x => x.ConditionID);
                });

            migrationBuilder.CreateTable(
                name: "ContraIndication",
                columns: table => new
                {
                    ContraIndicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraIndication", x => x.ContraIndicationID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalPractice",
                columns: table => new
                {
                    practiceNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<int>(type: "int", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalPractice", x => x.practiceNum);
                });

            migrationBuilder.CreateTable(
                name: "MedicationInteraction",
                columns: table => new
                {
                    InteractionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationInteraction", x => x.InteractionID);
                });

            migrationBuilder.CreateTable(
                name: "Suburb",
                columns: table => new
                {
                    SuburbID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburb", x => x.SuburbID);
                    table.ForeignKey(
                        name: "FK_Suburb_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActiveContraIndication",
                columns: table => new
                {
                    ActiveContraIndicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveIngredientID = table.Column<int>(type: "int", nullable: false),
                    ConditionID = table.Column<int>(type: "int", nullable: false),
                    ConditionDiagnosisModelConditionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveContraIndication", x => x.ActiveContraIndicationID);
                    table.ForeignKey(
                        name: "FK_ActiveContraIndication_ActiveIngredient_ActiveIngredientID",
                        column: x => x.ActiveIngredientID,
                        principalTable: "ActiveIngredient",
                        principalColumn: "ActiveIngredientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActiveContraIndication_ConditionDiagnosis_ConditionDiagnosisModelConditionID",
                        column: x => x.ConditionDiagnosisModelConditionID,
                        principalTable: "ConditionDiagnosis",
                        principalColumn: "ConditionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    MedicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DosageForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Schedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContraIndicationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.MedicationID);
                    table.ForeignKey(
                        name: "FK_Medication_ContraIndication_ContraIndicationID",
                        column: x => x.ContraIndicationID,
                        principalTable: "ContraIndication",
                        principalColumn: "ContraIndicationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy",
                columns: table => new
                {
                    PharmacyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuburbID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy", x => x.PharmacyID);
                    table.ForeignKey(
                        name: "FK_Pharmacy_Suburb_SuburbID",
                        column: x => x.SuburbID,
                        principalTable: "Suburb",
                        principalColumn: "SuburbID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationActiveIngredient",
                columns: table => new
                {
                    MedicationActiveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientStrength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveIngredientID = table.Column<int>(type: "int", nullable: false),
                    MedicationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationActiveIngredient", x => x.MedicationActiveID);
                    table.ForeignKey(
                        name: "FK_MedicationActiveIngredient_ActiveIngredient_ActiveIngredientID",
                        column: x => x.ActiveIngredientID,
                        principalTable: "ActiveIngredient",
                        principalColumn: "ActiveIngredientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationActiveIngredient_Medication_MedicationID",
                        column: x => x.MedicationID,
                        principalTable: "Medication",
                        principalColumn: "MedicationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descritpion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfRepeats = table.Column<int>(type: "int", nullable: false),
                    MedicationID = table.Column<int>(type: "int", nullable: false),
                    PharmacyID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionID);
                    table.ForeignKey(
                        name: "FK_Prescription_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_Medication_MedicationID",
                        column: x => x.MedicationID,
                        principalTable: "Medication",
                        principalColumn: "MedicationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Pharmacy_PharmacyID",
                        column: x => x.PharmacyID,
                        principalTable: "Pharmacy",
                        principalColumn: "PharmacyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                columns: table => new
                {
                    MedicalHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrescriptionID = table.Column<int>(type: "int", nullable: false),
                    ConditionID = table.Column<int>(type: "int", nullable: false),
                    ConditionDiagnosisModelConditionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.MedicalHistoryID);
                    table.ForeignKey(
                        name: "FK_MedicalHistory_ConditionDiagnosis_ConditionDiagnosisModelConditionID",
                        column: x => x.ConditionDiagnosisModelConditionID,
                        principalTable: "ConditionDiagnosis",
                        principalColumn: "ConditionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalHistory_Prescription_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescription",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SuburbID",
                table: "AspNetUsers",
                column: "SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveContraIndication_ActiveIngredientID",
                table: "ActiveContraIndication",
                column: "ActiveIngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveContraIndication_ConditionDiagnosisModelConditionID",
                table: "ActiveContraIndication",
                column: "ConditionDiagnosisModelConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_ConditionDiagnosisModelConditionID",
                table: "MedicalHistory",
                column: "ConditionDiagnosisModelConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_PrescriptionID",
                table: "MedicalHistory",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_ContraIndicationID",
                table: "Medication",
                column: "ContraIndicationID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationActiveIngredient_ActiveIngredientID",
                table: "MedicationActiveIngredient",
                column: "ActiveIngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationActiveIngredient_MedicationID",
                table: "MedicationActiveIngredient",
                column: "MedicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_SuburbID",
                table: "Pharmacy",
                column: "SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_ApplicationUserId",
                table: "Prescription",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_MedicationID",
                table: "Prescription",
                column: "MedicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PharmacyID",
                table: "Prescription",
                column: "PharmacyID");

            migrationBuilder.CreateIndex(
                name: "IX_Suburb_CityID",
                table: "Suburb",
                column: "CityID");

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

            migrationBuilder.DropTable(
                name: "ActiveContraIndication");

            migrationBuilder.DropTable(
                name: "MedicalHistory");

            migrationBuilder.DropTable(
                name: "MedicalPractice");

            migrationBuilder.DropTable(
                name: "MedicationActiveIngredient");

            migrationBuilder.DropTable(
                name: "MedicationInteraction");

            migrationBuilder.DropTable(
                name: "ConditionDiagnosis");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "ActiveIngredient");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "Pharmacy");

            migrationBuilder.DropTable(
                name: "ContraIndication");

            migrationBuilder.DropTable(
                name: "Suburb");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SuburbID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "SuburbModelSuburbID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CityModel",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityModel", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "SuburbModel",
                columns: table => new
                {
                    SuburbID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    CityModelCityID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuburbModel", x => x.SuburbID);
                    table.ForeignKey(
                        name: "FK_SuburbModel_CityModel_CityModelCityID",
                        column: x => x.CityModelCityID,
                        principalTable: "CityModel",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SuburbModelSuburbID",
                table: "AspNetUsers",
                column: "SuburbModelSuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_SuburbModel_CityModelCityID",
                table: "SuburbModel",
                column: "CityModelCityID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SuburbModel_SuburbModelSuburbID",
                table: "AspNetUsers",
                column: "SuburbModelSuburbID",
                principalTable: "SuburbModel",
                principalColumn: "SuburbID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
