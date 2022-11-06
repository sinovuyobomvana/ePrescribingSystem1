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
        public string Name { get; set; }

        public string DosageForm { get; set; }  

        public string Schedule { get; set; }

        public int Strength { get; set; }

        [ForeignKey("ActiveIngredientID")]
        public int ActiveIngredientID { get; set; }
        public ActiveIngredient ActiveIngredient { get; set; }
    }
}
