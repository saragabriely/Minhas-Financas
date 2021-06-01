using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Data;
using MinhasFinancas.Models.Investimentos.RendaVariavel;

namespace MinhasFinancas.Controllers.Investimentos.RendaVariavel
{
    public class TipoMovimentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoMovimentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoMovimento
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoMovimento.ToListAsync());
        }

        // GET: TipoMovimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimento = await _context.TipoMovimento
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoMovimento == null)
            {
                return NotFound();
            }

            return View(tipoMovimento);
        }

        // GET: TipoMovimento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMovimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao")] TipoMovimento tipoMovimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMovimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMovimento);
        }

        // GET: TipoMovimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimento = await _context.TipoMovimento.FindAsync(id);
            if (tipoMovimento == null)
            {
                return NotFound();
            }
            return View(tipoMovimento);
        }

        // POST: TipoMovimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao")] TipoMovimento tipoMovimento)
        {
            if (id != tipoMovimento.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMovimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMovimentoExists(tipoMovimento.ID))
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
            return View(tipoMovimento);
        }

        // GET: TipoMovimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimento = await _context.TipoMovimento
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoMovimento == null)
            {
                return NotFound();
            }

            return View(tipoMovimento);
        }

        // POST: TipoMovimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoMovimento = await _context.TipoMovimento.FindAsync(id);
            _context.TipoMovimento.Remove(tipoMovimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMovimentoExists(int id)
        {
            return _context.TipoMovimento.Any(e => e.ID == id);
        }
    }
}
