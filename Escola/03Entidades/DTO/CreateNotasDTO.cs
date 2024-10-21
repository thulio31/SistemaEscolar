using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._03Entidades.DTO
{
    public class CreateNotasDTO
    {

        public int disciplinaId { get; set; }
        public decimal valor { get; set; }
        public DateTime data { get; set; } // data em que a nota foi atribuída
        public string comentario { get; set; }

        public int IdAluno { get; set; }
    }
}
