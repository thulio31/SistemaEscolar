using Aluno._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._03Entidades
{
    public class Disciplina
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int cargahoraria { get; set; } // em horas
        public string ementa { get; set; } // descrição do conteúdo
        public string codigo { get; set; } // código da disciplina
        public int semestre { get; set; } // semestre em que a disciplina é oferecida

        //Propriedade de Referencia 
        public int IdFuncionarioEncarregado { get; set; }
        public int IdAluno { get; set; }

        public override string ToString()
        {
            return $"Id: {id} - Nome: {nome} - Cargahoraria: {cargahoraria} - Ementa: {ementa}  " +
                $"\nCodigo: {codigo} - Semestre {semestre} - IdFuncionarioEncarregado: {IdFuncionarioEncarregado}" +
                $"\nIdAluno: {IdAluno}";
        }
    }
}
