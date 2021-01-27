using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageMVC;
using GarageMVC.DataAccess.BusinessModel;

namespace WebAppGarage.Controllers
{
    public class VeloController : Controller
    {
        private readonly GarageDbContext _context;

        public VeloController(GarageDbContext context)
        {
            _context = context;
        }

        // GET: Velo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Velos.ToListAsync());
        }

        // GET: Velo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var velo = await _context.Velos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (velo == null)
            {
                return NotFound();
            }

            return View(velo);
        }

        // GET: Velo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Velo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Proprietaire,Marque,Modele")] Velo velo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(velo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(velo);
        }

        // GET: Velo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var velo = await _context.Velos.FindAsync(id);
            if (velo == null)
            {
                return NotFound();
            }
            return View(velo);
        }

        // POST: Velo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Proprietaire,Marque,Modele")] Velo velo)
        {
            if (id != velo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(velo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeloExists(velo.Id))
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
            return View(velo);
        }

        // GET: Velo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var velo = await _context.Velos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (velo == null)
            {
                return NotFound();
            }

            return View(velo);
        }

        // POST: Velo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var velo = await _context.Velos.FindAsync(id);
            _context.Velos.Remove(velo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeloExists(int id)
        {
            return _context.Velos.Any(e => e.Id == id);
        }
    }
}
