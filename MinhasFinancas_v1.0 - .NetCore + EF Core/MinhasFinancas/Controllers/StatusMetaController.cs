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
    public class StatusMetaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatusMetaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StatusMeta
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusMeta.ToListAsync());
        }

        // GET: StatusMeta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusMeta = await _context.StatusMeta
                .FirstOrDefaultAsync(m => m.ID == id);
            if (statusMeta == null)
            {
                return NotFound();
            }

            return View(statusMeta);
        }

        // GET: StatusMeta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusMeta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao")] StatusMeta statusMeta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusMeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusMeta);
        }

        // GET: StatusMeta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusMeta = await _context.StatusMeta.FindAsync(id);
            if (statusMeta == null)
            {
                return NotFound();
            }
            return View(statusMeta);
        }

        // POST: StatusMeta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao")] StatusMeta statusMeta)
        {
            if (id != statusMeta.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusMeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusMetaExists(statusMeta.ID))
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
            return View(statusMeta);
        }

        // GET: StatusMeta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusMeta = await _context.StatusMeta
                .FirstOrDefaultAsync(m => m.ID == id);
            if (statusMeta == null)
            {
                return NotFound();
            }

            return View(statusMeta);
        }

        // POST: StatusMeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusMeta = await _context.StatusMeta.FindAsync(id);
            _context.StatusMeta.Remove(statusMeta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusMetaExists(int id)
        {
            return _context.StatusMeta.Any(e => e.ID == id);
        }
    }
}
