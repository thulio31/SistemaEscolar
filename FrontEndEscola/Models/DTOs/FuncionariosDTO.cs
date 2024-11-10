using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscola.Models.DTOs
{
    public class FuncionariosDTO
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Datanasc { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }

        // Informações profissionais
        public string Cargo { get; set; }
        public double Salario { get; set; }
    }
}
