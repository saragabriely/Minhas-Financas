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
    public class FormaRecebimentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormaRecebimentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FormaRecebimento
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormaRecebimento.ToListAsync());
        }

        // GET: FormaRecebimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaRecebimento = await _context.FormaRecebimento
                .FirstOrDefaultAsync(m => m.FormaRecebimento_ID == id);
            if (formaRecebimento == null)
            {
                return NotFound();
            }

            return View(formaRecebimento);
        }

        // GET: FormaRecebimento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormaRecebimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormaRecebimento_ID,Descricao")] FormaRecebimento formaRecebimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formaRecebimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formaRecebimento);
        }

        // GET: FormaRecebimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaRecebimento = await _context.FormaRecebimento.FindAsync(id);
            if (formaRecebimento == null)
            {
                return NotFound();
            }
            return View(formaRecebimento);
        }

        // POST: FormaRecebimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormaRecebimento_ID,Descricao")] FormaRecebimento formaRecebimento)
        {
            if (id != formaRecebimento.FormaRecebimento_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formaRecebimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormaRecebimentoExists(formaRecebimento.FormaRecebimento_ID))
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
            return View(formaRecebimento);
        }

        // GET: FormaRecebimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaRecebimento = await _context.FormaRecebimento
                .FirstOrDefaultAsync(m => m.FormaRecebimento_ID == id);
            if (formaRecebimento == null)
            {
                return NotFound();
            }

            return View(formaRecebimento);
        }

        // POST: FormaRecebimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formaRecebimento = await _context.FormaRecebimento.FindAsync(id);
            _context.FormaRecebimento.Remove(formaRecebimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormaRecebimentoExists(int id)
        {
            return _context.FormaRecebimento.Any(e => e.FormaRecebimento_ID == id);
        }
    }
}
