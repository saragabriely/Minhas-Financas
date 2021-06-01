using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Models;
using MinhasFinancas.Models.Investimentos.RendaVariavel;

namespace MinhasFinancas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MinhasFinancas.Models.StatusReceita> StatusReceita { get; set; }
        public DbSet<MinhasFinancas.Models.TipoInvestimento> TipoInvestimento { get; set; }
        public DbSet<MinhasFinancas.Models.StatusMeta> StatusMeta { get; set; }
        public DbSet<MinhasFinancas.Models.StatusInvestimento> StatusInvestimento { get; set; }
        public DbSet<MinhasFinancas.Models.StatusDespesa> StatusDespesa { get; set; }
        public DbSet<MinhasFinancas.Models.FormaRecebimento> FormaRecebimento { get; set; }
        public DbSet<MinhasFinancas.Models.FormaPagamento> FormaPagamento { get; set; }
        public DbSet<MinhasFinancas.Models.TipoPessoa> TipoPessoa { get; set; }
        public DbSet<MinhasFinancas.Models.Pessoa> Pessoa { get; set; }
        public DbSet<MinhasFinancas.Models.CategoriaDespesa> CategoriaDespesa { get; set; }
        public DbSet<MinhasFinancas.Models.TipoConta> TipoConta { get; set; }
        public DbSet<MinhasFinancas.Models.Conta> Conta { get; set; }
        public DbSet<MinhasFinancas.Models.Despesa> Despesa { get; set; }
        public DbSet<MinhasFinancas.Models.Mes> Mes { get; set; }
        public DbSet<MinhasFinancas.Models.Ano> Ano { get; set; }
        public DbSet<MinhasFinancas.Models.Receita> Receita { get; set; }
        public DbSet<MinhasFinancas.Models.TipoReceita> TipoReceita { get; set; }
        public DbSet<MinhasFinancas.Models.Investimentos.RendaVariavel.SetorEmpresa> SetorEmpresa { get; set; }
        public DbSet<MinhasFinancas.Models.Investimentos.RendaVariavel.TipoMercado> TipoMercado { get; set; }
        public DbSet<MinhasFinancas.Models.Investimentos.RendaVariavel.EmpresaListada> EmpresaListada { get; set; }
        public DbSet<MinhasFinancas.Models.Investimentos.RendaVariavel.TipoMovimento> TipoMovimento { get; set; }
        public DbSet<MinhasFinancas.Models.Investimentos.RendaVariavel.Acao> Acao { get; set; }
    }
}
