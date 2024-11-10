using Escola._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscola.UseCases
{
    public class DisciplinaUC
    {
        private readonly HttpClient _client;
        public DisciplinaUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<Disciplina> ListarDisciplina()
        {
            return _client.GetFromJsonAsync<List<Disciplina>>("Disciplina/Listar-disciplina").Result;
        }
        public void CadastrarDisciplina(Disciplina disciplina)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Disciplina/Adicionar-disciplina", disciplina).Result;
        }
    }
}
