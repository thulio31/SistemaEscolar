﻿using FrontEnd.Models;
using FrontEnd.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    public class SistemaFuncionario
    {
        private static Usuario UsuarioLogado { get; set; }
        private readonly UsuarioUC _usuarioUC;
        public SistemaFuncionario(HttpClient cliente)
        {
            _usuarioUC = new UsuarioUC(cliente);
        }

        public void ExibirMenuFuncionario(Usuario usuario = null)
        {
            if (UsuarioLogado == null)
            {
                UsuarioLogado = usuario;
            }
            Console.WriteLine("- - - - Escolha as opções - - - -" +
                "\n1 - Ver Turma" +
                "\n2 - Ver Alunos " +
                "\n3 - Ver Notas" +
                "\n4 - Ver Disciplinas");//salario 
            int resposta = int.Parse(Console.ReadLine());
            if (resposta == 1)//Turma
            {
                //editar excluir adicionar
            }
            else if (resposta == 2)//alunos
            {
                //editar excluir adicionar
            }
            else if (resposta == 3)//Notas
            {
                //editar excluir adicionar
            }
            else if (resposta == 4)//disciplina
            {
                //editar excluir adicionar
            }
        }
    }
}
