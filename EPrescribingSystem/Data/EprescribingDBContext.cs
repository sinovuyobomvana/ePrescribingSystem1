using EPrescribingSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Data
{
    public class EprescribingDBContext : IdentityDbContext<ApplicationUser>
    {
        public EprescribingDBContext(DbContextOptions<EprescribingDBContext> options) : base(options)
        {

        }

        public DbSet<ActiveIngredient> ActiveIngredients { get; set; }
        public DbSet<ActiveContraIndication> ActiveContraIndications { get; set; }
        public DbSet<City> CityModels { get; set; }
        public DbSet<ConditionDiagnosis> ConditionDiagnoses{ get; set; }
        public DbSet<ContraIndication> ContraIndications { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<MedicalPractice> MedicalPractices { get; set; }
        public DbSet<MedicationActiveIngredient> MedicationActiveIngredients { get; set; }
        public DbSet<MedicationInteraction> MedicationInteractions { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Suburb> Suburbs { get; set; }



    }
}
