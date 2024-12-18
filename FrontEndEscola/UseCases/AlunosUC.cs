﻿using FrontEndEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscola.UseCases
{
    public class AlunosUC
    {
        private readonly HttpClient _client;
        public AlunosUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<Alunos> ListarNotas()
        {
            return _client.GetFromJsonAsync<List<Alunos>>("Alunos/Listar-Alunos").Result;
        }
        public void CadastrarAlunos(Alunos alunos)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Alunos/Adicionar-alunos", alunos).Result;
        }
        public Alunos AlunosPorId(int id)
        {
            return _client.GetFromJsonAsync<Alunos>($"Alunos/Buscar-Alunos?id={id}").Result;
        }
    }
}
