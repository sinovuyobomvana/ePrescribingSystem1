using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    public class MedicationModel
    {
        [Key]
        public int MedicationID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DosageForm { get; set; }
        [Required]
        public string Schedule { get; set; }
    }
}
