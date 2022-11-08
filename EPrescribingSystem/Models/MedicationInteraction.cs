using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    [Table("MedicationInteraction")]
    public class MedicationInteraction
    {
        [Key]

        public int InteractionID { get; set; }

        [ForeignKey("ActiveIngredientID")]
        [Display(Name = "Active Ingredient 1")]
        public int ActiveIngredientID { get; set; }
        public ActiveIngredient ActiveIngredient { get; set; }

        [ForeignKey("ActID")]

        [Display(Name = "Active Ingredient 2")]
        public int? ActID { get; set; }
        public ActiveIngredient Act { get; set; }
    }
}
