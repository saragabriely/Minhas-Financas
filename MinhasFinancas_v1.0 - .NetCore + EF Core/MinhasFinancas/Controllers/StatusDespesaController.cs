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
    public class StatusDespesaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatusDespesaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StatusDespesa
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusDespesa.ToListAsync());
        }

        // GET: StatusDespesa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusDespesa = await _context.StatusDespesa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (statusDespesa == null)
            {
                return NotFound();
            }

            return View(statusDespesa);
        }

        // GET: StatusDespesa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusDespesa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao")] StatusDespesa statusDespesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusDespesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusDespesa);
        }

        // GET: StatusDespesa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusDespesa = await _context.StatusDespesa.FindAsync(id);
            if (statusDespesa == null)
            {
                return NotFound();
            }
            return View(statusDespesa);
        }

        // POST: StatusDespesa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao")] StatusDespesa statusDespesa)
        {
            if (id != statusDespesa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusDespesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusDespesaExists(statusDespesa.ID))
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
            return View(statusDespesa);
        }

        // GET: StatusDespesa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusDespesa = await _context.StatusDespesa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (statusDespesa == null)
            {
                return NotFound();
            }

            return View(statusDespesa);
        }

        // POST: StatusDespesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusDespesa = await _context.StatusDespesa.FindAsync(id);
            _context.StatusDespesa.Remove(statusDespesa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusDespesaExists(int id)
        {
            return _context.StatusDespesa.Any(e => e.ID == id);
        }
    }
}
