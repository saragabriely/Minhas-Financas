using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.ClassesAuxiliares;
using MinhasFinancas.Data;
using MinhasFinancas.Models;

namespace MinhasFinancas.Controllers
{
    public class ContaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conta
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Conta.Include(c => c.Pessoa).Include(c => c.TipoConta);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Conta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conta = await _context.Conta
                .Include(c => c.Pessoa)
                .Include(c => c.TipoConta)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (conta == null)
            {
                return NotFound();
            }

            return View(conta);
        }

        // GET: Conta/Create
        public IActionResult Create()
        {
            ViewData["PessoaID"] = new SelectList(_context.Pessoa.Where(p => p.TipoPessoaID == TipoPessoa.BancoCorretora).OrderBy(p => p.nome), "Pessoa_ID", "nome");
            ViewData["TipoContaID"] = new SelectList(_context.TipoConta, "ID", "Descricao");
            return View();
        }

        // POST: Conta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Agencia,ContaBancaria,SaldoEmConta,PessoaID,TipoContaID,DataCadastro,DataUltimaAtualizacao,flagAtivo")] Conta conta)
        {
            conta.DataCadastro = conta.DataUltimaAtualizacao = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(conta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaID"] = new SelectList(_context.Pessoa, "Pessoa_ID", "nome", conta.PessoaID);
            ViewData["TipoContaID"] = new SelectList(_context.TipoConta, "ID", "Descricao", conta.TipoContaID);
            return View(conta);
        }

        // GET: Conta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conta = await _context.Conta.FindAsync(id);
            if (conta == null)
            {
                return NotFound();
            }
            ViewData["PessoaID"] = 
                new SelectList(_context.Pessoa.Where(p => p.TipoPessoaID == TipoPessoa.BancoCorretora).OrderBy(p => p.nome), "Pessoa_ID", "nome", conta.PessoaID);

            ViewData["TipoContaID"] = new SelectList(_context.TipoConta, "ID", "Descricao", conta.TipoContaID);

            return View(conta);
        }

        // POST: Conta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Agencia,ContaBancaria,SaldoEmConta,PessoaID,TipoContaID,DataCadastro,DataUltimaAtualizacao,flagAtivo")] Conta conta)
        {
            if (id != conta.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    conta.DataCadastro = obter(conta.ID).DataCadastro;
                    conta.DataUltimaAtualizacao = DateTime.Now;

                    _context.Update(conta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaExists(conta.ID))  return NotFound();

                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaID"] = 
                new SelectList(_context.Pessoa.Where(p => p.TipoPessoaID == TipoPessoa.BancoCorretora).OrderBy(p => p.nome), "Pessoa_ID", "nome", conta.PessoaID);

            ViewData["TipoContaID"] = new SelectList(_context.TipoConta, "ID", "Descricao", conta.TipoContaID);

            return View(conta);
        }

        // GET: Conta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var conta = await _context.Conta
                .Include(c => c.Pessoa)
                .Include(c => c.TipoConta)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (conta == null)  return NotFound();

            return View(conta);
        }

        // POST: Conta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conta = await _context.Conta.FindAsync(id);
            _context.Conta.Remove(conta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaExists(int id)
        {
            return _context.Conta.Any(e => e.ID == id);
        }

        public Conta obter(int id)
        {
            return _context.Conta.AsNoTracking().Where(e => e.ID == id).FirstOrDefault();
        }
    }
}
