using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models.Investimentos.RendaVariavel
{
    public class Acao
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public string DataNegociacao { get; set; }
        public string ValorCompra { get; set; }
        public int    QuantidadeCompra { get; set; }
        public string ValorCorretagem { get; set; }
        public string ValorISS { get; set; }

        public int EmpresaListadaID { get; set; }
        public EmpresaListada EmpresaListada { get; set; }

        public int TipoMercadoID { get; set; }
        public TipoMercado TipoMercado { get; set; }

        public int PessoaID { get; set; }
        public Pessoa Pessoa { get; set; }

        public int TipoMovimentoID { get; set; }
        public TipoMovimento TipoMovimento { get; set; }
    }
}
