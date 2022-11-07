using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    [Table("ContraIndication")]
    public class ContraIndication
    {
        [Key]
     
        public int ContraIndicationID { get; set; }
        [Display(Name = "Active Ingredient")]

        [ForeignKey("ActiveIngredientID")]
        public int ActiveIngredientID { get; set; }
        public ActiveIngredient ActiveIngredient { get; set; }
        [Display(Name = "Diagnosis")]
        [ForeignKey("DiseaseID")]
        public int DiseaseID { get; set; }
        public Disease Disease { get; set; }
    }
}
