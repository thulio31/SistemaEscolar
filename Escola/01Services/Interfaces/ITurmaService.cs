using Aluno._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._01Services.Interfaces
{
    public interface ITurmaService
    {
        void Adicionar(Turma turma);
        void Remover(int id);
        void Editar(Turma turma);
        List<Turma> Listar();
        Turma BuscarTurmaPorId(int id);
    }
}
