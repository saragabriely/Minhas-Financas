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
    public class AnoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ano
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ano.ToListAsync());
        }

        // GET: Ano/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ano = await _context.Ano
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ano == null)
            {
                return NotFound();
            }

            return View(ano);
        }

        // GET: Ano/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ano/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao")] Ano ano)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ano);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ano);
        }

        // GET: Ano/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ano = await _context.Ano.FindAsync(id);
            if (ano == null)
            {
                return NotFound();
            }
            return View(ano);
        }

        // POST: Ano/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao")] Ano ano)
        {
            if (id != ano.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ano);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnoExists(ano.ID))
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
            return View(ano);
        }

        // GET: Ano/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ano = await _context.Ano
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ano == null)
            {
                return NotFound();
            }

            return View(ano);
        }

        // POST: Ano/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ano = await _context.Ano.FindAsync(id);
            _context.Ano.Remove(ano);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnoExists(int id)
        {
            return _context.Ano.Any(e => e.ID == id);
        }
    }
}
