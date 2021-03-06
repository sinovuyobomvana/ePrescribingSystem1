using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    [Table("Medication")]
    public class Medication
    {
        [Key]
        public int MedicationID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DosageForm { get; set; }
        [Required]
        public string Schedule { get; set; }

        [ForeignKey("ContraIndicationID")]
        public int ContraIndicationID { get; set; }
        public ContraIndication ContraIndication { get; set; }
    }
}
