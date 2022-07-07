using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    public class MedicalHistoryModel
    {
        [Key]

        public int MedicalHistoryID { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }


    }
}
