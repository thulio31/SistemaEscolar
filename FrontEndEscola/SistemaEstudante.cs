using Aluno._03Entidades;
using Dapper.Contrib.Extensions;
using Escola._02Repository;
using Escola._03Entidades;
using FrontEnd.Models;
using FrontEnd.UseCases;
using FrontEndEscola;
using FrontEndEscola.UseCases;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    public class SistemaEstudante
    {
        private static Usuario UsuarioLogado;
        private readonly UsuarioUC _usuarioUC;
        private readonly NotaRepository notaRepository; 
        private readonly NotasUc _notasUC;
        private Alunos alunos;

        public SistemaEstudante(HttpClient cliente)
        {
            _usuarioUC = new UsuarioUC(cliente);
        }
       
        public void ExibirMenuAluno( Usuario usuario = null)
        {
            if (usuario == null) 
            {
                UsuarioLogado = usuario;
            }
                        
                //1 boletim == recibo 
                //olhar nota por disciplina

                Console.WriteLine(
                      "1 - Se cadastrar como aluno " +
                    "\n2 - Ver Turma" +
                    "\n3 - Olhar Boletim"
                    );
            int resposta = int.Parse(Console.ReadLine());
                
            if(resposta == 1)
            {
                CadastrarAluno();
            }
           
            else if (resposta == 2)
            {
                //listar alunos por turma
                Console.WriteLine("1 - Ver Horarios");
                resposta = int.Parse(Console.ReadLine());
                if(resposta == 1)
                {
                    //ListarHorariosPorTurma();
                    //Validaçao de horarios iguais
                }               

            }
            else if (resposta == 3)
            {
                ExibirBoletim();
            }

            else
            {
                Console.WriteLine("Opção nao disponivel!!");
                ExibirMenuAluno();
            }


        }
        public Notas ListarNotaPorAluno(int idaluno)
        {
            Notas notas = notaRepository.BuscarNotasPorAluno(idaluno);
            return notas;
        }
        public void ExibirBoletim()
        {
            List<Notas> nt = _notasUC.ListarNotas();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine($"Boletim do {alunos.Nome} Id: {alunos.Id}");
            foreach (Notas notas in nt)
            {
                Console.WriteLine($"Disciplina: {notas.disciplinaId} - Nota: {notas.valor}");
            }  
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
        }

        public Alunos CadastrarAluno()
        {
            Alunos alunos = new Alunos();
            Console.WriteLine("Digite seu nome: ");
            alunos.Nome = Console.ReadLine();
            Console.WriteLine("Digite sua idade: ");
            alunos.Idade = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite sua Matricula: ");
            alunos.Matricula = Console.ReadLine();
            Console.WriteLine("Digite seu telefone: ");
            alunos.Telefone = Console.ReadLine();
            Console.WriteLine("Digite sua serie: ");
            alunos.Serie = Console.ReadLine();
            Console.WriteLine("Digite sua turma: ");
            alunos.Turma = Console.ReadLine();
            return alunos;
        }
    }
}
