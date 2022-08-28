using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using EPrescribingSystem.Models;

namespace EPrescribingSystem.ViewModel
{
    public class UserCreateModel
    {
        public RegisterUserModel RegisterUserModel { get; set; }
        public IEnumerable<SelectListItem> Provinces { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set;  }
        public IEnumerable<SelectListItem> Suburbs { get; set; }
    }
}
