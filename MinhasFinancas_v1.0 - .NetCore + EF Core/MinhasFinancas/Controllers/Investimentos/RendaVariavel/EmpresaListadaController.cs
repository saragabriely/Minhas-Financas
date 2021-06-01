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
    public class EmpresaListadaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpresaListadaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmpresaListada
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmpresaListada.Include(e => e.SetorEmpresa);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmpresaListada/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaListada = await _context.EmpresaListada
                .Include(e => e.SetorEmpresa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (empresaListada == null)
            {
                return NotFound();
            }

            return View(empresaListada);
        }

        // GET: EmpresaListada/Create
        public IActionResult Create()
        {
            ViewData["SetorEmpresaID"] = new SelectList(_context.SetorEmpresa.OrderBy(p => p.descricao), "ID", "descricao");
            return View();
        }

        // POST: EmpresaListada/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NomeDePregao,CodigoAcao,SetorEmpresaID")] EmpresaListada empresaListada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresaListada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SetorEmpresaID"] = new SelectList(_context.SetorEmpresa, "ID", "ID", empresaListada.SetorEmpresaID);
            return View(empresaListada);
        }

        // GET: EmpresaListada/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaListada = await _context.EmpresaListada.FindAsync(id);
            if (empresaListada == null)
            {
                return NotFound();
            }
            ViewData["SetorEmpresaID"] = new SelectList(_context.SetorEmpresa, "ID", "ID", empresaListada.SetorEmpresaID);
            return View(empresaListada);
        }

        // POST: EmpresaListada/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NomeDePregao,CodigoAcao,SetorEmpresaID")] EmpresaListada empresaListada)
        {
            if (id != empresaListada.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresaListada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaListadaExists(empresaListada.ID))
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
            ViewData["SetorEmpresaID"] = new SelectList(_context.SetorEmpresa, "ID", "ID", empresaListada.SetorEmpresaID);
            return View(empresaListada);
        }

        // GET: EmpresaListada/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaListada = await _context.EmpresaListada
                .Include(e => e.SetorEmpresa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (empresaListada == null)
            {
                return NotFound();
            }

            return View(empresaListada);
        }

        // POST: EmpresaListada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresaListada = await _context.EmpresaListada.FindAsync(id);
            _context.EmpresaListada.Remove(empresaListada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaListadaExists(int id)
        {
            return _context.EmpresaListada.Any(e => e.ID == id);
        }
    }
}
