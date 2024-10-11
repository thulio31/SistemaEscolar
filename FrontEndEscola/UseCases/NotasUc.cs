using Escola._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscola.UseCases
{
    public class NotasUc
    {
        private readonly HttpClient _client;
        public NotasUc(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<Notas> ListarNotas()
        {
            return _client.GetFromJsonAsync<List<Notas>>("Notas/Listar-Notas").Result;
        }
        public void CadastrarNotas(Notas usuario)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Notas/Adicionar-dapper-contrib", usuario).Result;
        }
    }
}
