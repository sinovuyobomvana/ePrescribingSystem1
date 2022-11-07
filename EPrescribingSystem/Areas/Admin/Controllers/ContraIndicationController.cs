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
    public class ContraIndicationController : Controller
    {
        private readonly EprescribingDBContext _context;

        public ContraIndicationController(EprescribingDBContext context)
        {
            _context = context;
        }

        // GET: Admin/ContraIndication
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            var eprescribingDBContext = _context.ContraIndications.Include(c => c.ActiveIngredient).Include(c => c.Disease);
            return View(await eprescribingDBContext.ToListAsync());
        }

        // GET: Admin/ContraIndication/Details/5
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contraIndication = await _context.ContraIndications
                .Include(c => c.ActiveIngredient)
                .Include(c => c.Disease)
                .FirstOrDefaultAsync(m => m.ContraIndicationID == id);
            if (contraIndication == null)
            {
                return NotFound();
            }

            return View(contraIndication);
        }

        // GET: Admin/ContraIndication/Create
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Create()
        {
            ViewData["ActiveIngredientID"] = new SelectList(_context.ActiveIngredients, "ActiveIngredientID", "Name");
            ViewData["DiseaseID"] = new SelectList(_context.Disease, "DiseaseID", "Diagnosis");
            return View();
        }

        // POST: Admin/ContraIndication/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContraIndicationID,ActiveIngredientID,DiseaseID")] ContraIndication contraIndication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contraIndication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActiveIngredientID"] = new SelectList(_context.ActiveIngredients, "ActiveIngredientID", "ActiveIngredientID", contraIndication.ActiveIngredientID);
            ViewData["DiseaseID"] = new SelectList(_context.Disease, "DiseaseID", "DiseaseID", contraIndication.DiseaseID);
            return View(contraIndication);
        }

        // GET: Admin/ContraIndication/Edit/5
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contraIndication = await _context.ContraIndications.FindAsync(id);
            if (contraIndication == null)
            {
                return NotFound();
            }
            ViewData["ActiveIngredientID"] = new SelectList(_context.ActiveIngredients, "ActiveIngredientID", "ActiveIngredientID", contraIndication.ActiveIngredientID);
            ViewData["DiseaseID"] = new SelectList(_context.Disease, "DiseaseID", "DiseaseID", contraIndication.DiseaseID);
            return View(contraIndication);
        }

        // POST: Admin/ContraIndication/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContraIndicationID,ActiveIngredientID,DiseaseID")] ContraIndication contraIndication)
        {
            if (id != contraIndication.ContraIndicationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contraIndication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContraIndicationExists(contraIndication.ContraIndicationID))
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
            ViewData["ActiveIngredientID"] = new SelectList(_context.ActiveIngredients, "ActiveIngredientID", "ActiveIngredientID", contraIndication.ActiveIngredientID);
            ViewData["DiseaseID"] = new SelectList(_context.Disease, "DiseaseID", "DiseaseID", contraIndication.DiseaseID);
            return View(contraIndication);
        }

        // GET: Admin/ContraIndication/Delete/5
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contraIndication = await _context.ContraIndications
                .Include(c => c.ActiveIngredient)
                .Include(c => c.Disease)
                .FirstOrDefaultAsync(m => m.ContraIndicationID == id);
            if (contraIndication == null)
            {
                return NotFound();
            }

            return View(contraIndication);
        }

        // POST: Admin/ContraIndication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contraIndication = await _context.ContraIndications.FindAsync(id);
            _context.ContraIndications.Remove(contraIndication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContraIndicationExists(int id)
        {
            return _context.ContraIndications.Any(e => e.ContraIndicationID == id);
        }
    }
}
