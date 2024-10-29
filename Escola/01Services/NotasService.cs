using Escola._01Services.Interfaces;
using Escola._02Repository;
using Escola._02Repository.Interfaces;
using Escola._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._01Services
{
    public class NotasService : INotasService
    {
        public INotaRepository repository { get; set; }

        public NotasService(string StringConnection)
        {
            repository = new NotaRepository(StringConnection);
        }

        public void Adicionar(Notas notas)
        {
            repository.Adicionar(notas);
        }

        public void Remover(int id)
        {
            repository.Delete(id);
        }

        public void Editar(Notas notas)
        {
            repository.Editar(notas);
        }

        public List<Notas> Listar()
        {
            return repository.ListarNotas();
        }

        public Notas BuscaNotasPorId(int id)
        {
            return repository.BuscarNotas(id);
        }
             
    }
}
