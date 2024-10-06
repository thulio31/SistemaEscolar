using Aluno._02Repository;
using Aluno._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluno._01Services
{
    public class TurmaService
    {
        public TurmaRepository repository { get; set; }

        public TurmaService(string StringConnection)
        {
            repository = new TurmaRepository(StringConnection);
        }

        public void Adicionar(Turma turma)
        {
            repository.Adicionar(turma);
        }

        public void Remover(int id)
        {
            repository.Delete(id);
        }

        public void Editar(Turma turma)
        {
            repository.Editar(turma);
        }

        public List<Turma> Listar()
        {
            return repository.ListarTurmas();
        }

        public Turma BuscarTurmaPorId(int id)
        {
            return repository.BuscarTurmas(id);
        }

    }
}
