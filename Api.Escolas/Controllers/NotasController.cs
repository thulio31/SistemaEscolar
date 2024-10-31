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
        [HttpGet("Listar-Notas")]// Rota (EndPoint)
        public List<Notas> ListarNotas()
        {
            return _service.Listar();
        }
        [HttpPost("Adicionar-dapper-contrib")]// Rota (EndPoint)
        public void AdicionarContrib(CreateNotasDTO notDto) //pegando a dto
        {
            Notas not = new Notas(); //pegando de um objeto e jogando para outro objeto
            not.disciplinaId = notDto.disciplinaId; //propriedades para DTO
            not.valor = notDto.valor;
            not.data = notDto.data;
            not.comentario = notDto.comentario;
            not.IdAluno = notDto.IdAluno;
            _service.Adicionar(not);
        }

        [HttpGet("Buscar-Notas")]
        public Notas BuscarNotas(int id)
        {
            return _service.BuscaNotasPorId(id);
        }

        [HttpDelete("Delete-Notas")]// Rota (EndPoint)
        public void DeleteAlunos(int id)
        {
            _service.Remover(id);
        }

        [HttpPut("Editar-Notas")]// Rota (EndPoint)
        public void EditarNotas(Notas notas)
        {
            _service.Editar(notas);
        }

    }
}
