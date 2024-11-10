using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._03Entidades
{
    [Table("Funcionarios")]
    public class Funcionarios
    {
        // Propriedades básicas
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Datanasc { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Informações profissionais
        public string Cargo { get; set; }
        public double Salario { get; set; }


        //Propriedade de Referencia 
        public int IdTurmasAtendidas { get; set; }
        public int IdAlunos { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Nome: {Nome} - Datanasc: {Datanasc} - CPF: {CPF}  " +
                $"\nEndereco: {Endereco} - Telefone {Telefone} - Email: {Email}" +
                $"\nCargo: {Cargo} - Salario: {Salario} - IdTurmasAtendidas {IdTurmasAtendidas} - Email: {IdAlunos}";
        }

    }
}
