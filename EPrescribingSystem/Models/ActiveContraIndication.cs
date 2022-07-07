﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    public class ActiveContraIndication
    {
        [Key]

        public int ActiveContraIndicationID { get; set; }

        [ForeignKey("ActiveIngredientID")]
        public int ActiveIngredientID { get; set; }
        public ActiveIngredient ActiveIngredient { get; set; }


        [ForeignKey("ConditionID")]
        public int ConditionID { get; set; }
        public ConditionDiagnosisModel ConditionDiagnosisModel { get; set; }
    }
}
