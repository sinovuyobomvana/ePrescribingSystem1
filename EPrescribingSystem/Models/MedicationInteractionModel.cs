using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    public class MedicationInteractionModel
    {
        [Key]

        public int InteractionID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Effect { get; set; }
    }
}
