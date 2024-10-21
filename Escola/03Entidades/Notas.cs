using Aluno._03Entidades;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._03Entidades
{
    [Table("Notas")]
    public class Notas
    {
        public int id { get; set; } 
        public int disciplinaId { get; set; } 
        public decimal valor { get; set; } 
        public DateTime data { get; set; } // data em que a nota foi atribuída
        public string comentario { get; set; } 

        public int IdAluno { get; set; }


    }
}
