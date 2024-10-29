using Aluno._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._02Repository.Interfaces
{
    public interface ITurmaRepository
    {
        void Adicionar(Turma turma);
        List<Turma> ListarTurmas();
        Turma BuscarTurmas(int id);
        void Editar(Turma turma);
        void Delete(int id);
    }
}
