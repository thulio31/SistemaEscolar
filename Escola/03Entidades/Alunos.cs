using System.ComponentModel.DataAnnotations.Schema;

namespace Aluno._03Entidades
{
    [Table("Alunos")]
    public class Alunos
    {

        // Propriedades básicas

        public int Id { get; set; }
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
