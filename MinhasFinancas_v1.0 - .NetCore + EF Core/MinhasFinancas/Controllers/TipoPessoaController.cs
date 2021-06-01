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
    public class TipoPessoaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoPessoaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoPessoa
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoPessoa.ToListAsync());
        }

        // GET: TipoPessoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPessoa = await _context.TipoPessoa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoPessoa == null)
            {
                return NotFound();
            }

            return View(tipoPessoa);
        }

        // GET: TipoPessoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TiID,Descricao")] TipoPessoa tipoPessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPessoa);
        }

        // GET: TipoPessoa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPessoa = await _context.TipoPessoa.FindAsync(id);
            if (tipoPessoa == null)
            {
                return NotFound();
            }
            return View(tipoPessoa);
        }

        // POST: TipoPessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao")] TipoPessoa tipoPessoa)
        {
            if (id != tipoPessoa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPessoaExists(tipoPessoa.ID))
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
            return View(tipoPessoa);
        }

        // GET: TipoPessoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPessoa = await _context.TipoPessoa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoPessoa == null)
            {
                return NotFound();
            }

            return View(tipoPessoa);
        }

        // POST: TipoPessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPessoa = await _context.TipoPessoa.FindAsync(id);
            _context.TipoPessoa.Remove(tipoPessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPessoaExists(int id)
        {
            return _context.TipoPessoa.Any(e => e.ID == id);
        }

        public List<TipoPessoa> Obter()
        {
            return _context.TipoPessoa.ToList();
        }

        public TipoPessoa obter(int tipoPessoa)
        {
            return _context.TipoPessoa.Where(e => e.ID == tipoPessoa).FirstOrDefault();
        }
    }
}
