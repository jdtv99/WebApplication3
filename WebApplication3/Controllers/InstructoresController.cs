using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class InstructoresController : Controller
    {
        private readonly Prueba01Context _context;

        public InstructoresController(Prueba01Context context)
        {
            _context = context;
        }

        // GET: Instructores
        public async Task<IActionResult> Index()
        {
              return _context.Instructores != null ? 
                          View(await _context.Instructores.ToListAsync()) :
                          Problem("Entity set 'Prueba01Context.Instructores'  is null.");
        }

        // GET: Instructores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Instructores == null)
            {
                return NotFound();
            }

            var instructore = await _context.Instructores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instructore == null)
            {
                return NotFound();
            }

            return View(instructore);
        }

        // GET: Instructores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instructores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apaterno,UrlFoto,HoraClase,CodigoInstruc,Genero")] Instructore instructore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instructore);
        }

        // GET: Instructores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Instructores == null)
            {
                return NotFound();
            }

            var instructore = await _context.Instructores.FindAsync(id);
            if (instructore == null)
            {
                return NotFound();
            }
            return View(instructore);
        }

        // POST: Instructores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apaterno,UrlFoto,HoraClase,CodigoInstruc,Genero")] Instructore instructore)
        {
            if (id != instructore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructoreExists(instructore.Id))
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
            return View(instructore);
        }

        // GET: Instructores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Instructores == null)
            {
                return NotFound();
            }

            var instructore = await _context.Instructores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instructore == null)
            {
                return NotFound();
            }

            return View(instructore);
        }

        // POST: Instructores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Instructores == null)
            {
                return Problem("Entity set 'Prueba01Context.Instructores'  is null.");
            }
            var instructore = await _context.Instructores.FindAsync(id);
            if (instructore != null)
            {
                _context.Instructores.Remove(instructore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructoreExists(int id)
        {
          return (_context.Instructores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
