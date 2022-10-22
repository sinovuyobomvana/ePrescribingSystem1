using EPrescribingSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EPrescribingSystem.Areas.Admin.ViewModel
{
    public class MedicalPracticeViewModel
    {
        public MedicalPractice MedicalPractice { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public IEnumerable<Pharmacy> Pharmacies { get; set; }
        public IEnumerable<SelectListItem> Provinces { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
        public IEnumerable<SelectListItem> Suburbs { get; set; }
    }
}
