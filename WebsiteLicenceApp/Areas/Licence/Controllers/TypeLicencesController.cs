using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebsiteLicenceApp.Areas.Licence.Models;
using WebsiteLicenceApp.Data;

namespace WebsiteLicenceApp.Areas.Licence.Controllers
{
    
    [Area("Licence")]
    public class TypeLicencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeLicencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Licence/TypeLicences
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeLicences.ToListAsync());
        }

        // GET: Licence/TypeLicences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeLicences = await _context.TypeLicences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeLicences == null)
            {
                return NotFound();
            }

            return View(typeLicences);
        }

        // GET: Licence/TypeLicences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Licence/TypeLicences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Month")] TypeLicences typeLicences)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeLicences);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeLicences);
        }

        // GET: Licence/TypeLicences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeLicences = await _context.TypeLicences.FindAsync(id);
            if (typeLicences == null)
            {
                return NotFound();
            }
            return View(typeLicences);
        }

        // POST: Licence/TypeLicences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Month")] TypeLicences typeLicences)
        {
            if (id != typeLicences.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeLicences);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeLicencesExists(typeLicences.Id))
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
            return View(typeLicences);
        }

        // GET: Licence/TypeLicences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeLicences = await _context.TypeLicences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeLicences == null)
            {
                return NotFound();
            }

            return View(typeLicences);
        }

        // POST: Licence/TypeLicences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeLicences = await _context.TypeLicences.FindAsync(id);
            _context.TypeLicences.Remove(typeLicences);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeLicencesExists(int id)
        {
            return _context.TypeLicences.Any(e => e.Id == id);
        }
    }
}
