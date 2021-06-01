using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models.Investimentos.RendaVariavel
{
    public class TipoMercado
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [MaxLength(150, ErrorMessage = "A descrição tem tamanho máximo de 150 caracteres.")]
        public string descricao { get; set; }

        [MaxLength(200, ErrorMessage = "A observação tem tamanho máximo de 200 caracteres.")]
        public string observacao { get; set; }
    }
}
