using Escola._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._01Services.Interfaces
{
    public interface IFuncionarioService
    {
        void Adicionar(Funcionarios funcionario);
        void Remover(int id);
        void Editar(Funcionarios funcionario);
        List<Funcionarios> Listar();
        Funcionarios BuscarFuncionarioPorId(int id);

    }
        
}
