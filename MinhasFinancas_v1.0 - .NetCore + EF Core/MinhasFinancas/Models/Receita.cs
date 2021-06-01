using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class Receita
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime  DataPrevistaRecebimento { get; set; }
        public DateTime? DataDeRecebimento       { get; set; }

        [Required]
        public string ValorAReceber { get; set; }
        public string ValorRecebido { get; set; }
        
        public int FormaRecebimentoID            { get; set; }
        public FormaRecebimento FormaRecebimento { get; set; }

        public int StatusReceitaID { get; set; }
        public StatusReceita StatusReceita { get; set; }

        public int PessoaID { get; set; }
        public Pessoa Pessoa { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }

        public int TipoReceitaID { get; set; }
        public TipoReceita TipoReceita { get; set; }
    }
}
