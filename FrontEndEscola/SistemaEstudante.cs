using FrontEnd.Models;
using FrontEnd.UseCases;
using FrontEndEscola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    public class SistemaEstudante
    {
        private static Usuario UsuarioLogado { get; set; }
        private static SistemaGlobal sistemaG { get; set; }
        private readonly UsuarioUC _usuarioUC;
        public SistemaEstudante(HttpClient cliente)
        {
            _usuarioUC = new UsuarioUC(cliente);
            sistemaG = new SistemaGlobal(cliente);  
        }
        public void IniciarSistema()
        {
            int resposta = -1;
            while (resposta != 0)
            {
                if (UsuarioLogado.Tipo == "Estudante")
                {
                    ExibirMenuEstudante();
                }
                else
                {
                    //sistemaG.ExibirMenuPrincipal();
                }
            }
        }
        public void ExibirMenuEstudante()
        {
            int resposta = -1;

            
                //1 boletim == recibo 
                //olhar nota por disciplina
                Console.WriteLine("1 - Olhar Notas " +
                    "\n2 - Ver materias de disciplina" +
                    "\n3 - Ver Turma");
                resposta = int.Parse(Console.ReadLine());
                
            if(resposta == 1)
            {
                Console.WriteLine("1 - Deseja olhar por disciplina" +
                "\n2 - Deseja olhar por boletim ");

                resposta= int.Parse(Console.ReadLine()); 
                if(resposta == 1)
                {
                    //ListarNotaPorDisciplina();
                }
                else if (resposta == 1)
                {
                    //ListarBoletimNotas();
                }
            }
            else if (resposta == 2) 
            {
                //ListarMateriaPorDisciplina();
            }
            else if (resposta == 3)
            {
                Console.WriteLine("1 - Ver Horarios");
                Console.WriteLine("2 - Ver Atividades Pendentes");
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
            
            //criar metodos e sua designações//
            
        }

    }
}
