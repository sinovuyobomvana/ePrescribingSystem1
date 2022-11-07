using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EPrescribingSystem.Data;
using EPrescribingSystem.Models;

namespace EPrescribingSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MedicationInteractionController : Controller
    {
        private readonly EprescribingDBContext _context;

        public MedicationInteractionController(EprescribingDBContext context)
        {
            _context = context;
        }

        // GET: Admin/MedicationInteraction
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            var eprescribingDBContext = _context.MedicationInteractions.Include(m => m.ActiveIngredient);
            return View(await eprescribingDBContext.ToListAsync());
        }

        // GET: Admin/MedicationInteraction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationInteraction = await _context.MedicationInteractions
                .Include(m => m.ActiveIngredient)
                .FirstOrDefaultAsync(m => m.InteractionID == id);
            if (medicationInteraction == null)
            {
                return NotFound();
            }

            return View(medicationInteraction);
        }

        // GET: Admin/MedicationInteraction/Create
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Create()
        {
            ViewData["ActiveIngredientID"] = new SelectList(_context.ActiveIngredients, "ActiveIngredientID", "Name");
            return View();
        }

        // POST: Admin/MedicationInteraction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InteractionID,ActiveIngredientID,ActiveIngredientID2")] MedicationInteraction medicationInteraction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicationInteraction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActiveIngredientID"] = new SelectList(_context.ActiveIngredients, "ActiveIngredientID", "ActiveIngredientID", medicationInteraction.ActiveIngredientID);
            return View(medicationInteraction);
        }

        // GET: Admin/MedicationInteraction/Edit/5
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationInteraction = await _context.MedicationInteractions.FindAsync(id);
            if (medicationInteraction == null)
            {
                return NotFound();
            }
            ViewData["ActiveIngredientID"] = new SelectList(_context.ActiveIngredients, "ActiveIngredientID", "ActiveIngredientID", medicationInteraction.ActiveIngredientID);
            return View(medicationInteraction);
        }

        // POST: Admin/MedicationInteraction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InteractionID,ActiveIngredientID,ActiveIngredientID2")] MedicationInteraction medicationInteraction)
        {
            if (id != medicationInteraction.InteractionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicationInteraction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationInteractionExists(medicationInteraction.InteractionID))
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
            ViewData["ActiveIngredientID"] = new SelectList(_context.ActiveIngredients, "ActiveIngredientID", "ActiveIngredientID", medicationInteraction.ActiveIngredientID);
            return View(medicationInteraction);
        }

        // GET: Admin/MedicationInteraction/Delete/5
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationInteraction = await _context.MedicationInteractions
                .Include(m => m.ActiveIngredient)
                .FirstOrDefaultAsync(m => m.InteractionID == id);
            if (medicationInteraction == null)
            {
                return NotFound();
            }

            return View(medicationInteraction);
        }

        // POST: Admin/MedicationInteraction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicationInteraction = await _context.MedicationInteractions.FindAsync(id);
            _context.MedicationInteractions.Remove(medicationInteraction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicationInteractionExists(int id)
        {
            return _context.MedicationInteractions.Any(e => e.InteractionID == id);
        }
    }
}
