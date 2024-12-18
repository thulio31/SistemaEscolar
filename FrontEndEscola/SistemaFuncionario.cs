

using Core.Entidades;
using Escola._03Entidades;
using FrontEnd.UseCases;
using FrontEndEscola.Models;
using FrontEndEscola.UseCases;

namespace FrontEnd
{
    public class SistemaFuncionario
    {
        private static FrontEnd.Models.Usuario UsuarioLogado { get; set; }
        private readonly UsuarioUC _usuarioUC;
        private readonly NotasUc _notasUC;
        private readonly FuncionarioUC _funcionarioUC;
        public SistemaFuncionario(HttpClient cliente)
        {
            _usuarioUC = new UsuarioUC(cliente);
            _funcionarioUC = new FuncionarioUC(cliente);
            _notasUC = new NotasUc(cliente);
        }

        //public void ExibirMenuFuncionario(Usuario usuario = null)
        //{
        //    if (UsuarioLogado == null)
        //    {
        //        UsuarioLogado = usuario;
        //    }
        //    Console.WriteLine("- - - - Escolha as opções - - - -" +
        //        "\n1 - Ver Turma" +
        //        "\n2 - Ver Alunos " +
        //        "\n3 - Ver Notas" +
        //        "\n4 - Ver Disciplinas");//salario 
        //    int resposta = int.Parse(Console.ReadLine());
        //    if (resposta == 1)//Turma
        //    {
        //        //editar excluir adicionar
        //    }
        //    else if (resposta == 2)//alunos
        //    {
        //        //editar excluir adicionar
        //    }
        //    else if (resposta == 3)//Notas
        //    {
        //        //editar excluir adicionar
        //    }
        //    else if (resposta == 4)//disciplina
        //    {
        //        //editar excluir adicionar
        //    }
        //}

        public void IniciarSistemaFuncionario()
        {
            int resposta = -1;
            while (resposta != 0)
            {
                if (UsuarioLogado == null)
                {
                    resposta = ExibirMenuFuncionario();

                    if (resposta == 1)
                    {
                        Funcionarios funcionario = CadastrarFuncionario();
                        _funcionarioUC.CadastrarFuncionarios(funcionario);
                        Console.WriteLine("Funcionario cadastrado com sucesso");
                    }
                    else if (resposta == 2)
                    {
                        //ListarNotas();
                    }
                    else if (resposta == 3)
                    {
                        //ExibirBoletim();
                    }
                    else if (resposta == 0)//Encerrar o loop
                    {
                        Console.WriteLine("Saindo do sistema...");
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida! Tente novamente.");
                    }
                }

            }
        }

        public int ExibirMenuFuncionario(FrontEnd.Models.Usuario usuario = null)
        {
            if (usuario == null)
            {
                UsuarioLogado = usuario;
            }

            Console.WriteLine("=-=-=-=-=-=-=-= - Menu Funcionario - =-=-=-=-=-=-=-=");
            Console.WriteLine("1 - Cadastrar novo Funcionario ");
            Console.WriteLine("2 - Ver Notas");
            Console.WriteLine("3 - Editar Funcionario");
            Console.WriteLine("4 - Excluir Funcionário");
            Console.WriteLine("5 - Consultar Funcionário");
            Console.WriteLine("0 - Sair");
            return int.Parse(Console.ReadLine());

        }


        public Funcionarios CadastrarFuncionario()
        {
            Funcionarios func = new ();
            Console.WriteLine("Digite seu nome: ");
            func.Nome = Console.ReadLine();
            Console.WriteLine("Digite sua Data de Nascimento: ");
            func.Datanasc = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Digite sua Matricula: ");
            func.CPF = Console.ReadLine();
            Console.WriteLine("Digite seu Endereço: ");
            func.Endereco = Console.ReadLine();
            Console.WriteLine("Digite seu telefone: ");
            func.Telefone = Console.ReadLine();
            Console.WriteLine("Digite seu email: ");
            func.Email = Console.ReadLine();
            Console.WriteLine("Digite seu cargo: ");
            func.Cargo = Console.ReadLine();
            Console.WriteLine("Digite seu salario: ");
            func.Salario = double.Parse(Console.ReadLine());
            return func;
        }

        //public List<Notas> ListarNotas()
        //{
        //    List<Notas> nt = _notasUC;
        //    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
        //    Console.WriteLine("Notas");
        //    foreach (Escola._03Entidades.Notas notas in nt)
        //    {
        //        Console.WriteLine(notas);
        //    }

        //    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
        //    return nt;
        //}
    }
}
