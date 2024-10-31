﻿using Aluno._03Entidades;
using Dapper.Contrib.Extensions;
using Escola._02Repository.Interfaces;
using Escola._03Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._02Repository
{
    public class NotaRepository : INotaRepository
    {
        public readonly string _connectionString; //Variável de connection string a ser preenchida
        //private readonly IMapper _mapper; //criando o mapper a ser preenchidoIMapper mapper,

        public NotaRepository(IConfiguration configuration) //Responsavel por preencher a connection string
        {
            //_mapper = mapper;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Adicionar(Notas notas)
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao
            connection.Insert<Notas>(notas);
        }
        public List<Notas> ListarNotas()
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao

            return connection.GetAll<Notas>().ToList(); // retorna a tabela em forma de lista    
        }
        public Notas BuscarNotasPorAluno( int idaluno)
        {
            Notas not = new Notas();
            not.IdAluno = idaluno;
            using var connection = new SQLiteConnection(_connectionString);// conexao
            return connection.Get<Notas>(idaluno);
        }

        public Notas BuscarNotas(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao
            return connection.Get<Notas>(id);//busca so um resgistro id e sua linha
        }
        public void Editar(Notas notas)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            connection.Update<Notas>(notas);
        }
        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            Notas novanota = BuscarNotas(id);//retorna o objeto produto
            connection.Delete<Notas>(novanota);
        }
    }
}
