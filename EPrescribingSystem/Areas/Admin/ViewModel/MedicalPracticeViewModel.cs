﻿using EPrescribingSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EPrescribingSystem.Areas.Admin.ViewModel
{
    public class MedicalPracticeViewModel
    {
        public MedicalPractice MedicalPractice { get; set; }
        public Pharmacy Pharmacy { get; set; }

        public Medication Medication { get; set; }
        public IEnumerable<SelectListItem> Provinces { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
        public IEnumerable<SelectListItem> Suburbs { get; set; }

        public IEnumerable<SelectListItem> ActiveIngredients { get; set; }
        public List<SelectListItem> Users { get; internal set; }
    }
}
