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
    public class ReceitaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceitaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Receita
        public async Task<IActionResult> Index(int? Ano, int? Mes, int? StReceita, int? TpReceita)
        {
            var mesAtual = DateTime.Now.Month;
            var anoAtual = DateTime.Now.Year;
            StReceita = StReceita == null ? StatusReceita.Todos : StReceita;
            TpReceita = TpReceita == null ? TipoReceita.Todos : TpReceita;

            mesAtual = Mes != null ? (int)Mes : mesAtual;
            anoAtual = Ano != null ? (int)Ano : anoAtual;

            ViewData["Ano"] = new SelectList(_context.Ano.OrderBy(p => p.Descricao), "Descricao", "Descricao", anoAtual);
            ViewData["Mes"] = new SelectList(_context.Mes.OrderBy(p => p.NumeroMes), "NumeroMes", "Descricao", mesAtual);
            ViewData["StReceita"] = new SelectList(_context.StatusReceita.OrderBy(p => p.Descricao), "ID", "Descricao", StReceita);
            ViewData["TpReceita"] = new SelectList(_context.TipoReceita.OrderBy(p => p.Descricao),   "ID", "Descricao", TpReceita);

            var application = _context.Receita.Where(p => p.DataPrevistaRecebimento.Month == mesAtual && p.DataPrevistaRecebimento.Year == anoAtual);

            if (StReceita != StatusDespesa.Todos)
            {
                application = application.Where(p => p.StatusReceitaID == StReceita);
            }

            var applicationDbContext = application.Include(r => r.FormaRecebimento)
                                                  .Include(r => r.Pessoa)
                                                  .Include(r => r.StatusReceita)
                                                  .Include(r => r.TipoReceita);

            PopularTela(applicationDbContext);


            /*
            var applicationDbContext = _context.Receita.Include(r => r.FormaRecebimento)
                                                       .Include(r => r.Pessoa)
                                                       .Include(r => r.StatusReceita)
                                                       .Include(r => r.TipoReceita);
            */
            return View(await applicationDbContext.ToListAsync());
        }

        public List<Receita> CapturaReceitas(int? Ano, int? Mes, int? StReceita)
        {
            var mesAtual = DateTime.Now.Month;
            var anoAtual = DateTime.Now.Year;
            //StReceita = StReceita == null ? StatusReceita.Todos : StReceita;
            //TpReceita = TpReceita == null ? TipoReceita.Todos : TpReceita;

            mesAtual = Mes != null ? (int)Mes : mesAtual;
            anoAtual = Ano != null ? (int)Ano : anoAtual;

            ViewData["Ano"] = new SelectList(_context.Ano.OrderBy(p => p.Descricao), "Descricao", "Descricao", anoAtual);
            ViewData["Mes"] = new SelectList(_context.Mes.OrderBy(p => p.NumeroMes), "NumeroMes", "Descricao", mesAtual);
            //ViewData["StReceita"] = new SelectList(_context.StatusReceita.OrderBy(p => p.Descricao), "ID", "Descricao", StReceita);
            //ViewData["TpReceita"] = new SelectList(_context.TipoReceita.OrderBy(p => p.Descricao), "ID", "Descricao", TpReceita);

            var application = _context.Receita.Where(p => p.DataPrevistaRecebimento.Month == mesAtual && p.DataPrevistaRecebimento.Year == anoAtual);

            /*if (StReceita != StatusDespesa.Todos)
            {
                application = application.Where(p => p.StatusReceitaID == StReceita);
            }*/

            var applicationDbContext = application.Include(r => r.FormaRecebimento)
                                                  .Include(r => r.Pessoa)
                                                  .Include(r => r.StatusReceita)
                                                  .Include(r => r.TipoReceita);

            PopularTela(applicationDbContext);

            return applicationDbContext.ToList();
        }

        private void PopularTela(Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Receita, TipoReceita> applicationDbContext)
        {
            var lstValorAReceber = applicationDbContext.Select(p => Convert.ToDecimal(p.ValorAReceber.Replace(".", "").Replace(",", "."))).ToList();
            var lstValorRecebido = applicationDbContext.Select(p => Convert.ToDecimal(p.ValorRecebido.Replace(".", "").Replace(",", "."))).ToList();

            var totalAReceber = lstValorAReceber.Count() > 0 ? lstValorAReceber.Sum() : 0;
            var totalRecebido = lstValorRecebido.Count() > 0 ? lstValorRecebido.Sum() : 0;

            ViewData["NroTotalReceitas"]   = lstValorAReceber.Count().ToString();
            ViewData["ValorTotalAReceber"] = totalAReceber.ToString("C");
            ViewData["ValorTotalRecebido"] = totalRecebido.ToString("C");
            ViewData["ValorTotalPendente"] = (totalAReceber - totalRecebido).ToString("C");
        }

        // GET: Receita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita
                .Include(r => r.FormaRecebimento)
                .Include(r => r.Pessoa)
                .Include(r => r.StatusReceita)
                .Include(r => r.TipoReceita)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // GET: Receita/Create
        public IActionResult Create()
        {
            ViewData["FormaRecebimentoID"] = new SelectList(_context.FormaRecebimento.OrderBy(p => p.Descricao), "FormaRecebimento_ID", "Descricao");
            ViewData["PessoaID"]           = new SelectList(_context.Pessoa.OrderBy(p => p.nome), "Pessoa_ID", "nome");
            ViewData["StatusReceitaID"]    = new SelectList(_context.StatusReceita.OrderBy(p => p.Descricao), "ID", "Descricao");
            ViewData["TipoReceitaID"]      = new SelectList(_context.TipoReceita.OrderBy(p => p.Descricao), "ID", "Descricao");
            return View();
        }

        // POST: Receita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao,DataPrevistaRecebimento,DataDeRecebimento,ValorAReceber,ValorRecebido,FormaRecebimentoID,StatusReceitaID,PessoaID,DataCadastro,DataUltimaAtualizacao,TipoReceitaID")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                receita.DataCadastro = receita.DataUltimaAtualizacao = DateTime.Now;

                if (receita.ValorAReceber == null) receita.ValorAReceber = "0";
                if (receita.ValorRecebido == null) receita.ValorRecebido = "0";

                _context.Add(receita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormaRecebimentoID"] = new SelectList(_context.FormaRecebimento.OrderBy(p => p.Descricao), "FormaRecebimento_ID", "Descricao", receita.FormaRecebimentoID);
            ViewData["PessoaID"]           = new SelectList(_context.Pessoa.OrderBy(p => p.nome), "Pessoa_ID", "nome", receita.PessoaID);
            ViewData["StatusReceitaID"]    = new SelectList(_context.StatusReceita.OrderBy(p => p.Descricao), "ID", "Descricao", receita.StatusReceitaID);
            ViewData["TipoReceitaID"]      = new SelectList(_context.TipoReceita.OrderBy(p => p.Descricao), "ID", "Descricao", receita.TipoReceitaID);
            return View(receita);
        }

        // GET: Receita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }

            ViewData["FormaRecebimentoID"] = new SelectList(_context.FormaRecebimento.OrderBy(p => p.Descricao), "FormaRecebimento_ID", "Descricao", receita.FormaRecebimentoID);
            ViewData["PessoaID"]           = new SelectList(_context.Pessoa.OrderBy(p => p.nome), "Pessoa_ID", "nome", receita.PessoaID);
            ViewData["StatusReceitaID"]    = new SelectList(_context.StatusReceita.OrderBy(p => p.Descricao), "ID", "Descricao", receita.StatusReceitaID);
            ViewData["TipoReceitaID"]      = new SelectList(_context.TipoReceita.OrderBy(p => p.Descricao), "ID", "Descricao", receita.TipoReceitaID);

            return View(receita);
        }

        // POST: Receita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao,DataPrevistaRecebimento,DataDeRecebimento,ValorAReceber,ValorRecebido,FormaRecebimentoID,StatusReceitaID,PessoaID,DataCadastro,DataUltimaAtualizacao,TipoReceitaID")] Receita receita)
        {
            if (id != receita.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    receita.DataCadastro = obter(receita.ID).DataCadastro;
                    receita.DataUltimaAtualizacao = DateTime.Now;

                    _context.Update(receita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitaExists(receita.ID))
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
            ViewData["FormaRecebimentoID"] = new SelectList(_context.FormaRecebimento.OrderBy(p => p.Descricao), "FormaRecebimento_ID", "Descricao", receita.FormaRecebimentoID);
            ViewData["PessoaID"]           = new SelectList(_context.Pessoa.OrderBy(p => p.nome), "Pessoa_ID", "nome", receita.PessoaID);
            ViewData["StatusReceitaID"]    = new SelectList(_context.StatusReceita.OrderBy(p => p.Descricao), "ID", "Descricao", receita.StatusReceitaID);
            ViewData["TipoReceitaID"]      = new SelectList(_context.TipoReceita.OrderBy(p => p.Descricao), "ID", "Descricao", receita.TipoReceitaID);
            return View(receita);
        }

        // GET: Receita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita
                .Include(r => r.FormaRecebimento)
                .Include(r => r.Pessoa)
                .Include(r => r.StatusReceita)
                .Include(r => r.TipoReceita)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // POST: Receita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receita = await _context.Receita.FindAsync(id);
            _context.Receita.Remove(receita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitaExists(int id)
        {
            return _context.Receita.Any(e => e.ID == id);
        }

        public Receita obter(int id)
        {
            return _context.Receita.AsNoTracking().Where(e => e.ID == id).FirstOrDefault();
        }
    }
}
