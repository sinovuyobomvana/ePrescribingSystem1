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
        [Required]
        public DateTime PrescriptionDate { get; set; }
        public DateTime DispensingDate { get; set; }
        [Required]
        public string Instruction { get; set; }

        public string Quantity { get; set; }

        [Required]
        public int NumberOfRepeats { get; set; }
        public int NumberOfRepeatsLeft { get; set; }

        [ForeignKey("MedicationID")]
        public int MedicationID { get; set; }
        public Medication Medication { get; set; }

        [ForeignKey("PharmacyID")]
        public int PharmacyID { get; set; }
        public Pharmacy Pharmacy { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
}
