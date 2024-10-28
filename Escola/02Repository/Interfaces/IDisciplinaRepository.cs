using Escola._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._02Repository.Interfaces
{
    public interface IDisciplinaRepository
    {
        void Adicionar(Disciplina disciplina);
        List<Disciplina> ListarDisciplinas();
        Disciplina BuscarDisciplinas(int id);
        void Editar(Disciplina disciplina);
        void Delete(int id);
    }
}
