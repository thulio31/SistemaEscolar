using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscola.Models.DTOs
{
    public class AlunosDTO
    {
        
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Serie { get; set; }
        public string Turma { get; set; }


        //Propriedade de Referencia 
        public int IdFuncionarioEncarregado { get; set; }
    }
}
