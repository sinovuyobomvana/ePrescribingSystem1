using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    public class MedicationActiveIngredient
    {
        [Key]

        public int MedicationActiveID { get; set; }

        public string IngredientStrength { get; set; }
    }
}
