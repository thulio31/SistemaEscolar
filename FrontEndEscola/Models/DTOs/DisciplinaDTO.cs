using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscola.Models.DTOs
{
    public class DisciplinaDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int cargahoraria { get; set; } // em horas

        //Propriedade de Referencia 
        public int IdFuncionarioEncarregado { get; set; }
    }
}
