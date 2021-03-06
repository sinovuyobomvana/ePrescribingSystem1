using EPrescribingSystem.Areas.Admin.Data.Repository;
using EPrescribingSystem.Areas.Admin.Data.Services;
using EPrescribingSystem.Data;
using EPrescribingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MedicalPracticeController : Controller
    {
        private readonly IMedicalPracticeRepository _service;


        public MedicalPracticeController(IMedicalPracticeRepository service)
        {
            _service = service;
        }
  
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Medical Practice/Create
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("PracticeNumber,Name,Address1,Address2,ContactNum,EmailAddress")]MedicalPractice medicalPractice)
        {
            if (!ModelState.IsValid)
            {
                return View(medicalPractice);
            }
            await _service.AddAsync(medicalPractice);
            return RedirectToAction(nameof(Index));
        }

        //Get: Medical Practice/Details
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Details(int id)
        {
            var medicalPracticeDetails = await _service.GetByIdAsync(id);

            if (medicalPracticeDetails == null) return View("Not Found!!!");
            return View(medicalPracticeDetails);
        }

        //Get: Medical Practice/Update
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Edit(int id)
        {
            var medicalPracticeDetails = await _service.GetByIdAsync(id);

            if (medicalPracticeDetails == null)
            {
                return NotFound();
            }


            return View(medicalPracticeDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MedicalPractice medicalPractice)
        {
            try
            {
                medicalPractice = await _service.UpdateAsync(medicalPractice);
            }
            catch
            {

            }

            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("MedicalPracticeID,PracticeNumber,Name,Address1,Address2,ContactNum,EmailAddress")] MedicalPractice medicalPractice)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(medicalPractice);
        //    }
        //    await _service.UpdateAsync(id, medicalPractice);
        //    return RedirectToAction(nameof(Index));
        //}

        //Get: Medical Practice/Delete
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Delete(int id)
        {
            var medicalPractice = _service.GetById(id);
            return View(medicalPractice);
        }

        [HttpPost]
        public IActionResult Delete(MedicalPractice medicalPractice)
        {
            try
            {
                medicalPractice = _service.Delete(medicalPractice);
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //[Route("[area]/[controller]/[action]")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var medicalPracticeDetails = await _service.GetByIdAsync(id);

        //    return View(medicalPracticeDetails);
        //}

        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var medicalPracticeDetails = await _service.GetByIdAsync(id);
        //    if (medicalPracticeDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    await _service.DeleteAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
