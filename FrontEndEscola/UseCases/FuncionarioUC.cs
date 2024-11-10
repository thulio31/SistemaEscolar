using Escola._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscola.UseCases
{
    public class FuncionarioUC
    {
        private readonly HttpClient _client;
        public FuncionarioUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<Funcionarios> ListarFuncionarios()
        {
            return _client.GetFromJsonAsync<List<Funcionarios>>("Funcionarios/Listar-Funcionarios").Result;
        }
        public void CadastrarFuncionarios(Funcionarios funcionarios)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Funcionarios/Adicionar-Funcionarios", funcionarios).Result;
        }
    }
}
