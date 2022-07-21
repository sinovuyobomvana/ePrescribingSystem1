using EPrescribingSystem.Areas.Admin.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PharmacyController : Controller
    {
        private readonly IPharmacyRepository _service;


        public PharmacyController(IPharmacyRepository service)
        {
            _service = service;
        }

        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
    }
}
