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

        public DisciplinaController(IMapper mapper, IConfiguration configuration, IDisciplinaService service)
        {
            string _connectionString = configuration.GetConnectionString("DefaultConnection");//Passando a connection para uma nova string
            _mapper = mapper;
            _service = service;
        }


        /// <summary>
        /// endpoint para listar todos as disciplina do banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listar-Disciplina")]// Rota (EndPoint)
        public List<Disciplina> ListarDisciplina()
        {
            
            try
            {
                return _service.Listar();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar as disciplinas");
            }

        }


        /// /// <summary>
        /// endpoint para adicionar uma disciplina novo no banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpPost("Adicionar-disciplina")]// Rota (EndPoint)
        public IActionResult AdicionarContrib(CreateDisciplinaDTO discDto) //pegando a dto
        {
            try
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

                return Ok();
            }
            catch (Exception erro)//
            {
                return BadRequest($"Ocorreu um erro ao adicionar a disciplina," +
                    $"\n {erro.Message}");
            }
            
        }



        /// <summary>
        /// endpoint para buscar uma disciplina por id
        /// </summary>
        /// <returns></returns>
        [HttpGet("Buscar-Disciplina")]
        public Disciplina BuscarDisciplina(int id)
        {
            try
            {
                return _service.BuscarDisciplinaPorId(id);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao buscar disciplina por id");
            }
            
        }

        /// <summary>
        /// endpoint para deletar uma disciplina no banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpDelete("Delete-Disciplina")]// Rota (EndPoint)
        public IActionResult DeleteDisciplina(int id)
        {
            try
            {
                _service.Remover(id);
                return Ok();
            }
            catch (Exception erro )
            {
                return BadRequest($"Erro ao deletar disciplina {erro.Message}");
            }
            
        }

        /// <summary>
        /// endpoint para editar uma disciplina novo no banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpPut("Editar-Disciplina")]// Rota (EndPoint)
        public IActionResult EditarDisciplina(Disciplina disciplina)
        {
            try
            {
                _service.Editar(disciplina);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao editar disciplina {erro.Message}");

                
            }
            
        }
    }
}
