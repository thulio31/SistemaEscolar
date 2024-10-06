using FrontEnd.Models;
using FrontEnd.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    public class Sistema
    {
        private static Usuario UsuarioLogado { get; set; }
        private readonly UsuarioUC _usuarioUC;
        public Sistema (HttpClient cliente ) 
        {
            _usuarioUC = new UsuarioUC(cliente);
        }
        public void IniciarSistema()
        {
            int resposta = -1;
            while(resposta != 0)
            {
                if(UsuarioLogado == null)
                {
                    resposta = ExibirLogin();

                    if(resposta == 1)
                    {
                        FazerLogin();
                    }
                    else if (resposta == 2)
                    {
                        Usuario usuario = CriarUsuario();
                        _usuarioUC.CadastrarUsuario(usuario);
                        Console.WriteLine("Usuario cadastrado!!");
                    }
                    else if(resposta == 3)
                    {
                        List<Usuario> usuarios = _usuarioUC.ListarUsuarios();
                        foreach (Usuario us in usuarios)
                        {
                            Console.WriteLine(us.ToString());
                        }
                    }
                }
                else
                {
                    ExibirMenuPrincipal();
                }
            }
        }

        public void ExibirMenuPrincipal()
        {
            throw new NotImplementedException();
        }

        public Usuario CriarUsuario()
        {
            throw new NotImplementedException();
        }

        public void FazerLogin()
        {
            throw new NotImplementedException();
        }

        public int ExibirLogin()
        {
            throw new NotImplementedException();
        }
    }
}
