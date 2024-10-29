using Aluno._02Repository;
using Aluno._03Entidades.DTO;
using Aluno._03Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Escola._03Entidades;
using Escola._02Repository;
using Escola._03Entidades.DTO;
using Escola._01Services.Interfaces;
using Escola._01Services;

namespace Api.Escolas.Controllers
{

    [ApiController]
    [Route("[controller]")] //DataNotation
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaService _service;
        private readonly IMapper _mapper; //criando o mapper a ser preenchido

        public DisciplinaController(IMapper mapper, IConfiguration configuration)
        {
            string _connectionString = configuration.GetConnectionString("DefaultConnection");//Passando a connection para uma nova string
            _mapper = mapper;
            _service = new DisciplinaService(_connectionString);
        }
        [HttpGet("Listar-Disciplina")]// Rota (EndPoint)
        public List<Disciplina> ListarDisciplina()
        {
            return _service.Listar();
        }
        [HttpPost("Adicionar-dapper-contrib")]// Rota (EndPoint)
        public void AdicionarContrib(CreateDisciplinaDTO discDto) //pegando a dto
        {
            Disciplina disc = new Disciplina(); //pegando de um objeto e jogando para outro objeto
            disc.nome = discDto.nome; //propriedades para DTO
            disc.cargahoraria = discDto.cargahoraria;
            disc.ementa = discDto.ementa;
            disc.codigo = discDto.codigo;
            disc.semestre = discDto.semestre;
            disc.IdFuncionarioEncarregado = discDto.IdFuncionarioEncarregado;
            disc.IdAluno = discDto.IdAluno;
            _service.Adicionar(disc);
        }

        [HttpGet("Buscar-Disciplina")]
        public Disciplina BuscarDisciplina(int id)
        {
            return _service.BuscarDisciplinaPorId(id);
        }

        [HttpDelete("Delete-Disciplina")]// Rota (EndPoint)
        public void DeleteDisciplina(int id)
        {
            _service.Remover(id);
        }

        [HttpPut("Editar-Disciplina")]// Rota (EndPoint)
        public void EditarDisciplina(Disciplina disciplina)
        {
            _service.Editar(disciplina);
        }
    }
}
