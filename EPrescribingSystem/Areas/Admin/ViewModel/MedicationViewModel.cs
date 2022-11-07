using EPrescribingSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EPrescribingSystem.Areas.Admin.ViewModel
{
    public class MedicationViewModel
    {
        public int MedicationID { get; set; }
        public string Name { get; set; }
        public string Schedule { get; set; }
        public string DosageForm { get; set; }
        public string ActiveIngredientName { get; set; }
        public string Strength { get; set; }
        public string Strength2 { get; set; }
        public string Strength3 { get; set; }

    }
}
