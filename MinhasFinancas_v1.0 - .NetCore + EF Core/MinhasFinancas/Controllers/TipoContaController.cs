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
    public class TipoContaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoContaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoConta
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoConta.ToListAsync());
        }

        // GET: TipoConta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConta = await _context.TipoConta
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoConta == null)
            {
                return NotFound();
            }

            return View(tipoConta);
        }

        // GET: TipoConta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoConta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao")] TipoConta tipoConta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoConta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoConta);
        }

        // GET: TipoConta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConta = await _context.TipoConta.FindAsync(id);
            if (tipoConta == null)
            {
                return NotFound();
            }
            return View(tipoConta);
        }

        // POST: TipoConta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao")] TipoConta tipoConta)
        {
            if (id != tipoConta.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoConta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoContaExists(tipoConta.ID))
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
            return View(tipoConta);
        }

        // GET: TipoConta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConta = await _context.TipoConta
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoConta == null)
            {
                return NotFound();
            }

            return View(tipoConta);
        }

        // POST: TipoConta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoConta = await _context.TipoConta.FindAsync(id);
            _context.TipoConta.Remove(tipoConta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoContaExists(int id)
        {
            return _context.TipoConta.Any(e => e.ID == id);
        }
    }
}
