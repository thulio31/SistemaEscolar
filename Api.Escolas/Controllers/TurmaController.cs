using Aluno._02Repository;
using Aluno._03Entidades.DTO;
using Aluno._03Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Aluno._01Services;
using Escola._01Services.Interfaces;

namespace EscolaAPI.Controllers
{

    [ApiController]
    [Route("[controller]")] //DataNotation
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService _service;
        private readonly IMapper _mapper; //criando o mapper a ser preenchido

        public TurmaController(IMapper mapper, IConfiguration configuration, ITurmaService service )
        {
            string _connectionString = configuration.GetConnectionString("DefaultConnection");//Passando a connection para uma nova string
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// endpoint que lista todas as turmas do banco de dadosa
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listar-Turma")]// Rota (EndPoint)
        public List<Turma> ListarTurmas()
        {
            try
            {
                return _service.Listar();
            }
            catch (Exception)
            {

                throw new Exception("erro ao listar");
            }
            
        }

        /// <summary>
        /// endpoit que adiciona uma turma no banco de dados
        /// </summary>
        /// <param name="turDto"></param>
        [HttpPost("Adicionar-turma")]// Rota (EndPoint)
        public IActionResult AdicionarContrib(CreateTurmaDTO turDto) //pegando a dto
        {
            try
            {
                Turma turm = new Turma(); //pegando de um objeto e jogando para outro objeto
                turm.Nome = turDto.Nome;//propriedades para DTO
                turm.Alunos = turDto.Alunos;
                turm.Vagas = turDto.Vagas;
                turm.CargaHoraria = turDto.CargaHoraria;
                turm.CodigoTurma = turDto.CodigoTurma;
                turm.Status = turDto.Status;
                turm.IdFuncionarioEncarregado = turDto.IdFuncionarioEncarregado;
                turm.IdAluno = turDto.IdAluno;
                _service.Adicionar(turm);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest($"erro ao adicionar a turma {erro.Message}");
            }
            
        }

        /// <summary>
        /// endpoint para buscar uma turma por id inserido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Buscar-Turma")]
        public Turma BuscarTurma(int id)
        {
            try
            {
                return _service.BuscarTurmaPorId(id);
            }
            catch (Exception)
            {

                throw new Exception("erro ao buscar");
            }
            
        }


        /// <summary>
        /// endpoint para deletar uma turma por id inserido
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("Delete-Turmas")]// Rota (EndPoint)
        public IActionResult DeleteTurmas(int id)
        {
            try
            {
                _service.Remover(id);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest($"erro ao deletar {erro.Message}");
            }
            
        }

        /// <summary>
        /// endpoit para editar uma turma por id inserido
        /// </summary>
        /// <param name="turma"></param>
        [HttpPut("Editar-Turmas")]// Rota (EndPoint)
        public IActionResult EditarTurmas(Turma turma)
        {
            try
            {
                _service.Editar(turma);
                return Ok();
            }   
            catch (Exception erro)
            {

                return BadRequest($"erro ao editar {erro.Message}");
            }
            
        }
    }
}
