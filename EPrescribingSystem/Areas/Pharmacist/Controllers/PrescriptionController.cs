using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EPrescribingSystem.Data;
using EPrescribingSystem.Models;

namespace EPrescribingSystem.Areas.Pharmacist.Controllers
{
    [Area("Pharmacist")]
    public class PrescriptionController : Controller
    {
        private readonly EprescribingDBContext _context;

        public PrescriptionController(EprescribingDBContext context)
        {
            _context = context;
        }

        // GET: Pharmacist/Prescription
        [HttpGet]
        [Route("[area]/[controller]/[action]/{id?}")]
        public async Task<IActionResult> Index(string id)
        {
            var eprescribingDBContext = _context.Prescriptions.Where(u=>u.ApplicationUserID == id).Include(p => p.ApplicationUser).Include(p => p.Doctor).Include(p => p.Med2).Include(p => p.Medication).Include(p => p.Medicine3).Include(p => p.Pharmacy);
            return View(await eprescribingDBContext.ToListAsync());
        }

        // GET: Pharmacist/Prescription/Details/5
        [HttpGet]
        [Route("[area]/[controller]/[action]/{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions
                .Include(p => p.ApplicationUser)
                .Include(p => p.Doctor)
                .Include(p => p.Med2)
                .Include(p => p.Medication)
                .Include(p => p.Medicine3)
                .Include(p => p.Pharmacy)
                .FirstOrDefaultAsync(m => m.PrescriptionID == id);
            if (prescription == null)
            {
                return NotFound();
            }


            return View(prescription);
        }

        // GET: Pharmacist/Prescription/Details/5
        [HttpGet]
        [Route("[area]/[controller]/[action]/{id?}")]
        public async Task<IActionResult> Details1(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions
                .Include(p => p.ApplicationUser)
                .Include(p => p.Doctor)
                .Include(p => p.Med2)
                .Include(p => p.Medication)
                .Include(p => p.Medicine3)
                .Include(p => p.Pharmacy)
                .FirstOrDefaultAsync(m => m.PrescriptionID == id);
            if (prescription == null)
            {
                return NotFound();
            }

            TempData["SuccessMessage"] = "Medication Dispensed Successfully!";

            return View(prescription);
        }

        // GET: Pharmacist/Prescription/Create
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Create()
        {
            ViewData["ApplicationUserID"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["DoctorID"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["Med2ID"] = new SelectList(_context.Medications, "MedicationID", "Name");
            ViewData["MedicationID"] = new SelectList(_context.Medications, "MedicationID", "Name");
            ViewData["Medicine3ID"] = new SelectList(_context.Medications, "MedicationID", "Name");
            ViewData["PharmacyID"] = new SelectList(_context.Pharmacies, "PharmacyID", "AddressLine1");
            return View();
        }

        // POST: Pharmacist/Prescription/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrescriptionID,PrescriptionDate,DispensingDate,Instruction,Quantity,NumberOfRepeats,NumberOfRepeatsLeft,MedicationID,Instruction2,Quantity2,NumberOfRepeats2,NumberOfRepeatsLeft2,Med2ID,Instruction3,Quantity3,NumberOfRepeats3,NumberOfRepeatsLeft3,Medicine3ID,PharmacyID,ApplicationUserID,DoctorID")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserID"] = new SelectList(_context.Users, "Id", "Id", prescription.ApplicationUserID);
            ViewData["DoctorID"] = new SelectList(_context.Users, "Id", "Id", prescription.DoctorID);
            ViewData["Med2ID"] = new SelectList(_context.Medications, "MedicationID", "Name", prescription.Med2ID);
            ViewData["MedicationID"] = new SelectList(_context.Medications, "MedicationID", "Name", prescription.MedicationID);
            ViewData["Medicine3ID"] = new SelectList(_context.Medications, "MedicationID", "Name", prescription.Medicine3ID);
            ViewData["PharmacyID"] = new SelectList(_context.Pharmacies, "PharmacyID", "AddressLine1", prescription.PharmacyID);
            return View(prescription);
        }

        // GET: Pharmacist/Prescription/Edit/5
        [HttpGet]
        [Route("[area]/[controller]/[action]/{id?}")]
        public async Task<IActionResult> Edit1(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserID"] = new SelectList(_context.Users, "Id", "Id", prescription.ApplicationUserID);
            ViewData["DoctorID"] = new SelectList(_context.Users, "Id", "Id", prescription.DoctorID);
            ViewData["Med2ID"] = new SelectList(_context.Medications, "MedicationID", "Name", prescription.Med2ID);
            ViewData["MedicationID"] = new SelectList(_context.Medications, "MedicationID", "Name", prescription.MedicationID);
            ViewData["Medicine3ID"] = new SelectList(_context.Medications, "MedicationID", "Name", prescription.Medicine3ID);
            ViewData["PharmacyID"] = new SelectList(_context.Pharmacies, "PharmacyID", "AddressLine1", prescription.PharmacyID);

            ViewBag.MdID = id;

            return View(prescription);
        }

        // POST: Pharmacist/Prescription/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[area]/[controller]/[action]/{id?}")]
        public async Task<IActionResult> Edit(int id, [Bind("PrescriptionID,PrescriptionDate,DispensingDate,Instruction,Quantity,NumberOfRepeats,NumberOfRepeatsLeft,MedicationID,Instruction2,Quantity2,NumberOfRepeats2,NumberOfRepeatsLeft2,Med2ID,Instruction3,Quantity3,NumberOfRepeats3,NumberOfRepeatsLeft3,Medicine3ID,PharmacyID,ApplicationUserID,DoctorID")] Prescription prescription)
        {
            if (id != prescription.PrescriptionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (prescription.MedicationID == id)
                    {
                        prescription.NumberOfRepeatsLeft--;
                    }else if(prescription.Med2ID == id)
                    {
                        prescription.NumberOfRepeatsLeft2--;
                    }
                    else if(prescription.Medicine3ID == id)
                    {
                        prescription.NumberOfRepeatsLeft3--;
                    }


                    prescription.DispensingDate= DateTime.Now;
                    _context.Update(prescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescriptionExists(prescription.PrescriptionID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserID"] = new SelectList(_context.Users, "Id", "Id", prescription.ApplicationUserID);
            ViewData["DoctorID"] = new SelectList(_context.Users, "Id", "Id", prescription.DoctorID);
            ViewData["Med2ID"] = new SelectList(_context.Medications, "MedicationID", "MedicationID", prescription.Med2ID);
            ViewData["MedicationID"] = new SelectList(_context.Medications, "MedicationID", "MedicationID", prescription.MedicationID);
            ViewData["Medicine3ID"] = new SelectList(_context.Medications, "MedicationID", "MedicationID", prescription.Medicine3ID);
            ViewData["PharmacyID"] = new SelectList(_context.Pharmacies, "PharmacyID", "AddressLine1", prescription.PharmacyID);
            return View(prescription);
        }

        // GET: Pharmacist/Prescription/Delete/5
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions
                .Include(p => p.ApplicationUser)
                .Include(p => p.Doctor)
                .Include(p => p.Med2)
                .Include(p => p.Medication)
                .Include(p => p.Medicine3)
                .Include(p => p.Pharmacy)
                .FirstOrDefaultAsync(m => m.PrescriptionID == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // POST: Pharmacist/Prescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            _context.Prescriptions.Remove(prescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionExists(int id)
        {
            return _context.Prescriptions.Any(e => e.PrescriptionID == id);
        }
    }
}
