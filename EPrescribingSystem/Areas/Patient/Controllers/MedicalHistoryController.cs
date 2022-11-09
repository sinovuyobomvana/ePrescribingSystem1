using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EPrescribingSystem.Data;
using EPrescribingSystem.Models;

namespace EPrescribingSystem.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class MedicalHistoryController : Controller
    {
        private readonly EprescribingDBContext _context;

        public MedicalHistoryController(EprescribingDBContext context)
        {
            _context = context;
        }

        // GET: Patient/MedicalHistory
        [Route("[area]/[controller]/[action]/{id?}")]
        public async Task<IActionResult> Index(string id)
        {
            var eprescribingDBContext = _context.ConditionDiagnoses.Where(u => u.ApplicationUserId == id).Include(d=>d.Doctor).Include(c => c.ApplicationUser).Include(c => c.Medication);
            return View(await eprescribingDBContext.ToListAsync());
        }

        // GET: Patient/MedicalHistory/Details/5
        [Route("[area]/[controller]/[action]/{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionDiagnosis = await _context.ConditionDiagnoses
                .Include(c => c.ApplicationUser)
                .Include(c => c.Medication)
                .FirstOrDefaultAsync(m => m.ConditionID == id);
            if (conditionDiagnosis == null)
            {
                return NotFound();
            }

            return View(conditionDiagnosis);
        }

        // GET: Patient/MedicalHistory/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["MedicationID"] = new SelectList(_context.Medications, "MedicationID", "MedicationID");
            return View();
        }

        // POST: Patient/MedicalHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConditionID,ICD_10_CODE,Diagnosis,DiagnosisDate,ApplicationUserId,Doctor,Allergy,MedicationID")] ConditionDiagnosis conditionDiagnosis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conditionDiagnosis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", conditionDiagnosis.ApplicationUserId);
            ViewData["MedicationID"] = new SelectList(_context.Medications, "MedicationID", "MedicationID", conditionDiagnosis.MedicationID);
            return View(conditionDiagnosis);
        }

        // GET: Patient/MedicalHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionDiagnosis = await _context.ConditionDiagnoses.FindAsync(id);
            if (conditionDiagnosis == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", conditionDiagnosis.ApplicationUserId);
            ViewData["MedicationID"] = new SelectList(_context.Medications, "MedicationID", "MedicationID", conditionDiagnosis.MedicationID);
            return View(conditionDiagnosis);
        }

        // POST: Patient/MedicalHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConditionID,ICD_10_CODE,Diagnosis,DiagnosisDate,ApplicationUserId,Doctor,Allergy,MedicationID")] ConditionDiagnosis conditionDiagnosis)
        {
            if (id != conditionDiagnosis.ConditionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conditionDiagnosis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConditionDiagnosisExists(conditionDiagnosis.ConditionID))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", conditionDiagnosis.ApplicationUserId);
            ViewData["MedicationID"] = new SelectList(_context.Medications, "MedicationID", "MedicationID", conditionDiagnosis.MedicationID);
            return View(conditionDiagnosis);
        }

        // GET: Patient/MedicalHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionDiagnosis = await _context.ConditionDiagnoses
                .Include(c => c.ApplicationUser)
                .Include(c => c.Medication)
                .FirstOrDefaultAsync(m => m.ConditionID == id);
            if (conditionDiagnosis == null)
            {
                return NotFound();
            }

            return View(conditionDiagnosis);
        }

        // POST: Patient/MedicalHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conditionDiagnosis = await _context.ConditionDiagnoses.FindAsync(id);
            _context.ConditionDiagnoses.Remove(conditionDiagnosis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConditionDiagnosisExists(int id)
        {
            return _context.ConditionDiagnoses.Any(e => e.ConditionID == id);
        }
    }
}
