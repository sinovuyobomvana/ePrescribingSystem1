using EPrescribingSystem.Areas.Admin.Data.Repository;
using EPrescribingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MedicationController : Controller
    {
        private readonly IMedicationRepository _service;


        public MedicationController(IMedicationRepository service)
        {
            _service = service;
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

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,DosageForm,Schedule,ActiveIngredientID,Strength")] Medication medication)
        {
            if (!ModelState.IsValid)
            {
                return View(medication);
            }
            await _service.AddAsync(medication);
            TempData["SuccessMessage"] = medication.Name + " Medication Created Successfully!";
            return RedirectToAction(nameof(Index));
        }


        //Get: Pharmacy/Details
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Details(int id)
        {
            var medicationDetails = await _service.GetByIdAsync(id);

            if (medicationDetails == null) return View("Not Found!!!");
            return View(medicationDetails);
        }

        //Get: Pharmacy/Update
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Edit(int id)
        {
            var medicationDetails = await _service.GetByIdAsync(id);

            if (medicationDetails == null)
            {
                return NotFound();
            }


            return View(medicationDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Medication medication)
        {
            try
            {
                medication = await _service.UpdateAsync(medication);
            }
            catch
            {

            }
            TempData["SuccessMessage"] = medication.Name + " Medication Updated Successfully!";
            return RedirectToAction("Index");
        }


        //Get: Pharmacy/Delete
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Delete(int id)
        {
            var medication = _service.GetById(id);
            return View(medication);
        }

        [HttpPost]
        public IActionResult Delete(Medication medication)
        {
            try
            {
                medication = _service.Delete(medication);
            }
            catch
            {

            }
            TempData["SuccessMessage"] = medication.Name + " Medication Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}
