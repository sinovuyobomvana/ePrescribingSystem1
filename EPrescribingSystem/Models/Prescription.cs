using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    [Table("Prescription")]
    public class Prescription
    {
        [Key]
        public int PrescriptionID { get; set; }
        [Display(Name = "Prescription Date")]
        public DateTime PrescriptionDate { get; set; }
        [Display(Name = "Dispensing Date")]
        public DateTime DispensingDate { get; set; }

        public string Instruction { get; set; }

        public string Quantity { get; set; }

        [Display(Name = "Number Of Repeats")]
        public int NumberOfRepeats { get; set; }
        [Display(Name = "Number Of Repeats Left")]
        public int NumberOfRepeatsLeft { get; set; }

        [Display(Name = "Medication Name")]
        [ForeignKey("MedicationID")]
        public int MedicationID { get; set; }
        public Medication Medication { get; set; }

        public string? Instruction2 { get; set; }

        public string? Quantity2 { get; set; }

        [Display(Name = "Number Of Repeats")]
        public int? NumberOfRepeats2 { get; set; }
        [Display(Name = "Number Of Repeats Left")]
        public int? NumberOfRepeatsLeft2 { get; set; }

        [Display(Name = "Medication Name")]
        [ForeignKey("Med2ID")]
        public int? Med2ID { get; set; }
        public Medication Med2 { get; set; }

        public string? Instruction3 { get; set; }

        public string? Quantity3 { get; set; }

        [Display(Name = "Number Of Repeats")]
        public int? NumberOfRepeats3 { get; set; }
        [Display(Name = "Number Of Repeats Left")]
        public int? NumberOfRepeatsLeft3 { get; set; }

        [Display(Name = "Medication Name")]
        [ForeignKey("Medicine3ID")]
        public int? Medicine3ID { get; set; }
        public Medication Medicine3 { get; set; }

        [ForeignKey("PharmacyID")]
        public int? PharmacyID { get; set; }
        public Pharmacy Pharmacy { get; set; }

       
        [ForeignKey("ApplicationUserID")]
        [Display(Name = "Patient")]
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("DoctorID")]
        [Display(Name = "Doctor")]
        public string DoctorID { get; set; }
        public ApplicationUser Doctor { get; set; }
    }
}
