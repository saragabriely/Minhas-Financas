using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Data;
using MinhasFinancas.Models;
using MinhasFinancas.Models.Investimentos.RendaVariavel;

namespace MinhasFinancas.Controllers.Investimentos.RendaVariavel
{
    public class AcaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Acao
        public async Task<IActionResult> Index(int? Ano, int? Mes, string BancoCorretora, string CodAcao)
        {
            var mesAtual       = Mes != null ? (int)Mes : DateTime.Now.Month;
            var anoAtual       = Ano != null ? (int)Ano : DateTime.Now.Year;
            var codigoAcao     = CodAcao ?? "0";
            var bancoCorretora = BancoCorretora ?? "0";

            ViewData["Ano"]            = new SelectList(_context.Ano.OrderBy(p => p.Descricao), "Descricao", "Descricao", anoAtual);
            ViewData["Mes"]            = new SelectList(_context.Mes.OrderBy(p => p.NumeroMes), "NumeroMes", "Descricao", mesAtual);
            ViewData["CodAcao"]        = new SelectList(_context.EmpresaListada.OrderBy(p => p.CodigoAcao), "CodigoAcao", "CodigoAcao", codigoAcao);
            ViewData["BancoCorretora"] = new SelectList(_context.Pessoa.Where(p => p.TipoPessoaID == TipoPessoa.BancoCorretora).OrderBy(p => p.nome),
                                                                                "Pessoa_ID", "nome", bancoCorretora);

            var application = _context.Acao.Include(a => a.EmpresaListada).Include(a => a.Pessoa).Include(a => a.TipoMercado).Include(a => a.TipoMovimento).ToList();

            if (Ano > 0 || Ano == null)
            {
                application = application.Where(p => Convert.ToDateTime(p.DataNegociacao).Year == anoAtual).ToList();
            }

            if (Mes > 0 || Mes == null)
            {
                application = application.Where(p => Convert.ToDateTime(p.DataNegociacao).Month == mesAtual).ToList();
            }

            if (codigoAcao != "0")
            {
                application = application.Where(p => p.EmpresaListada.CodigoAcao == codigoAcao).ToList();
            }

            if (bancoCorretora != "0")
            {
                application = application.Where(p => p.Pessoa.Pessoa_ID == Convert.ToInt32(bancoCorretora)).ToList();
            }
            
            return View(application);

            /*
             var applicationDbContext = _context.Acao.Include(a => a.EmpresaListada).Include(a => a.Pessoa).Include(a => a.TipoMercado).Include(a => a.TipoMovimento);
            return View(await applicationDbContext.ToListAsync());
             */
        }

        // GET: Acao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acao = await _context.Acao
                .Include(a => a.EmpresaListada)
                .Include(a => a.Pessoa)
                .Include(a => a.TipoMercado)
                .Include(a => a.TipoMovimento)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (acao == null)
            {
                return NotFound();
            }

            return View(acao);
        }

        // GET: Acao/Create
        public IActionResult Create()
        {
            ViewData["EmpresaListadaID"] = new SelectList(_context.EmpresaListada, "ID", "ID");
            ViewData["PessoaID"] = new SelectList(_context.Pessoa, "Pessoa_ID", "nome");
            ViewData["TipoMercadoID"] = new SelectList(_context.TipoMercado, "ID", "ID");
            ViewData["TipoMovimentoID"] = new SelectList(_context.TipoMovimento, "ID", "ID");
            return View();
        }

        // POST: Acao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DataNegociacao,ValorCompra,QuantidadeCompra,ValorCorretagem,ValorISS,EmpresaListadaID,TipoMercadoID,PessoaID,TipoMovimentoID")] Acao acao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaListadaID"] = new SelectList(_context.EmpresaListada, "ID", "ID", acao.EmpresaListadaID);
            ViewData["PessoaID"] = new SelectList(_context.Pessoa, "Pessoa_ID", "nome", acao.PessoaID);
            ViewData["TipoMercadoID"] = new SelectList(_context.TipoMercado, "ID", "ID", acao.TipoMercadoID);
            ViewData["TipoMovimentoID"] = new SelectList(_context.TipoMovimento, "ID", "ID", acao.TipoMovimentoID);
            return View(acao);
        }

        // GET: Acao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acao = await _context.Acao.FindAsync(id);
            if (acao == null)
            {
                return NotFound();
            }
            ViewData["EmpresaListadaID"] = new SelectList(_context.EmpresaListada, "ID", "ID", acao.EmpresaListadaID);
            ViewData["PessoaID"] = new SelectList(_context.Pessoa, "Pessoa_ID", "nome", acao.PessoaID);
            ViewData["TipoMercadoID"] = new SelectList(_context.TipoMercado, "ID", "ID", acao.TipoMercadoID);
            ViewData["TipoMovimentoID"] = new SelectList(_context.TipoMovimento, "ID", "ID", acao.TipoMovimentoID);
            return View(acao);
        }

        // POST: Acao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DataNegociacao,ValorCompra,QuantidadeCompra,ValorCorretagem,ValorISS,EmpresaListadaID,TipoMercadoID,PessoaID,TipoMovimentoID")] Acao acao)
        {
            if (id != acao.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcaoExists(acao.ID))
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
            ViewData["EmpresaListadaID"] = new SelectList(_context.EmpresaListada, "ID", "ID", acao.EmpresaListadaID);
            ViewData["PessoaID"] = new SelectList(_context.Pessoa, "Pessoa_ID", "nome", acao.PessoaID);
            ViewData["TipoMercadoID"] = new SelectList(_context.TipoMercado, "ID", "ID", acao.TipoMercadoID);
            ViewData["TipoMovimentoID"] = new SelectList(_context.TipoMovimento, "ID", "ID", acao.TipoMovimentoID);
            return View(acao);
        }

        // GET: Acao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acao = await _context.Acao
                .Include(a => a.EmpresaListada)
                .Include(a => a.Pessoa)
                .Include(a => a.TipoMercado)
                .Include(a => a.TipoMovimento)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (acao == null)
            {
                return NotFound();
            }

            return View(acao);
        }

        // POST: Acao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acao = await _context.Acao.FindAsync(id);
            _context.Acao.Remove(acao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcaoExists(int id)
        {
            return _context.Acao.Any(e => e.ID == id);
        }
    }
}
