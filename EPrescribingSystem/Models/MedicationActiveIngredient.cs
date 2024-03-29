﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    [Table("MedicationActiveIngredient")]
    public class MedicationActiveIngredient
    {
        [Key]

        public int MedicationActiveID { get; set; }

        public string IngredientStrength { get; set; }

        [ForeignKey("ActiveIngredientID")]
        public int ActiveIngredientID { get; set; }
        public ActiveIngredient ActiveIngredient { get; set; }


        [ForeignKey("MedicationID")]
        public int MedicationID { get; set; }
        public Medication MedicationModel { get; set; }

    }
}
