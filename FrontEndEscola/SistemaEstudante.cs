﻿using Aluno._03Entidades;
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
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    public class SistemaEstudante
    {
        private static Usuario UsuarioLogado;
        private readonly UsuarioUC _usuarioUC;
        private readonly AlunosUC _alunosUC;
        private readonly NotaRepository notaRepository; 
        private readonly NotasUc _notasUC;
        private readonly TurmaUC _turmasUC;


        private Turma turma;
        private Alunos alunos;

        public SistemaEstudante(HttpClient cliente)
        {
            _notasUC = new NotasUc(cliente);
            _turmasUC = new TurmaUC(cliente);
            alunos = new Alunos();
            turma = new Turma();
            _usuarioUC = new UsuarioUC(cliente);
            _alunosUC = new AlunosUC(cliente);
        }

        public void IniciarSistemaEstudante()
        {
            int resposta = -1;
            while (resposta != 0)
            {
                if (UsuarioLogado == null)
                {
                      resposta = ExibirMenuAluno();

                    if (resposta == 1)
                    {
                        FrontEndEscola.Models.Alunos aluno = CadastrarAluno();
                        _alunosUC.CadastrarAlunos(aluno);
                        Console.WriteLine("Usuário cadastrado com sucesso");
                    }
                    else if (resposta == 2)
                    {
                        ListarTurma();
                    }
                    else if (resposta == 3)
                    {
                        ExibirBoletim();
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

        public void AdicionarAluno()
        {
            FrontEndEscola.Models.Alunos aluno = CadastrarAluno();
            _alunosUC.CadastrarAlunos(aluno);
            Console.WriteLine("Usuário cadastrado com sucesso");
        }

        public int ExibirMenuAluno( Usuario usuario = null)
        {
            if (usuario == null) 
            {
                UsuarioLogado = usuario;
            }

            Console.WriteLine("=-=-=-=-=-=-=-= - Menu Aluno - =-=-=-=-=-=-=-=");
            Console.WriteLine("1 - Se cadastrar como aluno ");
            Console.WriteLine("2 - Ver Turma");
            Console.WriteLine("3 - Olhar Boletim");       
            Console.WriteLine("0 - Sair");       
            return int.Parse(Console.ReadLine());

        }


        public Notas ListarNotaPorAluno(int idaluno)
        {
            Notas notas = notaRepository.BuscarNotasPorAluno(idaluno);
            return notas;
        }
        public List<Notas> ExibirBoletim(int id)
        {
            List<Notas> nt = _notasUC.ListarNotas();
            FrontEndEscola.Models.Alunos aluno = _alunosUC.AlunosPorId(id);
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine($"Boletim do {aluno.Nome} Id: {aluno.id}");
            foreach (Notas notas in nt)
            {
                Console.WriteLine($"Disciplina: {notas.disciplinaId} - Nota: {notas.valor}");
            }
            
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            return nt;
        }

        public List<Turma> ListarTurma()
        {
            List<Turma> tur = _turmasUC.ListarTurma();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine($"Boletim da {turma.Nome} Id: {turma.Id}");
            foreach (Turma turma in tur)
            {
                Console.WriteLine($"Alunos: {turma.IdAluno} - Carga Horaria: {turma.CargaHoraria}");
            }
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            return tur;
        }



        public FrontEndEscola.Models.Alunos CadastrarAluno()
        {
            FrontEndEscola.Models.Alunos alunos = new FrontEndEscola.Models.Alunos();
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
