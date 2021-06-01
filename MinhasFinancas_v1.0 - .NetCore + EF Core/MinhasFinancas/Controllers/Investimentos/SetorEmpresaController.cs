using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Data;
using MinhasFinancas.Models.Investimentos.RendaVariavel;

namespace MinhasFinancas.Controllers.Investimentos
{
    public class SetorEmpresaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SetorEmpresaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SetorEmpresa
        public async Task<IActionResult> Index()
        {
            return View(await _context.SetorEmpresa.ToListAsync());
        }

        // GET: SetorEmpresa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setorEmpresa = await _context.SetorEmpresa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (setorEmpresa == null)
            {
                return NotFound();
            }

            return View(setorEmpresa);
        }

        // GET: SetorEmpresa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SetorEmpresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,descricao")] SetorEmpresa setorEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(setorEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(setorEmpresa);
        }

        // GET: SetorEmpresa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setorEmpresa = await _context.SetorEmpresa.FindAsync(id);
            if (setorEmpresa == null)
            {
                return NotFound();
            }
            return View(setorEmpresa);
        }

        // POST: SetorEmpresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,descricao")] SetorEmpresa setorEmpresa)
        {
            if (id != setorEmpresa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(setorEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetorEmpresaExists(setorEmpresa.ID))
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
            return View(setorEmpresa);
        }

        // GET: SetorEmpresa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setorEmpresa = await _context.SetorEmpresa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (setorEmpresa == null)
            {
                return NotFound();
            }

            return View(setorEmpresa);
        }

        // POST: SetorEmpresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var setorEmpresa = await _context.SetorEmpresa.FindAsync(id);
            _context.SetorEmpresa.Remove(setorEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SetorEmpresaExists(int id)
        {
            return _context.SetorEmpresa.Any(e => e.ID == id);
        }
    }
}
