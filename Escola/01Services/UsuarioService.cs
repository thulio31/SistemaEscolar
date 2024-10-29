using Core._03_Entidades.DTO.Usuarios;
using Core.Entidades;
using Escola._01Services.Interfaces;
using Escola._02Repository.Interfaces;
using TrabalhoFinal._02_Repository;

namespace TrabalhoFinal._01_Services;

public class UsuarioService : IUsuarioService
{
    public IUsuarioRepository repository { get; set; }
    public UsuarioService(string _config)
    {
        repository = new UsuarioRepository(_config);
    }
    public void Adicionar(Usuario usuario)
    {
        repository.Adicionar(usuario);
    }

    public void Remover(int id)
    {
        repository.Remover(id);
    }

    public List<Usuario> Listar()
    {
        return repository.Listar();
    }
    public Usuario BuscarTimePorId(int id)
    {
        return repository.BuscarPorId(id);
    }
    public void Editar(Usuario editPessoa)
    {
        repository.Editar(editPessoa);
    }
    public Usuario FazerLogin(UsuarioLoginDTO usuarioLogin)
    {
        List<Usuario> listUsuario = Listar();
        foreach (Usuario usuario in listUsuario)
        {
            if(usuario.Email == usuarioLogin.Email
                && usuario.Senha == usuarioLogin.Senha)
            {
                return usuario;
            }
        }
        return null;
    }
}
