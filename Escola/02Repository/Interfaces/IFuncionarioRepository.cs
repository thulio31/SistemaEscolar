using Escola._03Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola._02Repository.Interfaces
{
    public interface IFuncionarioRepository
    {
        void Adicionar(Funcionarios funcionario);
        List<Funcionarios> ListarFuncionarios();
        Funcionarios BuscarFuncionarios(int id);
        void Editar(Funcionarios funcionario);
        void Delete(int id);

    }
}
