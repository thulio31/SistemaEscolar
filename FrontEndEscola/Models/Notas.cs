using Escola._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscola.Models
{
    public class Notas
    {
        public int id { get; set; }
        public Disciplina disciplina { get; set; }
        public decimal valor { get; set; }
        public DateTime data { get; set; } // data em que a nota foi atribuída
        public string comentario { get; set; }
        public int IdAluno { get; set; }

        public override string ToString()
        {
            return $"Id: {id} - Disciplina: {disciplina} - Valor: {valor} - data: {data}\ncomentario: {comentario} - IdAluno {IdAluno}";
        }
    }
}
