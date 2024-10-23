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
        private static Usuario UsuarioLogado { get; set; }
        private readonly UsuarioUC _usuarioUC;
        private readonly NotaRepository notaRepository; 
        private readonly NotasUc _notasUC;
        private Alunos alunos;

        public SistemaEstudante(HttpClient cliente)
        {
            _usuarioUC = new UsuarioUC(cliente);
        }
       
        public void ExibirMenuAluno()
        {
            int resposta = -1;

            
                //1 boletim == recibo 
                //olhar nota por disciplina
                Console.WriteLine(
                      "1 - Ver Boletim " +
                    "\n2 - Ver Turma"
                    );
                resposta = int.Parse(Console.ReadLine());
                
            if(resposta == 1)
            {
                ExibirBoletim();
            }
           
            else if (resposta == 2)
            {
                Console.WriteLine("1 - Ver Horarios");
                //Console.WriteLine("2 - Ver Atividades Pendentes");
                resposta = int.Parse(Console.ReadLine());
                if(resposta == 1)
                {
                    //ListarHorariosPorTurma();
                }
                else if (resposta == 2)
                {
                    //ListarAtividadesPendentesPorAlunoId();
                }

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
    }
}
