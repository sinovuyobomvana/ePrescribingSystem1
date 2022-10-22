using EPrescribingSystem.Areas.Admin.Data.Repository;
using EPrescribingSystem.Areas.Admin.ViewModel;
using EPrescribingSystem.Data;
using EPrescribingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        private readonly EprescribingDBContext _context = null;

        public PharmacyController(EprescribingDBContext context, IPharmacyRepository service)
        {
            _service = service;
            _context = context;
        }

        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }


        //Get: Pharmacy/Create
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Create()
        {
            MedicalPracticeViewModel medicalPracticeModel = new MedicalPracticeViewModel();

            medicalPracticeModel.Pharmacy = new Models.Pharmacy();
            List<SelectListItem> Provinces = _context.Provinces
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.ProvinceID.ToString(),
                    Text = n.Name
                }).ToList();

            medicalPracticeModel.Provinces = Provinces;
            medicalPracticeModel.Cities = new List<SelectListItem>();

            medicalPracticeModel.Pharmacy = new Models.Pharmacy();
            List<SelectListItem> Cities = _context.Cities
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.CityID.ToString(),
                    Text = n.Name
                }).ToList();

            medicalPracticeModel.Cities = Cities;
            medicalPracticeModel.Suburbs = new List<SelectListItem>();

            return View(medicalPracticeModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Address1,ContactNumber,EmailAddress,LicenseNumber,SuburbID, PostalCode, Province")] Pharmacy pharmacy)
        {
            if (!ModelState.IsValid)
            {
                return View(pharmacy);
            }
            await _service.AddAsync(pharmacy);
            return RedirectToAction(nameof(Index));
        }


        //Get: Pharmacy/Details
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Details(int id)
        {
            var pharmacyDetails = await _service.GetByIdAsync(id);

            if (pharmacyDetails == null) return View("Not Found!!!");
            return View(pharmacyDetails);
        }

        //Get: Pharmacy/Update
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Edit(int id)
        {

            Pharmacy pharmacy = _service.GetById(id);
            return View(pharmacy);
        }
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var pharmacyDetails = await _service.GetByIdAsync(id);

        //    if (pharmacyDetails == null)
        //    {
        //        return NotFound();
        //    }


        //    return View(pharmacyDetails);
        //}

        [HttpPost]
        public IActionResult Edit(Pharmacy pharmacy)
        {
            try
            {
                pharmacy = _service.Update(pharmacy);
            }
            catch
            {

            }

            return RedirectToAction("Index");
        }


        //Get: Pharmacy/Delete
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Delete(int id)
        {
            var pharmacy = _service.GetById(id);
            return View(pharmacy);
        }

        [HttpPost]
        public IActionResult Delete(Pharmacy pharmacy)
        {
            try
            {
                pharmacy = _service.Delete(pharmacy);
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }
    }
}
