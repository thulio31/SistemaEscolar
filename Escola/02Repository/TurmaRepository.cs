using Aluno._03Entidades;
using AutoMapper;
using Dapper;
using Dapper.Contrib.Extensions;
using Escola._02Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluno._02Repository
{
      public class TurmaRepository: ITurmaRepository
    {
        public readonly string _connectionString; //Variável de connection string a ser preenchida
        //private readonly IMapper _mapper; //criando o mapper a ser preenchidoIMapper mapper,

        public TurmaRepository( string StringConnection) //Responsavel por preencher a connection string
        {
            //_mapper = mapper;
            _connectionString = StringConnection;
        }

        public void Adicionar(Turma turma)
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao
            connection.Insert<Turma>(turma);
        }
        public List<Turma> ListarTurmas()
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao

            return connection.GetAll<Turma>().ToList(); // retorna a tabela em forma de lista    
        }
        public Turma BuscarTurmas(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao
            return connection.Get<Turma>(id);//busca so um resgistro id e sua linha
        }
        public void Editar(Turma turma)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            connection.Update<Turma>(turma);
        }
        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            Turma novaturma = BuscarTurmas(id);//retorna o objeto produto
            connection.Delete<Turma>(novaturma);
        }
    }
}
