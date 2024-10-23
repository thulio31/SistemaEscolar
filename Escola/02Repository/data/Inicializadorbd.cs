using Aluno._03Entidades;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Aluno._02Repository.data
{
    public class Inicializadorbd
    {

        private const string ConnectionString = "Data Source=Escola.db";
        public static void Inializador()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandoSQL = @" 
                CREATE TABLE IF NOT EXISTS Alunos(                
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                NOME TEXT NOT NULL,
                IDADE INTEGER NOT NULL,
                MATRICULA TEXT NOT NULL,
                TELEFONE TEXT NOT NULL,
                SERIE TEXT NOT NULL,
                TURMA TEXT NOT NULL,
                IDFUNCIONARIOENCARREGADO INTEGER NOT NULL,
                IDTURMAS INTEGER  NOT NULL
                 );";
                
                commandoSQL += @" 
                CREATE TABLE IF NOT EXISTS Turmas(                
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                NOME TEXT NOT NULL,
                ALUNOS INTERGER NOT NULL,
                VAGAS INTERGER NOT NULL,
                CARGAHORARIA REAL NOT NULL,
                CODIGOTURMA TEXT NOT NULL,
                STATUS TEXT NOT NULL,
                IDFUNCIONARIOENCARREGADO INTEGER NOT NULL,
                IDALUNO INTEGER NOT NULL);";

                commandoSQL += @"
                CREATE TABLE IF NOT EXISTS Funcionarios( 
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                NOME TEXT NOT NULL,
                DATANASC DATE NOT NULL,
                CPF TEXT UNIQUE NOT NULL,
                ENDERECO TEXT NOT NULL,
                TELEFONE TEXT NOT NULL,
                EMAIL TEXT NOT NULL,    
                CARGO TEXT NOT NULL,
                SALARIO DECIMAL NOT NULL,
                IDTURMASATENDIDAS INTEGER NOT NULL,
                IDALUNOS INTEGER NOT NULL);";

                commandoSQL += @"
                CREATE TABLE IF NOT EXISTS Disciplinas( 
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                NOME TEXT NOT NULL,
                CARGAHORARIA INTEGER NOT NULL,
                EMENTA TEXT NOT NULL,
                CODIGO TEXT NOT NULL,
                SEMESTRE TEXT NOT NULL,
                IDFUNCIONARIOENCARREGADO INTEGER NOT NULL,
                IDALUNO INTEGER NOT NULL);";


                commandoSQL += @"
                CREATE TABLE IF NOT EXISTS Notas(
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                DISCIPLINAID INTEGER NOT NULL,
                VALOR REAL NOT NULL,
                DATA DATE UNIQUE NOT NULL,
                COMENTARIO TEXT NOT NULL,    
                IDALUNO INTEGER NOT NULL );";

                commandoSQL += @"   
                 CREATE TABLE IF NOT EXISTS Usuarios(
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 Nome TEXT NOT NULL,
                 Senha TEXT NOT NULL,
                 Email TEXT NOT NULL,
                 Tipo INTEGER NOT NULL
                );";


                connection.Execute(commandoSQL); //comando do Dapper que executa qualquer comando sql

            }
        }
    }
}
