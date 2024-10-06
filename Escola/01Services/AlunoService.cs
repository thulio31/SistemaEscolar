using Aluno._02Repository;
using Aluno._03Entidades;

namespace Aluno._01Services
{
    public class AlunoService
    {
        public FuncionarioRepository repository { get; set; }

        public AlunoService(string StringConnection)
        {
            repository = new FuncionarioRepository(StringConnection);
        }

        public void Adicionar(Alunos aluno)
        {
            repository.AdicionarContrib(aluno);
        }

        public void Remover(int id)
        {
            repository.Delete(id);
        }

        public void Editar(Alunos aluno)
        {
            repository.Editar(aluno);
        }

        public List<Alunos> Listar()
        {
            return repository.ListarAlunos();
        }

        public Alunos BuscarAlunosPorId(int id)
        {
            return repository.BuscarAlunos(id);
        }


    }
}
