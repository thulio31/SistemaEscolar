using Escola._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._02Repository.Interfaces
{
    public interface INotaRepository
    {
        void Adicionar(Notas notas);
        List<Notas> ListarNotas();
        Notas BuscarNotasPorAluno(int idaluno);
        Notas BuscarNotas(int id);
        void Editar(Notas notas);
        void Delete(int id);
    }
}
