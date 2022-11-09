using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    [Table("ConditionDiagnosis")]
    public class ConditionDiagnosis
    {
        [Key]

        public int ConditionID { get; set; }

        public string ICD_10_CODE { get; set; }

        public string Diagnosis { get; set; }

        public DateTime DiagnosisDate { get; set; }

        [Display(Name = "Patient")]
        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "Doctor")]
        [ForeignKey("DoctorID")]

        public string DoctorID { get; set; }
        public ApplicationUser Doctor { get; set; }

        public string Allergy { get; set; }
        [Display(Name = "Medication")]
        [ForeignKey("MedicationID")]
        public int MedicationID { get; set; }
        public Medication Medication { get; set; }
    }
}
