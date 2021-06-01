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
    public class MesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mes.ToListAsync());
        }

        // GET: Mes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mes = await _context.Mes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mes == null)
            {
                return NotFound();
            }

            return View(mes);
        }

        // GET: Mes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao,NumeroMes")] Mes mes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mes);
        }

        // GET: Mes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mes = await _context.Mes.FindAsync(id);
            if (mes == null)
            {
                return NotFound();
            }
            return View(mes);
        }

        // POST: Mes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao,NumeroMes")] Mes mes)
        {
            if (id != mes.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MesExists(mes.ID))
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
            return View(mes);
        }

        // GET: Mes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mes = await _context.Mes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mes == null)
            {
                return NotFound();
            }

            return View(mes);
        }

        // POST: Mes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mes = await _context.Mes.FindAsync(id);
            _context.Mes.Remove(mes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MesExists(int id)
        {
            return _context.Mes.Any(e => e.ID == id);
        }
    }
}
