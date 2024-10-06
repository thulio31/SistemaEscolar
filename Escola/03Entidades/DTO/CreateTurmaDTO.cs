﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluno._03Entidades.DTO
{
    public class CreateTurmaDTO
    {
        // Propriedades básicas
        public string Nome { get; set; }
        public int Alunos { get; set; }
        public int Vagas { get; set; }
        public double CargaHoraria { get; set; }
        public string CodigoTurma { get; set; }
        public string Status { get; set; }

        //Propriedade de Referencia 
        public int IdFuncionarioEncarregado { get; set; }
        public int IdAluno { get; set; }

    }
}