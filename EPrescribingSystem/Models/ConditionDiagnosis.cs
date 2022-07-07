using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    [Table("ConditionDiagnosis")]
    public class ConditionDiagnosis
    {
        [Key]

        public int ConditionID { get; set; }

        public string ConditionName { get; set; }

        public string symptoms { get; set; }
    }
}
