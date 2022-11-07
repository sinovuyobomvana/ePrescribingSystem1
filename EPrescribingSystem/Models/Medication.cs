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
        [ForeignKey("ActiveIngredientID")]
        [Display(Name = "Active Ingredient 1")]
        public int ActiveIngredientID { get; set; }
        public ActiveIngredient ActiveIngredient { get; set; }
        [Display(Name = "Strength 1")]
        public string Strength { get; set; }
        [Display(Name = "Active Ingredient 2")]
        public int ActiveIngredientID2 { get; set; }
        [Display(Name = "Strength 2")]
        public string Strength2 { get; set; }
        [Display(Name = "Active Ingredient 3")]
        public int ActiveIngredientID3 { get; set; }
        [Display(Name = "Strength 3")]
        public string Strength3 { get; set; }




    }
}
