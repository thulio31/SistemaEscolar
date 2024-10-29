using Escola._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._01Services.Interfaces
{
    public interface INotasService
    {
        void Adicionar(Notas notas);
        void Remover(int id);
        void Editar(Notas notas);
        List<Notas> Listar();
        Notas BuscaNotasPorId(int id);
    }
}
