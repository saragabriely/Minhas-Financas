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
    public class TipoInvestimentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoInvestimentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoInvestimento
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoInvestimento.ToListAsync());
        }

        // GET: TipoInvestimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInvestimento = await _context.TipoInvestimento
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoInvestimento == null)
            {
                return NotFound();
            }

            return View(tipoInvestimento);
        }

        // GET: TipoInvestimento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoInvestimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao")] TipoInvestimento tipoInvestimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoInvestimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoInvestimento);
        }

        // GET: TipoInvestimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInvestimento = await _context.TipoInvestimento.FindAsync(id);
            if (tipoInvestimento == null)
            {
                return NotFound();
            }
            return View(tipoInvestimento);
        }

        // POST: TipoInvestimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao")] TipoInvestimento tipoInvestimento)
        {
            if (id != tipoInvestimento.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoInvestimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoInvestimentoExists(tipoInvestimento.ID))
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
            return View(tipoInvestimento);
        }

        // GET: TipoInvestimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInvestimento = await _context.TipoInvestimento
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoInvestimento == null)
            {
                return NotFound();
            }

            return View(tipoInvestimento);
        }

        // POST: TipoInvestimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoInvestimento = await _context.TipoInvestimento.FindAsync(id);
            _context.TipoInvestimento.Remove(tipoInvestimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoInvestimentoExists(int id)
        {
            return _context.TipoInvestimento.Any(e => e.ID == id);
        }
    }
}
