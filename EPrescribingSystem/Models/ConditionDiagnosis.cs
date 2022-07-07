using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    public class ConditionDiagnosis
    {
        [Key]

        public int ConditionID { get; set; }

        public string ConditionName { get; set; }

        public string symptoms { get; set; }
    }
}
