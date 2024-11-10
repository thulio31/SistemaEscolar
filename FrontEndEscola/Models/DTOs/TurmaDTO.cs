using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscola.Models.DTOs
{
    public class TurmaDTO
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Alunos { get; set; }
        public int Vagas { get; set; }
        public double CargaHoraria { get; set; }


        //Propriedade de Referencia 
        public int IdFuncionarioEncarregado { get; set; }
    }
}
