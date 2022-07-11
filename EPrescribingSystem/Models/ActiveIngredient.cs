using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    [Table("ActiveIngredient")]
    public class ActiveIngredient
    {
        [Key]
        public int ActiveIngredientID { get; set; }

        public string Name { get; set; }
    }
}
