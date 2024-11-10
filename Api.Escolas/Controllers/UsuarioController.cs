using AutoMapper;
using Core._03_Entidades.DTO.Usuarios;
using Core.Entidades;
using Escola._01Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Services;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;
    private readonly IMapper _mapper;
    public UsuarioController(IConfiguration config, IMapper mapper, IUsuarioService service )
    {
        string _config = config.GetConnectionString("DefaultConnection");
        _service = service;
        _mapper = mapper;
    }

    /// <summary>
    /// endpoint que adiciona um aluno no banco de dados
    /// </summary>
    /// <param name="usuario"></param>
    /// <returns></returns>
    [HttpPost("adicionar-usuario")]
    public Usuario AdicionarAluno(Usuario usuario)
    {
        try
        {
            _service.Adicionar(usuario);
            return usuario;
        }
        catch (Exception)
        {

            throw new Exception("erro ao adicionar");
        }
        
    }

    /// <summary>
    /// endpoint para o usuario fazer login
    /// </summary>
    /// <param name="usuarioLogin"></param>
    /// <returns></returns>
    [HttpPost("fazer-login")]
    public Usuario FazerLogin(UsuarioLoginDTO usuarioLogin)
    {
        try
        {
            Usuario usuario = _service.FazerLogin(usuarioLogin);
            return usuario;
        }
        catch (Exception)
        {

            throw new Exception("erro ao fazer login");
        }
        
    }

    /// <summary>
    /// endpoint que lista alunos no banco de dados 
    /// </summary>
    /// <returns></returns> 
    [HttpGet("listar-usuario")]
    public List<Usuario> ListarAluno()
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
    /// endpoint que edita um usuario por id inserido
    /// </summary>
    /// <param name="p"></param>
    [HttpPut("editar-usuario")]
    public IActionResult EditarUsuario(Usuario p)
    {
        try
        {
            _service.Editar(p);
            return Ok();

        }
        catch (Exception erro)
        {
            return BadRequest($"erro ao editar {erro.Message}");           
        }
        
    }

    /// <summary>
    /// endpoint que deleta usuario por id inserido
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("deletar-usuario")]
    public IActionResult DeletarUsuario(int id)
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
}
