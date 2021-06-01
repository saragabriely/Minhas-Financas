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
    public class TipoMercadoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoMercadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoMercado
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoMercado.ToListAsync());
        }

        // GET: TipoMercado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMercado = await _context.TipoMercado
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoMercado == null)
            {
                return NotFound();
            }

            return View(tipoMercado);
        }

        // GET: TipoMercado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMercado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,descricao,observacao")] TipoMercado tipoMercado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMercado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMercado);
        }

        // GET: TipoMercado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMercado = await _context.TipoMercado.FindAsync(id);
            if (tipoMercado == null)
            {
                return NotFound();
            }
            return View(tipoMercado);
        }

        // POST: TipoMercado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,descricao,observacao")] TipoMercado tipoMercado)
        {
            if (id != tipoMercado.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMercado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMercadoExists(tipoMercado.ID))
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
            return View(tipoMercado);
        }

        // GET: TipoMercado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMercado = await _context.TipoMercado
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoMercado == null)
            {
                return NotFound();
            }

            return View(tipoMercado);
        }

        // POST: TipoMercado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoMercado = await _context.TipoMercado.FindAsync(id);
            _context.TipoMercado.Remove(tipoMercado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMercadoExists(int id)
        {
            return _context.TipoMercado.Any(e => e.ID == id);
        }
    }
}
