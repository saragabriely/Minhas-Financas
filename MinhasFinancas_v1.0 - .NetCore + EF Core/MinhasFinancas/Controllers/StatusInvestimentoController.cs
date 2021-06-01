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
    public class StatusInvestimentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatusInvestimentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StatusInvestimento
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusInvestimento.ToListAsync());
        }

        // GET: StatusInvestimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusInvestimento = await _context.StatusInvestimento
                .FirstOrDefaultAsync(m => m.ID == id);
            if (statusInvestimento == null)
            {
                return NotFound();
            }

            return View(statusInvestimento);
        }

        // GET: StatusInvestimento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusInvestimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao")] StatusInvestimento statusInvestimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusInvestimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusInvestimento);
        }

        // GET: StatusInvestimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusInvestimento = await _context.StatusInvestimento.FindAsync(id);
            if (statusInvestimento == null)
            {
                return NotFound();
            }
            return View(statusInvestimento);
        }

        // POST: StatusInvestimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao")] StatusInvestimento statusInvestimento)
        {
            if (id != statusInvestimento.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusInvestimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusInvestimentoExists(statusInvestimento.ID))
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
            return View(statusInvestimento);
        }

        // GET: StatusInvestimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusInvestimento = await _context.StatusInvestimento
                .FirstOrDefaultAsync(m => m.ID == id);
            if (statusInvestimento == null)
            {
                return NotFound();
            }

            return View(statusInvestimento);
        }

        // POST: StatusInvestimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusInvestimento = await _context.StatusInvestimento.FindAsync(id);
            _context.StatusInvestimento.Remove(statusInvestimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusInvestimentoExists(int id)
        {
            return _context.StatusInvestimento.Any(e => e.ID == id);
        }
    }
}
