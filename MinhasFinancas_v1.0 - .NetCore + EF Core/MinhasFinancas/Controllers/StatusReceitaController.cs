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
    public class StatusReceitaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatusReceitaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StatusReceita
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusReceita.ToListAsync());
        }

        // GET: StatusReceita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusReceita = await _context.StatusReceita
                .FirstOrDefaultAsync(m => m.ID == id);
            if (statusReceita == null)
            {
                return NotFound();
            }

            return View(statusReceita);
        }

        // GET: StatusReceita/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusReceita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao")] StatusReceita statusReceita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusReceita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusReceita);
        }

        // GET: StatusReceita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusReceita = await _context.StatusReceita.FindAsync(id);
            if (statusReceita == null)
            {
                return NotFound();
            }
            return View(statusReceita);
        }

        // POST: StatusReceita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao")] StatusReceita statusReceita)
        {
            if (id != statusReceita.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusReceita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusReceitaExists(statusReceita.ID))
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
            return View(statusReceita);
        }

        // GET: StatusReceita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusReceita = await _context.StatusReceita
                .FirstOrDefaultAsync(m => m.ID == id);
            if (statusReceita == null)
            {
                return NotFound();
            }

            return View(statusReceita);
        }

        // POST: StatusReceita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusReceita = await _context.StatusReceita.FindAsync(id);
            _context.StatusReceita.Remove(statusReceita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusReceitaExists(int id)
        {
            return _context.StatusReceita.Any(e => e.ID == id);
        }
    }
}
