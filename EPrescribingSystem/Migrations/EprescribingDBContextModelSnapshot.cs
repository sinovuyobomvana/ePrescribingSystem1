﻿// <auto-generated />
using System;
using EPrescribingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EPrescribingSystem.Migrations
{
    [DbContext(typeof(EprescribingDBContext))]
    partial class EprescribingDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EPrescribingSystem.Models.ActiveContraIndication", b =>
                {
                    b.Property<int>("ActiveContraIndicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveIngredientID")
                        .HasColumnType("int");

                    b.Property<int?>("ConditionDiagnosisModelConditionID")
                        .HasColumnType("int");

                    b.Property<int>("ConditionID")
                        .HasColumnType("int");

                    b.HasKey("ActiveContraIndicationID");

                    b.HasIndex("ActiveIngredientID");

                    b.HasIndex("ConditionDiagnosisModelConditionID");

                    b.ToTable("ActiveContraIndication");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.ActiveIngredient", b =>
                {
                    b.Property<int>("ActiveIngredientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActiveIngredientID");

                    b.ToTable("ActiveIngredient");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Addressine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HealthCouncilRegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HighestQualification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PracticeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuburbID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("SuburbID");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProvinceID")
                        .HasColumnType("int");

                    b.HasKey("CityID");

                    b.HasIndex("ProvinceID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.ConditionDiagnosis", b =>
                {
                    b.Property<int>("ConditionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Allergy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DiagnosisDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Doctor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ICD_10_CODE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedicationID")
                        .HasColumnType("int");

                    b.HasKey("ConditionID");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("MedicationID");

                    b.ToTable("ConditionDiagnosis");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.ContraIndication", b =>
                {
                    b.Property<int>("ContraIndicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveIngredientID")
                        .HasColumnType("int");

                    b.Property<int>("DiseaseID")
                        .HasColumnType("int");

                    b.HasKey("ContraIndicationID");

                    b.HasIndex("ActiveIngredientID");

                    b.HasIndex("DiseaseID");

                    b.ToTable("ContraIndication");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.Disease", b =>
                {
                    b.Property<int>("DiseaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ICD_10_CODE")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiseaseID");

                    b.ToTable("Disease");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.MedicalHistory", b =>
                {
                    b.Property<int>("MedicalHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConditionDiagnosisModelConditionID")
                        .HasColumnType("int");

                    b.Property<int>("ConditionID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrescriptionID")
                        .HasColumnType("int");

                    b.HasKey("MedicalHistoryID");

                    b.HasIndex("ConditionDiagnosisModelConditionID");

                    b.HasIndex("PrescriptionID");

                    b.ToTable("MedicalHistory");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.MedicalPractice", b =>
                {
                    b.Property<int>("MedicalPracticeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PracticeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuburbID")
                        .HasColumnType("int");

                    b.HasKey("MedicalPracticeID");

                    b.HasIndex("SuburbID");

                    b.ToTable("MedicalPractice");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.Medication", b =>
                {
                    b.Property<int>("MedicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveIngredientID")
                        .HasColumnType("int");

                    b.Property<int?>("ActiveIngredientID2")
                        .HasColumnType("int");

                    b.Property<int?>("ActiveIngredientID3")
                        .HasColumnType("int");

                    b.Property<string>("DosageForm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Schedule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strength")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strength2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strength3")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicationID");

                    b.HasIndex("ActiveIngredientID");

                    b.ToTable("Medication");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.MedicationActiveIngredient", b =>
                {
                    b.Property<int>("MedicationActiveID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveIngredientID")
                        .HasColumnType("int");

                    b.Property<string>("IngredientStrength")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedicationID")
                        .HasColumnType("int");

                    b.HasKey("MedicationActiveID");

                    b.HasIndex("ActiveIngredientID");

                    b.HasIndex("MedicationID");

                    b.ToTable("MedicationActiveIngredient");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.MedicationInteraction", b =>
                {
                    b.Property<int>("InteractionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActID")
                        .HasColumnType("int");

                    b.Property<int>("ActiveIngredientID")
                        .HasColumnType("int");

                    b.HasKey("InteractionID");

                    b.HasIndex("ActID");

                    b.HasIndex("ActiveIngredientID");

                    b.ToTable("MedicationInteraction");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.Pharmacy", b =>
                {
                    b.Property<int>("PharmacyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuburbID")
                        .HasColumnType("int");

                    b.HasKey("PharmacyID");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("SuburbID");

                    b.ToTable("Pharmacy");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.Prescription", b =>
                {
                    b.Property<int>("PrescriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DispensingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DoctorID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Instruction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instruction2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instruction3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Med2ID")
                        .HasColumnType("int");

                    b.Property<int>("MedicationID")
                        .HasColumnType("int");

                    b.Property<int?>("Medicine3ID")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRepeats")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfRepeats2")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfRepeats3")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRepeatsLeft")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfRepeatsLeft2")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfRepeatsLeft3")
                        .HasColumnType("int");

                    b.Property<int?>("PharmacyID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PrescriptionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Quantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity3")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrescriptionID");

                    b.HasIndex("ApplicationUserID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("Med2ID");

                    b.HasIndex("MedicationID");

                    b.HasIndex("Medicine3ID");

                    b.HasIndex("PharmacyID");

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.Province", b =>
                {
                    b.Property<int>("ProvinceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProvinceID");

                    b.ToTable("Province");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.Suburb", b =>
                {
                    b.Property<int>("SuburbID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SuburbID");

                    b.HasIndex("CityID");

                    b.ToTable("Suburb");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.ActiveContraIndication", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.ActiveIngredient", "ActiveIngredient")
                        .WithMany()
                        .HasForeignKey("ActiveIngredientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EPrescribingSystem.Models.ConditionDiagnosis", "ConditionDiagnosisModel")
                        .WithMany()
                        .HasForeignKey("ConditionDiagnosisModelConditionID");

                    b.Navigation("ActiveIngredient");

                    b.Navigation("ConditionDiagnosisModel");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.ApplicationUser", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.Suburb", "Suburb")
                        .WithMany()
                        .HasForeignKey("SuburbID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Suburb");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.City", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceID");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.ConditionDiagnosis", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("EPrescribingSystem.Models.Medication", "Medication")
                        .WithMany()
                        .HasForeignKey("MedicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Medication");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.ContraIndication", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.ActiveIngredient", "ActiveIngredient")
                        .WithMany()
                        .HasForeignKey("ActiveIngredientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EPrescribingSystem.Models.Disease", "Disease")
                        .WithMany()
                        .HasForeignKey("DiseaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActiveIngredient");

                    b.Navigation("Disease");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.MedicalHistory", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.ConditionDiagnosis", "ConditionDiagnosisModel")
                        .WithMany()
                        .HasForeignKey("ConditionDiagnosisModelConditionID");

                    b.HasOne("EPrescribingSystem.Models.Prescription", "PrescriptionModel")
                        .WithMany()
                        .HasForeignKey("PrescriptionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConditionDiagnosisModel");

                    b.Navigation("PrescriptionModel");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.MedicalPractice", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.Suburb", "Suburb")
                        .WithMany()
                        .HasForeignKey("SuburbID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Suburb");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.Medication", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.ActiveIngredient", "ActiveIngredient")
                        .WithMany()
                        .HasForeignKey("ActiveIngredientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActiveIngredient");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.MedicationActiveIngredient", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.ActiveIngredient", "ActiveIngredient")
                        .WithMany()
                        .HasForeignKey("ActiveIngredientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EPrescribingSystem.Models.Medication", "MedicationModel")
                        .WithMany()
                        .HasForeignKey("MedicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActiveIngredient");

                    b.Navigation("MedicationModel");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.MedicationInteraction", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.ActiveIngredient", "Act")
                        .WithMany()
                        .HasForeignKey("ActID");

                    b.HasOne("EPrescribingSystem.Models.ActiveIngredient", "ActiveIngredient")
                        .WithMany()
                        .HasForeignKey("ActiveIngredientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Act");

                    b.Navigation("ActiveIngredient");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.Pharmacy", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("EPrescribingSystem.Models.Suburb", "Suburb")
                        .WithMany()
                        .HasForeignKey("SuburbID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Suburb");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.Prescription", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserID");

                    b.HasOne("EPrescribingSystem.Models.ApplicationUser", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorID");

                    b.HasOne("EPrescribingSystem.Models.Medication", "Med2")
                        .WithMany()
                        .HasForeignKey("Med2ID");

                    b.HasOne("EPrescribingSystem.Models.Medication", "Medication")
                        .WithMany()
                        .HasForeignKey("MedicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EPrescribingSystem.Models.Medication", "Medicine3")
                        .WithMany()
                        .HasForeignKey("Medicine3ID");

                    b.HasOne("EPrescribingSystem.Models.Pharmacy", "Pharmacy")
                        .WithMany()
                        .HasForeignKey("PharmacyID");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Doctor");

                    b.Navigation("Med2");

                    b.Navigation("Medication");

                    b.Navigation("Medicine3");

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("EPrescribingSystem.Models.Suburb", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EPrescribingSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EPrescribingSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
