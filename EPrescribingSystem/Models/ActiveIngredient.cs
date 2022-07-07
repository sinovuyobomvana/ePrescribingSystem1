using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    public class ActiveIngredient
    {
        [Key]

        public int ActiveIngredientID { get; set; }

        public string Name { get; set; }
    }
}
