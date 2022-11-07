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

        [ForeignKey("ActiveIngredientID")]
        public int ActiveIngredientID { get; set; }
        public ActiveIngredient ActiveIngredient { get; set; }

        [ForeignKey("ConditionID")]
        public int ConditionID { get; set; }
        public ConditionDiagnosis Condition{ get; set; }
    }
}
