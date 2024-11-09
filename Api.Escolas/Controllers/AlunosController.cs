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

        public AlunosController(IMapper mapper, IConfiguration configuration, IAlunoService service )
        {
            string _connectionString = configuration.GetConnectionString("DefaultConnection");//Passando a connection para uma nova string
            _mapper = mapper;
            _service = service;
        }
        /// <summary>
        /// endpoint para listar todos os alunos do banco de dados
        /// </summary>
        /// <returns></returns>
                     

        [HttpGet("Listar-Alunos")]// Rota (EndPoint)
        public List<Alunos> ListarAlunos()
        {
            try
            {
                return _service.Listar();
                
            }
            catch (Exception)
            {

                throw new Exception("Errro ao listar");
            }
            
        }

        /// <summary>
        /// endpoint para adicionar um aluno novo no banco de dados
        /// </summary>
        /// <returns></returns>
        
        [HttpPost("Adicionar-dapper-contrib")]// Rota (EndPoint)
        public IActionResult AdicionarContrib(CreateAlunoDTO alDto) //pegando a dto
        {
            
            try
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

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// endpoint para buscar um aluno por id
        /// </summary>
        /// <returns></returns>

        [HttpGet("Buscar-Alunos")]
        public Alunos BuscarAlunos(int id)
        {
            return _service.BuscarAlunosPorId(id);
        }

        /// <summary>
        /// endpoint para deletar um aluno no banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpDelete("Delete-Alunos")]// Rota (EndPoint)
        public void DeleteAlunos(int id)
        {
            _service.Remover(id);
        }

        /// <summary>
        /// endpoint para editar um aluno novo no banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpPut("Editar-Alunos")]// Rota (EndPoint)
        public void EditarAlunos(Alunos aluno)
        {
            _service.Editar(aluno);
        }
    }
}
