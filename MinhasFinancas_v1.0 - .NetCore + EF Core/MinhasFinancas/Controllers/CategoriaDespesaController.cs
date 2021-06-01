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
    public class CategoriaDespesaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaDespesaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaDespesa
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaDespesa.ToListAsync());
        }

        // GET: CategoriaDespesa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaDespesa = await _context.CategoriaDespesa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (categoriaDespesa == null)
            {
                return NotFound();
            }

            return View(categoriaDespesa);
        }

        // GET: CategoriaDespesa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaDespesa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao,PorcentagemIdeal")] CategoriaDespesa categoriaDespesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaDespesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDespesa);
        }

        // GET: CategoriaDespesa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaDespesa = await _context.CategoriaDespesa.FindAsync(id);
            if (categoriaDespesa == null)
            {
                return NotFound();
            }
            return View(categoriaDespesa);
        }

        // POST: CategoriaDespesa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao,PorcentagemIdeal")] CategoriaDespesa categoriaDespesa)
        {
            if (id != categoriaDespesa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaDespesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaDespesaExists(categoriaDespesa.ID))
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
            return View(categoriaDespesa);
        }

        // GET: CategoriaDespesa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaDespesa = await _context.CategoriaDespesa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (categoriaDespesa == null)
            {
                return NotFound();
            }

            return View(categoriaDespesa);
        }

        // POST: CategoriaDespesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaDespesa = await _context.CategoriaDespesa.FindAsync(id);
            _context.CategoriaDespesa.Remove(categoriaDespesa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaDespesaExists(int id)
        {
            return _context.CategoriaDespesa.Any(e => e.ID == id);
        }

        public CategoriaDespesa obter(int id)
        {
            return _context.CategoriaDespesa.AsNoTracking().Where(e => e.ID == id).FirstOrDefault();
        }

        public CategoriaDespesa obter(string descricao)
        {
            return _context.CategoriaDespesa.AsNoTracking().Where(e => e.Descricao == descricao).FirstOrDefault();
        }
    }
}
