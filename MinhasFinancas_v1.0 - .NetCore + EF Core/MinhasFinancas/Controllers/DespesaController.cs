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
    public class DespesaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DespesaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Despesa
        /*public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Despesa.Include(d => d.CategoriaDespesa)
                                                       .Include(d => d.FormaPagamento)
                                                       .Include(d => d.Pessoa)
                                                       .Include(d => d.StatusDespesa);
            return View(await applicationDbContext.ToListAsync());
        }*/

        public async Task<IActionResult> Index(int? Ano, int? Mes, int? StDespesa)
        {
            CommonViewModel commonView = new CommonViewModel();

            // DESPESA
            var applicationDbContext_Despesa = CapturaDespesas(Ano, Mes, StDespesa);

            PopularTela(applicationDbContext_Despesa);

            commonView.DespesaVM = applicationDbContext_Despesa.ToList();

            // RECEITA
            ReceitaController receitaController = new ReceitaController(_context);

            commonView.ReceitaVM = receitaController.CapturaReceitas(Ano, Mes, 4);

            return View(await applicationDbContext_Despesa.ToListAsync());
        }

        private Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Despesa, StatusDespesa> CapturaDespesas(int? Ano, int? Mes, int? StDespesa)
        {
            var mesAtual = DateTime.Now.Month;
            var anoAtual = DateTime.Now.Year;
            StDespesa = StDespesa == null ? StatusDespesa.Todos : StDespesa;

            mesAtual = Mes != null ? (int)Mes : mesAtual;
            anoAtual = Ano != null ? (int)Ano : anoAtual;

            ViewData["Ano"] = new SelectList(_context.Ano.OrderBy(p => p.Descricao), "Descricao", "Descricao", anoAtual);
            ViewData["Mes"] = new SelectList(_context.Mes.OrderBy(p => p.NumeroMes), "NumeroMes", "Descricao", mesAtual);
            ViewData["StDespesa"] = new SelectList(_context.StatusDespesa.OrderBy(p => p.Descricao), "ID", "Descricao", StDespesa);

            var application = _context.Despesa.Where(p => p.DataVencimento.Month == mesAtual && p.DataVencimento.Year == anoAtual);

            if (StDespesa != StatusDespesa.Todos)
            {
                application = application.Where(p => p.StatusDespesaID == StDespesa);
            }

            var applicationDbContext = application.Include(d => d.CategoriaDespesa)
                                                  .Include(d => d.FormaPagamento)
                                                  .Include(d => d.Pessoa)
                                                  .Include(d => d.StatusDespesa);
            return applicationDbContext;
        }

        public async Task<IActionResult> IndexConsulta(int? Ano, int? Mes, int? StDespesa)
        {
            var mesAtual = DateTime.Now.Month;
            var anoAtual = DateTime.Now.Year;
            StDespesa = StDespesa == null ? StatusDespesa.Todos : StDespesa;

            mesAtual = Mes != null ? (int)Mes : mesAtual;
            anoAtual = Ano != null ? (int)Ano : anoAtual;

            ViewData["Ano"] = new SelectList(_context.Ano.OrderBy(p => p.Descricao), "Descricao", "Descricao", anoAtual);
            ViewData["Mes"] = new SelectList(_context.Mes.OrderBy(p => p.NumeroMes), "NumeroMes", "Descricao", mesAtual);
            ViewData["StDespesa"] = new SelectList(_context.StatusDespesa.OrderBy(p => p.Descricao), "ID", "Descricao", StDespesa);

            var application = _context.Despesa.Where(p => p.DataVencimento.Month == mesAtual && p.DataVencimento.Year == anoAtual);

            if(StDespesa != StatusDespesa.Todos)
            {
                application = application.Where(p => p.StatusDespesaID == StDespesa);
            }

            var applicationDbContext = application.Include(d => d.CategoriaDespesa)
                                                  .Include(d => d.FormaPagamento)
                                                  .Include(d => d.Pessoa)
                                                  .Include(d => d.StatusDespesa);

            PopularTela(applicationDbContext);

            return View(await applicationDbContext.ToListAsync());
        }

        private void PopularTela(Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Despesa, StatusDespesa> applicationDbContext)
        {
            var lstValorAPagar = applicationDbContext.Select(p => Convert.ToDecimal(p.ValorAPagar.Replace(",", "."))).ToList();
            var lstValorPago   = applicationDbContext.Select(p => Convert.ToDecimal(p.ValorPago.Replace(",", "."))).ToList();

            var totalAPagar = lstValorAPagar.Count() > 0 ? lstValorAPagar.Sum() : 0;
            var totalPago   = lstValorPago.Count()   > 0 ? lstValorPago.Sum()   : 0;

            ViewData["NroTotalDespesas"]   = lstValorAPagar.Count().ToString();
            ViewData["ValorTotalAPagar"]   = totalAPagar.ToString("C");
            ViewData["ValorTotalPago"]     = totalPago.ToString("C");
            ViewData["ValorTotalPendente"] = (totalAPagar - totalPago).ToString("C");

            CapturarValores(applicationDbContext, "Essencial");
            CapturarValores(applicationDbContext, "Estudos");
            CapturarValores(applicationDbContext, "Metas");
            CapturarValores(applicationDbContext, "Outros");
        }

        private void CapturarValores(IQueryable<Despesa> lstDespesa, string categoria)
        {
            var categoriaID = new CategoriaDespesaController(_context).obter(categoria);

            var despesas = lstDespesa.Where(p => p.CategoriaDespesaID == categoriaID.ID);

            ViewData[$"ValorTotalAPagar_{categoria}"] = despesas.Select(p => Convert.ToDecimal(p.ValorAPagar.Replace(",", "."))).ToList().Sum().ToString("C");
            ViewData[$"ValorTotalAPago_{categoria}"]  = despesas.Select(p => Convert.ToDecimal(p.ValorPago.Replace(",", "."))).ToList().Sum().ToString("C");
        }

        // GET: Despesa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var despesa = await _context.Despesa
                .Include(d => d.CategoriaDespesa)
                .Include(d => d.FormaPagamento)
                .Include(d => d.Pessoa)
                .Include(d => d.StatusDespesa)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (despesa == null)
                return NotFound();

            return View(despesa);
        }

        // GET: Despesa/Create
        public IActionResult Create()
        {
            ViewData["CategoriaDespesaID"]  = ObterDadosComplementares("CategoriaDespesa");
            ViewData["FormaPagamentoID"]    = ObterDadosComplementares("FormaPagamento");
            ViewData["PessoaID"]            = ObterDadosComplementares("Pessoa");
            ViewData["StatusDespesaID"]     = ObterDadosComplementares("StatusDespesa");
            return View();
        }

        // POST: Despesa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao,DataVencimento,DataPagamento,ValorAPagar,ValorPago,CategoriaDespesaID,FormaPagamentoID,StatusDespesaID,PessoaID,DataCadastro,DataUltimaAtualizacao")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                despesa.DataCadastro = despesa.DataUltimaAtualizacao = DateTime.Now;

                if (despesa.ValorAPagar == null) despesa.ValorAPagar = "0";
                if (despesa.ValorPago   == null) despesa.ValorPago   = "0";

                _context.Add(despesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaDespesaID"]  = ObterDadosComplementares("CategoriaDespesa", despesa);
            ViewData["FormaPagamentoID"]    = ObterDadosComplementares("FormaPagamento", despesa);
            ViewData["PessoaID"]            = ObterDadosComplementares("Pessoa", despesa);
            ViewData["StatusDespesaID"]     = ObterDadosComplementares("StatusDespesa",despesa);

            return View(despesa);
        }

        // GET: Despesa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var despesa = await _context.Despesa.FindAsync(id);
            if (despesa == null)
                return NotFound();

            ViewData["CategoriaDespesaID"]  = ObterDadosComplementares("CategoriaDespesa", despesa);
            ViewData["FormaPagamentoID"]    = ObterDadosComplementares("FormaPagamento", despesa);
            ViewData["PessoaID"]            = ObterDadosComplementares("Pessoa", despesa);
            ViewData["StatusDespesaID"]     = ObterDadosComplementares("StatusDespesa",despesa);
            return View(despesa);
        }

        // POST: Despesa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao,DataVencimento,DataPagamento,ValorAPagar,ValorPago,CategoriaDespesaID,FormaPagamentoID,StatusDespesaID,PessoaID,DataCadastro,DataUltimaAtualizacao")] Despesa despesa)
        {
            if (id != despesa.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    despesa.DataCadastro = obter(despesa.ID).DataCadastro;
                    despesa.DataUltimaAtualizacao = DateTime.Now;

                    _context.Update(despesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespesaExists(despesa.ID))
                        return NotFound();

                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaDespesaID"]  = ObterDadosComplementares("CategoriaDespesa", despesa);
            ViewData["FormaPagamentoID"]    = ObterDadosComplementares("FormaPagamento", despesa);
            ViewData["PessoaID"]            = ObterDadosComplementares("Pessoa", despesa);
            ViewData["StatusDespesaID"]     = ObterDadosComplementares("StatusDespesa",despesa);
            return View(despesa);
        }

        // GET: Despesa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var despesa = await _context.Despesa
                .Include(d => d.CategoriaDespesa)
                .Include(d => d.FormaPagamento)
                .Include(d => d.Pessoa)
                .Include(d => d.StatusDespesa)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (despesa == null)
                return NotFound();

            return View(despesa);
        }

        // POST: Despesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var despesa = await _context.Despesa.FindAsync(id);
            _context.Despesa.Remove(despesa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private SelectList ObterDadosComplementares(string classe)
        {
            if(classe.Equals("CategoriaDespesa"))    return new SelectList(_context.CategoriaDespesa.OrderBy(p => p.Descricao), "ID", "Descricao");
            else if(classe.Equals("FormaPagamento")) return new SelectList(_context.FormaPagamento.OrderBy(p => p.Descricao), "ID", "Descricao");
            else if(classe.Equals("Pessoa"))         return new SelectList(_context.Pessoa.Where(p => p.TipoPessoaID == TipoPessoa.BancoCorretora).OrderBy(p => p.nome), "Pessoa_ID", "nome");
            else                                     return new SelectList(_context.StatusDespesa.Where(p => p.ID != StatusDespesa.Todos).OrderBy(p => p.Descricao), "ID", "Descricao");
        }

        private SelectList ObterDadosComplementares(string classe, Despesa despesa)
        {
            if(classe.Equals("CategoriaDespesa"))    return new SelectList(_context.CategoriaDespesa.OrderBy(p => p.Descricao), "ID", "Descricao", despesa.CategoriaDespesaID);
            else if(classe.Equals("FormaPagamento")) return new SelectList(_context.FormaPagamento.OrderBy(p => p.Descricao), "ID", "Descricao", despesa.FormaPagamentoID);
            else if(classe.Equals("Pessoa"))         return new SelectList(_context.Pessoa.Where(p => p.TipoPessoaID == TipoPessoa.BancoCorretora).OrderBy(p => p.nome), "Pessoa_ID", "nome", despesa.PessoaID);
            else                                     return new SelectList(_context.StatusDespesa.Where(p => p.ID != StatusDespesa.Todos).OrderBy(p => p.Descricao), "ID", "Descricao", despesa.StatusDespesaID);
        }

        private bool DespesaExists(int id)
        {
            return _context.Despesa.Any(e => e.ID == id);
        }

        public Despesa obter(int id)
        {
            return _context.Despesa.AsNoTracking().Where(e => e.ID == id).FirstOrDefault();
        }
    }
}
