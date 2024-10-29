
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

        public FuncionarioController(IMapper mapper, IConfiguration configuration)
        {
            string _connectionString = configuration.GetConnectionString("DefaultConnection");//Passando a connection para uma nova string
            _mapper = mapper;
            _service = new FuncionarioService(_connectionString);
        }
        [HttpGet("Listar-Funcionarios")]// Rota (EndPoint)
        public List<Funcionarios> ListarFuncionarios()
        {
            return _service.Listar();
        }
        [HttpPost("Adicionar-dapper-contrib")]// Rota (EndPoint)
        public void AdicionarContrib(CreateFuncionarioDTO funDto) //pegando a dto
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
        }
        [HttpGet("Buscar-Funcionarios")]
        public Funcionarios BuscarFuncionarios(int id)
        {
            return _service.BuscarFuncionarioPorId(id);
        }

        [HttpDelete("Delete-Funcionarios")]// Rota (EndPoint)
        public void DeleteFuncionarios(int id)
        {
            _service.Remover(id);
        }

        [HttpPut("Editar-Funcionarios")]// Rota (EndPoint)
        public void EditarFuncionarios(Funcionarios funcionario)
        {
            _service.Editar(funcionario);
        }
    }
}
