using Aluno._02Repository;
using Aluno._03Entidades.DTO;
using Aluno._03Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Escola._03Entidades;
using Escola._02Repository;
using Escola._03Entidades.DTO;

namespace Api.Escolas.Controllers
{

    [ApiController]
    [Route("[controller]")] //DataNotation
    public class DisciplinaController : ControllerBase
    {
        private readonly DisciplinaRepository _repository;
        private readonly IMapper _mapper; //criando o mapper a ser preenchido

        public DisciplinaController(IMapper mapper, IConfiguration configuration)
        {
            string _connectionString = configuration.GetConnectionString("DefaultConnection");//Passando a connection para uma nova string
            _mapper = mapper;
            _repository = new DisciplinaRepository(_connectionString);
        }
        [HttpGet("Listar-Disciplina")]// Rota (EndPoint)
        public List<Disciplina> ListarDisciplina()
        {
            return _repository.ListarDisciplinas();
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
            _repository.Adicionar(disc);
        }

        [HttpGet("Buscar-Disciplina")]
        public Disciplina BuscarDisciplina(int id)
        {
            return _repository.BuscarDisciplinas(id);
        }

        [HttpDelete("Delete-Disciplina")]// Rota (EndPoint)
        public void DeleteDisciplina(int id)
        {
            _repository.Delete(id);
        }

        [HttpPut("Editar-Disciplina")]// Rota (EndPoint)
        public void EditarDisciplina(Disciplina disciplina)
        {
            _repository.Editar(disciplina);
        }
    }
}
