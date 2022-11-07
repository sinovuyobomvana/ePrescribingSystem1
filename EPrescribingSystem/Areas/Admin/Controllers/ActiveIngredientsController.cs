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
    public class ActiveIngredientsController : Controller
    {
        private readonly EprescribingDBContext _context;

        public ActiveIngredientsController(EprescribingDBContext context)
        {
            _context = context;
        }

        // GET: Admin/ActiveIngredients
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActiveIngredients.ToListAsync());
        }

        // GET: Admin/ActiveIngredients/Details/5
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeIngredient = await _context.ActiveIngredients
                .FirstOrDefaultAsync(m => m.ActiveIngredientID == id);
            if (activeIngredient == null)
            {
                return NotFound();
            }

            return View(activeIngredient);
        }

        // GET: Admin/ActiveIngredients/Create
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ActiveIngredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(ActiveIngredient activeIngredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activeIngredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activeIngredient);
        }

        // GET: Admin/ActiveIngredients/Edit/5
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeIngredient = await _context.ActiveIngredients.FindAsync(id);
            if (activeIngredient == null)
            {
                return NotFound();
            }
            return View(activeIngredient);
        }

        // POST: Admin/ActiveIngredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActiveIngredientID,Name")] ActiveIngredient activeIngredient)
        {
            if (id != activeIngredient.ActiveIngredientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activeIngredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActiveIngredientExists(activeIngredient.ActiveIngredientID))
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
            return View(activeIngredient);
        }
        [HttpGet]
        // GET: Admin/ActiveIngredients/Delete/5
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeIngredient = await _context.ActiveIngredients
                .FirstOrDefaultAsync(m => m.ActiveIngredientID == id);
            if (activeIngredient == null)
            {
                return NotFound();
            }

            return View(activeIngredient);
        }

        // POST: Admin/ActiveIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activeIngredient = await _context.ActiveIngredients.FindAsync(id);
            _context.ActiveIngredients.Remove(activeIngredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActiveIngredientExists(int id)
        {
            return _context.ActiveIngredients.Any(e => e.ActiveIngredientID == id);
        }
    }
}
