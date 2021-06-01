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
    public class PessoaController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public PessoaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pessoa
        public async Task<IActionResult> Index(string NomePesquisa, int? TpPessoa)
        {
            TpPessoa = TpPessoa == null ? TipoPessoa.Todos : TpPessoa;

            ViewData["TpPessoa"] = new SelectList(_context.TipoPessoa.OrderBy(p => p.Descricao), "ID", "Descricao", TpPessoa);

            var application = _context.Pessoa.OrderBy(p => p.nome).ToList();
            
            if (TpPessoa != TipoPessoa.Todos)
            {
                application = application.Where(p => p.TipoPessoaID == TpPessoa).ToList();
            }

            if (NomePesquisa != null)
            {
                application = application.Where(p => p.nome.Contains(NomePesquisa)).ToList();
            }

            TipoPessoaController tipoPessoaController = new TipoPessoaController(_context);

            foreach (Pessoa item in application)
            {
                item.TipoPessoa = tipoPessoaController.obter(item.TipoPessoaID);
            }

            return View(application);
        }

        // GET: Pessoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa.FirstOrDefaultAsync(m => m.Pessoa_ID == id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoa/Create
        public IActionResult Create()
        {
            TipoPessoaController tipoPessoa = new TipoPessoaController(_context);

            var lstTipoPessoa = tipoPessoa.Obter();
            
            ViewBag.LstTipoPessoa = lstTipoPessoa;
            
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pessoa_ID,nome,documento,dataCadastro,dataUltimaAlteracao, TipoPessoaID,flagCadastroAtivo")] Pessoa pessoa)
        {
            TipoPessoaController tipController = new TipoPessoaController(_context);
            
            pessoa.dataCadastro        = DateTime.Now;
            pessoa.dataUltimaAlteracao = DateTime.Now;
            pessoa.TipoPessoa          = tipController.obter(pessoa.TipoPessoaID);
            
            if (ModelState.IsValid)
            {
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            var tipoPessoa = ObterModeloTipoPessoa(pessoa.TipoPessoaID);
            ViewBag.TipoPessoaID = tipoPessoa.ID;
            ViewBag.TipoPessoa = tipoPessoa.Descricao;
            
            var listaTipoPessoa = (await _context.TipoPessoa.ToListAsync()).Where(p => p.ID != id);
            
            ViewBag.LstTipoPessoa = listaTipoPessoa != null || listaTipoPessoa.Count() > 0 ? listaTipoPessoa : null;

            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pessoa_ID,nome,documento,dataUltimaAlteracao, TipoPessoaID,flagCadastroAtivo")] Pessoa pessoa)
        {
            var pessoaAux = obter(id);
            
            if (pessoaAux == null) //if (id != pessoa.Pessoa_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    pessoa.dataCadastro        = pessoaAux.dataCadastro; 
                    pessoa.dataUltimaAlteracao = DateTime.Now;
                    pessoa.TipoPessoa          = ObterModeloTipoPessoa(pessoa.TipoPessoaID);

                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.Pessoa_ID))
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
            return View(pessoa);
        }

        private TipoPessoa ObterModeloTipoPessoa(int tipoPessoaID)
        {
            TipoPessoaController tipoPessoaCtrlr = new TipoPessoaController(_context);

            return tipoPessoaCtrlr.obter(tipoPessoaID);
        }

        // GET: Pessoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.Pessoa_ID == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);
            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.Pessoa_ID == id);
        }

        public Pessoa obter(int id)
        {
            return _context.Pessoa.AsNoTracking().Where(e => e.Pessoa_ID == id).FirstOrDefault();
        }
    }
}
