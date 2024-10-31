using Escola._01Services.Interfaces;
using Escola._02Repository;
using Escola._02Repository.Interfaces;
using Escola._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._01Services
{
    public class DisciplinaService : IDisciplinaService
    {
        public readonly IDisciplinaRepository repository;

        public DisciplinaService(IDisciplinaRepository _repository)
        {
            repository = _repository;
        }

        public void Adicionar(Disciplina disciplina)
        {
            repository.Adicionar(disciplina);
        }

        public void Remover(int id)
        {
            repository.Delete(id);
        }

        public void Editar(Disciplina disciplina)
        {
            repository.Editar(disciplina);
        }

        public List<Disciplina> Listar()
        {
            return repository.ListarDisciplinas();
        }

        public Disciplina BuscarDisciplinaPorId(int id)
        {
            return repository.BuscarDisciplinas(id);
        }
    }
}
