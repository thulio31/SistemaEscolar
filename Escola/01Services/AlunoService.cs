﻿using Aluno._02Repository;
using Aluno._03Entidades;
using Escola._01Services.Interfaces;
using Escola._02Repository.Interfaces;

namespace Aluno._01Services
{
    public class AlunoService : IAlunoService
    {
        public IAlunoRepository repository { get; set; }

        public AlunoService(string StringConnection)
        {
            repository = new AlunoRepository(StringConnection);
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
