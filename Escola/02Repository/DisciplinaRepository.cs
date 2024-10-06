using Dapper.Contrib.Extensions;
using Escola._03Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._02Repository
{
    public class DisciplinaRepository
    {
        public readonly string _connectionString; //Variável de connection string a ser preenchida
        //private readonly IMapper _mapper; //criando o mapper a ser preenchidoIMapper mapper,

        public DisciplinaRepository(string StringConnection) //Responsavel por preencher a connection string
        {
            //_mapper = mapper;
            _connectionString = StringConnection;
        }

        public void Adicionar(Disciplina disciplina)
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao
            connection.Insert<Disciplina>(disciplina);
        }
        public List<Disciplina> ListarDisciplinas()
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao
            return connection.GetAll<Disciplina>().ToList(); // retorna a tabela em forma de lista    
        }
        public Disciplina BuscarDisciplinas(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao
            return connection.Get<Disciplina>(id);//busca so um resgistro id e sua linha
        }
        public void Editar(Disciplina disciplina)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            connection.Update<Disciplina>(disciplina);
        }
        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            Disciplina novadisciplina = BuscarDisciplinas(id);//retorna o objeto produto
            connection.Delete<Disciplina>(novadisciplina);
        }
    }
}
