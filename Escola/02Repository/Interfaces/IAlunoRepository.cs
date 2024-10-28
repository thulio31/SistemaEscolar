using Aluno._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._02Repository.Interfaces
{
    public interface IAlunoRepository
    {
        void AdicionarContrib(Alunos aluno);
        List<Alunos> ListarAlunos();
        Alunos BuscarAlunos(int id);
        void Editar(Alunos aluno);
        void Delete(int id);

    }
}
