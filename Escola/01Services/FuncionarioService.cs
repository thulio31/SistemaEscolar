﻿
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
    public class FuncionarioService : IFuncionarioService
    {
        public readonly IFuncionarioRepository repository;

        public FuncionarioService(IFuncionarioRepository _repository)
        {
            repository = _repository;
        }

        public void Adicionar(Funcionarios funcionario)
        {
            repository.Adicionar(funcionario);
        }

        public void Remover(int id)
        {
            repository.Delete(id);
        }

        public void Editar(Funcionarios funcionario)
        {
            repository.Editar(funcionario);
        }

        public List<Funcionarios> Listar()
        {
            return repository.ListarFuncionarios();
        }

        public Funcionarios BuscarFuncionarioPorId(int id)
        {
            return repository.BuscarFuncionarios(id);
        }

    }
}
