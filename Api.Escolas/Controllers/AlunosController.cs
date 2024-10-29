using Aluno._01Services;
using Aluno._02Repository;
using Aluno._03Entidades;
using Aluno._03Entidades.DTO;
using AutoMapper;
using Escola._01Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAPI.Controllers
{

    [ApiController]
    [Route("[controller]")] //DataNotation
    public class AlunosController:ControllerBase
    {
        private readonly IAlunoService _service;
        private readonly IMapper _mapper; //criando o mapper a ser preenchido

        public AlunosController(IMapper mapper, IConfiguration configuration)
        {
            string _connectionString = configuration.GetConnectionString("DefaultConnection");//Passando a connection para uma nova string
            _mapper = mapper;
            _service = new AlunoService(_connectionString);
        }
        [HttpGet("Listar-Alunos")]// Rota (EndPoint)
        public List<Alunos> ListarAlunos()
        {
            return _service.Listar();
        }
        [HttpPost("Adicionar-dapper-contrib")]// Rota (EndPoint)
        public void AdicionarContrib(CreateAlunoDTO alDto) //pegando a dto
        {
            Alunos alu = new Alunos(); //pegando de um objeto e jogando para outro objeto
            alu.Nome = alDto.Nome; //propriedades para DTO
            alu.Idade = alDto.Idade;
            alu.Matricula = alDto.Matricula;
            alu.Telefone = alDto.Telefone;
            alu.Serie = alDto.Serie;
            alu.Turma = alDto.Turma;
            alu.IdFuncionarioEncarregado = alDto.IdFuncionarioEncarregado;
            _service.Adicionar(alu);
        } 

        [HttpGet("Buscar-Alunos")]
        public Alunos BuscarAlunos(int id)
        {
            return _service.BuscarAlunosPorId(id);
        }

        [HttpDelete("Delete-Alunos")]// Rota (EndPoint)
        public void DeleteAlunos(int id)
        {
            _service.Remover(id);
        }

        [HttpPut("Editar-Alunos")]// Rota (EndPoint)
        public void EditarAlunos(Alunos aluno)
        {
            _service.Editar(aluno);
        }
    }
}
