using Aluno._02Repository;
using Aluno._03Entidades.DTO;
using Aluno._03Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Escola._02Repository;
using Escola._03Entidades;
using Escola._03Entidades.DTO;
using Escola._01Services.Interfaces;
using Escola._01Services;

namespace Api.Escolas.Controllers
{
    [ApiController]
    [Route("[controller]")] //DataNotation
    public class NotasController : ControllerBase
    {
        private readonly INotasService _service;
        private readonly IMapper _mapper; //criando o mapper a ser preenchido

        public NotasController(IMapper mapper, IConfiguration configuration, INotasService service)
        {
            string _connectionString = configuration.GetConnectionString("DefaultConnection");//Passando a connection para uma nova string
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// endpoit que lista todas as notas
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listar-Notas")]// Rota (EndPoint)
        public List<Notas> ListarNotas()
        {
            try
            {
                return _service.Listar();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao listar");
            }
            
        }

        /// <summary>
        /// endpoint para adicionar uma nota nota
        /// </summary>
        /// <param name="notDto"></param>
        [HttpPost("Adicionar-notas")]// Rota (EndPoint)
        public IActionResult AdicionarContrib(CreateNotasDTO notDto) //pegando a dto
        {
            try
            {
                Notas not = new Notas(); //pegando de um objeto e jogando para outro objeto
                not.disciplinaId = notDto.disciplinaId; //propriedades para DTO
                not.valor = notDto.valor;
                not.data = notDto.data;
                not.comentario = notDto.comentario;
                not.IdAluno = notDto.IdAluno;
                _service.Adicionar(not);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest($"Erro ao adicionar uma nota{erro.Message}");

            }

        }

        /// <summary>
        /// endpoint para buscar uma nota por id inserido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Buscar-Notas")]
        public Notas BuscarNotas(int id)
        {
            try
            {
                return _service.BuscaNotasPorId(id);
            }
            catch (Exception)
            {

                throw new Exception("erro ao buscar nota");
            }
            
        }

        /// <summary>
        /// endpoint para deletar um nota por id inserido
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("Delete-Notas")]// Rota (EndPoint)
        public IActionResult DeleteAlunos(int id)
        {
            try
            {
                _service.Remover(id);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest($"erro ao deletar uma nota");
            }
            
        }

        /// <summary>
        /// endpoint que edita uma nota por id inserido 
        /// </summary>
        /// <param name="notas"></param>
        [HttpPut("Editar-Notas")]// Rota (EndPoint)
        public IActionResult EditarNotas(Notas notas)
        {
            try
            {
                _service.Editar(notas);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest($"erro ao editar{erro.Message}");
            }
            
        }

    }
}
