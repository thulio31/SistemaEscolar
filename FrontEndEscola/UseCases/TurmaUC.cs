using Aluno._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscola.UseCases
{
    public class TurmaUC
    {
        private readonly HttpClient _client;
        public TurmaUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<Turma> ListarTurma()
        {
            return _client.GetFromJsonAsync<List<Turma>>("Turma/Listar-Turma").Result;
        }
        public void CadastrarTurma(Turma turma)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Turma/Adicionar-turma", turma).Result;
        }
    }
}
