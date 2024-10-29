using Aluno._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._01Services.Interfaces
{
    public interface IAlunoService
    {
        void Adicionar(Alunos aluno);
        void Remover(int id);
        void Editar(Alunos aluno);
        List<Alunos> Listar();
        Alunos BuscarAlunosPorId(int id);
    }
}
