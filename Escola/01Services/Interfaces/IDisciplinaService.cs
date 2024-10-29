using Escola._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._01Services.Interfaces
{
    public interface IDisciplinaService
    {
        void Adicionar(Disciplina disciplina);
        void Remover(int id);
        void Editar(Disciplina disciplina);
        List<Disciplina> Listar();
        Disciplina BuscarDisciplinaPorId(int id);
    }
}
