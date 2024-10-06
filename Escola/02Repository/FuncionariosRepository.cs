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
    public class FuncionariosRepository
    {
        public readonly string _connectionString; //Variável de connection string a ser preenchida
        //private readonly IMapper _mapper; //criando o mapper a ser preenchidoIMapper mapper,

        public FuncionariosRepository(string StringConnection) //Responsavel por preencher a connection string
        {
            //_mapper = mapper;
            _connectionString = StringConnection;
        }

        public void Adicionar(Funcionarios funcionario)
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao
            connection.Insert<Funcionarios>(funcionario);
        }
        public List<Funcionarios> ListarFuncionarios()
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao
            return connection.GetAll<Funcionarios>().ToList(); // retorna a tabela em forma de lista    
        }
        public Funcionarios BuscarFuncionarios(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao
            return connection.Get<Funcionarios>(id);//busca so um resgistro id e sua linha
        }
        public void Editar(Funcionarios funcionario)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            connection.Update<Funcionarios>(funcionario);
        }
        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            Funcionarios novofuncionarios = BuscarFuncionarios(id);//retorna o objeto produto
            connection.Delete<Funcionarios>(novofuncionarios);
        }
    }
}
