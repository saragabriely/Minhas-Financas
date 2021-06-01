using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Data;
using MinhasFinancas.Models;

namespace MinhasFinancas.Controllers
{
    public class TipoReceitaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoReceitaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoReceita
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoReceita.ToListAsync());
        }

        // GET: TipoReceita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoReceita = await _context.TipoReceita
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoReceita == null)
            {
                return NotFound();
            }

            return View(tipoReceita);
        }

        // GET: TipoReceita/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoReceita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao")] TipoReceita tipoReceita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoReceita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoReceita);
        }

        // GET: TipoReceita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoReceita = await _context.TipoReceita.FindAsync(id);
            if (tipoReceita == null)
            {
                return NotFound();
            }
            return View(tipoReceita);
        }

        // POST: TipoReceita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao")] TipoReceita tipoReceita)
        {
            if (id != tipoReceita.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoReceita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoReceitaExists(tipoReceita.ID))
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
            return View(tipoReceita);
        }

        // GET: TipoReceita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoReceita = await _context.TipoReceita
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoReceita == null)
            {
                return NotFound();
            }

            return View(tipoReceita);
        }

        // POST: TipoReceita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoReceita = await _context.TipoReceita.FindAsync(id);
            _context.TipoReceita.Remove(tipoReceita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoReceitaExists(int id)
        {
            return _context.TipoReceita.Any(e => e.ID == id);
        }
    }
}
