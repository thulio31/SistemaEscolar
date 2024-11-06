using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscola.Models
{
    public class Alunos
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Matricula { get; set; }
        public string Telefone { get; set; }
        public string Serie { get; set; }
        public string Turma { get; set; }


        //Propriedade de Referencia 
        public int IdFuncionarioEncarregado { get; set; }
        public int IdTurmas { get; set; }

        public override string ToString()
        {
            return $"Id: {id} - Nome: {Nome} - Matricula: {Matricula} - Telefone: {Telefone}\nSerie: {Turma} - Professor {IdFuncionarioEncarregado}";
        }
    }
}
