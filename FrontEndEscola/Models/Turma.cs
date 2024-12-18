﻿using FrontEndEscola.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluno._03Entidades
{
    public class Turma
    {
        // Propriedades básicas
        public int Id { get; set; }
        public string  Nome { get; set; }
        public int Alunos { get; set; }
        public int Vagas { get; set; }
        public double CargaHoraria { get; set; }
        public string CodigoTurma { get; set; }
        public string Status { get; set;}


        //Propriedade de Referencia 
        public int IdFuncionarioEncarregado { get; set; }
        public int IdAluno { get; set; }


        public override string ToString()
        {
            return $"Id: {Id} - Nome: {Nome} - Alunos: {Alunos} - Vagas: {Vagas}  " +
                $"\nCargaHoraria: {CargaHoraria} - CodigoTurma {CodigoTurma} - Status: {Status}" +
                $"\nIdFuncionarioEncarregado: {IdFuncionarioEncarregado} - IdAluno: {IdAluno}";
        }

    }
}
