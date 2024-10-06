using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluno._03Entidades.DTO
{
    public class CreateAlunoDTO
    {

        // Propriedades básicas
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Matricula { get; set; }
        public string Telefone { get; set; }
        public string Serie { get; set; }
        public string Turma { get; set; }

        //Propriedade de Referencia 
        public int IdFuncionarioEncarregado { get; set; }
        public int IdTurmas { get; set; }
    }
}
