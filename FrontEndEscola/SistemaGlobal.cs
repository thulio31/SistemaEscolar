using FrontEnd;
using FrontEnd.Models;
using FrontEnd.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscola
{
    public class SistemaGlobal
    {
      
        private static Usuario UsuarioLogado { get; set; }
        private readonly UsuarioUC _usuarioUC;
        private readonly SistemaEstudante _sistemaEstudante; 
        private readonly SistemaFuncionario _sistemaFuncionario;
        public SistemaGlobal(HttpClient cliente)
        {
            _usuarioUC = new UsuarioUC(cliente);
            _sistemaEstudante = new SistemaEstudante(cliente);
            _sistemaFuncionario = new SistemaFuncionario(cliente);
        }
        public void IniciarSistema()
        {
            int resposta = -1;
            while (resposta != 0)
            {
                if (UsuarioLogado == null)
                {
                    resposta = ExibirLogin();

                    if (resposta == 1)
                    {
                        FazerLogin();
                    }
                    else if (resposta == 2)
                    {
                        Usuario usuario = CriarUsuario();
                        _usuarioUC.CadastrarUsuario(usuario);
                        Console.WriteLine("Usuário cadastrado com sucesso");
                        
                    }
                    else if (resposta == 3)
                    {
                        List<Usuario> usuarios = _usuarioUC.ListarUsuarios();
                        foreach (Usuario u in usuarios)
                        {
                            Console.WriteLine(u.ToString());
                        }
                    }
                }
               
            }
        }


        public int ExibirLogin()
        {
            Console.WriteLine("--------- LOGIN ---------");
            Console.WriteLine("1 - Deseja Fazer Login");
            Console.WriteLine("2 - Deseja se Cadastrar");
            Console.WriteLine("3 - Listar Usuario Cadastrados");
            return int.Parse(Console.ReadLine());
        }
        public Usuario CriarUsuario()
        {
            Usuario usuario = new Usuario();
            Console.WriteLine("Digite seu nome: ");
            usuario.Nome = Console.ReadLine();
            Console.WriteLine("Digite seu email: ");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            usuario.Senha = Console.ReadLine();
            Console.WriteLine("Digite seu tipo de usuario:\n1 - Funcionario\n2 - Aluno ");
            usuario.Tipo = int.Parse(Console.ReadLine());
            return usuario;
        }
       
       
        public void FazerLogin()
        {
            Console.WriteLine("Digite seu email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            UsuarioLoginDTO usuDTO = new UsuarioLoginDTO
            {
                Email = email,  
                Senha = senha,

            };
            Usuario usuario = _usuarioUC.FazerLogin(usuDTO);
            UsuarioLogado = usuario;
            IdentificarUsuario(usuario);
            if (usuario == null)
            {
                Console.WriteLine("Usuário ou senha inválidos!!!");
            }
            
        }
        public void ExibirMenuPrincipal()
        {
            Console.WriteLine("1 - Listar Produtos");
            Console.WriteLine("2 - Cadastrar Produto");
            Console.WriteLine("3 - Realizar uma compra");
            Console.WriteLine("Qual operação deseja realizar?");
            int resposta = int.Parse(Console.ReadLine());

            if(resposta == 1)
            {
                IdentificarUsuario();
            }

        }

        public void IdentificarUsuario(Usuario usuario)
        {
            if (usuario.Tipo == 1)
            {
                _sistemaFuncionario.ExibirMenuFuncionario(usuario);  
                //Console.WriteLine("teste 1");
            }
            else if (usuario.Tipo == 2)
            {
                _sistemaEstudante.ExibirMenuAluno();
                //Console.WriteLine("teste 2");
            }
            else
            {
                Console.WriteLine("Tipo de usuário não reconhecido!");
            }
        }
       

      
        
    }
}

