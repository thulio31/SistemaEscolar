using Escola._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscola.Models.DTOs
{
    public class NotasDTO
    {
        public Disciplina disciplina { get; set; }
        public decimal valor { get; set; }
        public int IdAluno { get; set; }
    }
}
