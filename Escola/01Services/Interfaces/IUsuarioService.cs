using Core._03_Entidades.DTO.Usuarios;
using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._01Services.Interfaces
{
    public interface IUsuarioService
    {
        void Adicionar(Usuario usuario);
        void Remover(int id);
        List<Usuario> Listar();
        Usuario BuscarTimePorId(int id);
        void Editar(Usuario editPessoa);
        Usuario FazerLogin(UsuarioLoginDTO usuarioLogin);
    }
}
