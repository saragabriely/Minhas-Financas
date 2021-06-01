using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models.Investimentos.RendaVariavel
{
    public class EmpresaListada
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public string NomeDePregao { get; set; }
        public string CodigoAcao { get; set; }

        public int SetorEmpresaID     { get; set; }
        public SetorEmpresa SetorEmpresa { get; set; }
        
    }
}
