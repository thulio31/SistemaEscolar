using Aluno._02Repository;
using Aluno._03Entidades;
using Escola._01Services.Interfaces;
using Escola._02Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluno._01Services
{
    public class TurmaService : ITurmaService
    {
        public readonly ITurmaRepository repository;

        public TurmaService(ITurmaRepository _repository)
        {
            repository = _repository;
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
