
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Aluno._02Repository;
using Aluno._03Entidades;
using Escola._03Entidades.DTO;
using Escola._03Entidades;
using Escola._01Services;
using Escola._01Services.Interfaces;

namespace Api.Escolas.Controllers
{

    [ApiController]
    [Route("[controller]")] //DataNotation
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _service;
        private readonly IMapper _mapper; //criando o mapper a ser preenchido

        public FuncionarioController(IMapper mapper, IConfiguration configuration, IFuncionarioService service )
        {
            string _connectionString = configuration.GetConnectionString("DefaultConnection");//Passando a connection para uma nova string
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// endpoint para listar todos os funcionarios do banco de dados
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("Listar-Funcionarios")]// Rota (EndPoint)
        public List<Funcionarios> ListarFuncionarios()
        {
            try
            {
                return _service.Listar();
            }
            catch (Exception)
            {

                throw new Exception("Erro em listar os funcionarios");
            }
            
        }

        /// <summary>
        /// endpoint que adiciona um funcionario para o banco de dados
        /// </summary>
        /// <param name="funDto"></param>
        /// <returns></returns>
        [HttpPost("Adicionar-Funcionarios")]// Rota (EndPoint)
        public IActionResult AdicionarContrib(CreateFuncionarioDTO funDto) //pegando a dto
        {
            try
            {
                Funcionarios func = new Funcionarios(); //pegando de um objeto e jogando para outro objeto
                func.Nome = funDto.Nome;//propriedades para DTO
                func.Datanasc = funDto.Datanasc;
                func.CPF = funDto.CPF;
                func.Endereco = funDto.Endereco;
                func.Telefone = funDto.Telefone;
                func.Email = funDto.Email; 
                func.Cargo = funDto.Cargo;
                func.Salario = funDto.Salario;
                func.IdTurmasAtendidas = funDto.IdTurmasAtendidas;
                func.IdAlunos = funDto.IdAlunos;
                _service.Adicionar(func);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro em adicionar um funcionario {erro.Message}");
            }
            
        }

        /// <summary>
        /// endpoint que busca um funcionario po id no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Buscar-Funcionarios")]
        public Funcionarios BuscarFuncionarios(int id)
        {
            try
            {
                return _service.BuscarFuncionarioPorId(id);
            }
            catch (Exception)
            {
                throw new Exception("erro ao buscar um funcionario");
            }
           
        }


        /// <summary>
        /// endpoint que deleta um funcionario por id inserido
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("Delete-Funcionarios")]// Rota (EndPoint)
        public IActionResult DeleteFuncionarios(int id)
        {
            try
            {
                _service.Remover(id);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest($"erro ao deletar um funcionario{erro.Message}");
            }
            
        }

        /// <summary>
        /// endpoit que edita um funcionario por id inserido
        /// </summary>
        /// <param name="funcionario"></param>
        [HttpPut("Editar-Funcionarios")]// Rota (EndPoint)
        public IActionResult EditarFuncionarios(Funcionarios funcionario)
        {
            try
            {
                _service.Editar(funcionario);
                return Ok();
                
            }
            catch (Exception erro )
            {
                return BadRequest($"erro ao editar um funcionario{erro.Message}");
            }
            
        }
    }
}
