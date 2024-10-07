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
            Console.WriteLine("1 - Listar Usuarios por tipos");
            Console.WriteLine("2 - Cadastrar Produto");
            Console.WriteLine("3 - Realizar uma compra");
            Console.WriteLine("Qual operação deseja realizar?");
            int resposta = int.Parse(Console.ReadLine());
        }

        public Usuario CriarUsuario()
        {
            Usuario usuario = new Usuario();
            Console.WriteLine("Digite o seu nome");
            usuario.Nome = Console.ReadLine();
            Console.WriteLine("Digite sua senha");
            usuario.Senha = Console.ReadLine();
            Console.WriteLine("Digite seu email");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Digite o seu tipo de usuario");
            usuario.Tipo = Console.ReadLine();
            return usuario;
        }

        public void FazerLogin()
        {
            Console.WriteLine("Digite o seu email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            Console.WriteLine("Digite o tipo de usuario: ");
            string tipo = Console.ReadLine();
            UsuarioLoginDTO usuDTO = new UsuarioLoginDTO
            {
                Email = email,
                Senha = senha,
                Tipo = tipo
            };
            Usuario usuario = _usuarioUC.FazerLogin(usuDTO);
            if (usuario == null)
            {
                Console.WriteLine("Usuário ou senha inválidos!!!");
            }
            UsuarioLogado = usuario;
        }

        public int ExibirLogin()
        {
            Console.WriteLine("--------- LOGIN ---------");
            Console.WriteLine("1 - Deseja Fazer Login");
            Console.WriteLine("2 - Deseja se Cadastrar");
            Console.WriteLine("3 - Listar Usuario Cadastrados");
            return int.Parse(Console.ReadLine());
        }

    }
}
