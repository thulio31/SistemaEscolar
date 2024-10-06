using Aluno._02Repository;
using Aluno._03Entidades.DTO;
using Aluno._03Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAPI.Controllers
{

    [ApiController]
    [Route("[controller]")] //DataNotation
    public class TurmaController : ControllerBase
    {
        private readonly TurmaRepository _repository;
        private readonly IMapper _mapper; //criando o mapper a ser preenchido

        public TurmaController(IMapper mapper, IConfiguration configuration)
        {
            string _connectionString = configuration.GetConnectionString("DefaultConnection");//Passando a connection para uma nova string
            _mapper = mapper;
            _repository = new TurmaRepository(_connectionString);
        }
        [HttpGet("Listar-Turma")]// Rota (EndPoint)
        public List<Turma> ListarTurmas()
        {
            return _repository.ListarTurmas();
        }
        [HttpPost("Adicionar-dapper-contrib")]// Rota (EndPoint)
        public void AdicionarContrib(CreateTurmaDTO turDto) //pegando a dto
        {
            Turma turm = new Turma(); //pegando de um objeto e jogando para outro objeto
            turm.Nome = turDto.Nome;//propriedades para DTO
            turm.Alunos = turDto.Alunos;
            turm.Vagas = turDto.Vagas;
            turm.CargaHoraria = turDto.CargaHoraria;
            turm.CodigoTurma = turDto.CodigoTurma;
            turm.Status = turDto.Status;
            _repository.Adicionar(turm);
        }
        [HttpGet("Buscar-Turma")]
        public Turma BuscarTurma(int id)
        {
            return _repository.BuscarTurmas(id);
        }

        [HttpDelete("Delete-Turmas")]// Rota (EndPoint)
        public void DeleteTurmas(int id)
        {
            _repository.Delete(id);
        }

        [HttpPut("Editar-Turmas")]// Rota (EndPoint)
        public void EditarTurmas(Turma turma)
        {
            _repository.Editar(turma);
        }
    }
}
