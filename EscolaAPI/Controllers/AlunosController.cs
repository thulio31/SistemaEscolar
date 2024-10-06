using Aluno._02Repository;
using Aluno._03Entidades;
using Aluno._03Entidades.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAPI.Controllers
{

    [ApiController]
    [Route("[controller]")] //DataNotation
    public class AlunosController
    {
        private readonly AlunoRepository _repository;
        private readonly IMapper _mapper; //criando o mapper a ser preenchido

        public AlunosController(IMapper mapper, IConfiguration configuration)
        {
            string _connectionString = configuration.GetConnectionString("DefaultConnection");//Passando a connection para uma nova string
            _mapper = mapper;
            _repository = new AlunoRepository(_connectionString);
        }
        [HttpGet("Listar-Alunos")]// Rota (EndPoint)
        public List<Alunos> ListarAlunos()
        {
            return _repository.ListarAlunos();
        }
        [HttpPost("Adicionar-dapper-contrib")]// Rota (EndPoint)
        public void AdicionarContrib(CreateAlunoDTO alDto) //pegando a dto
        {
            Alunos alu = new Alunos(); //pegando de um objeto e jogando para outro objeto
            alu.Nome = alDto.Nome;//propriedades para DTO
            alu.Idade = alDto.Idade;
            alu.Matricula = alDto.Matricula;
            alu.Telefone = alDto.Telefone;
            alu.Serie = alDto.Serie;
            alu.Turma = alDto.Turma;
            _repository.Adicionar(alu);
        }
        [HttpGet("Buscar - Alunos")]
        public Alunos BuscarAlunos(int id)
        {
            return _repository.BuscarAlunos(id);
        }

        [HttpDelete("Delete - Alunos")]// Rota (EndPoint)
        public void DeleteAlunos(int id)
        {
            _repository.Delete(id);
        }

        [HttpPut("Editar - Alunos")]// Rota (EndPoint)
        public void EditarAlunos(Alunos aluno)
        {
            _repository.Editar(aluno);
        }
    }
}
