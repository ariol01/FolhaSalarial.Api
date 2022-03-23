using Folha.Models;

namespace Folha.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        Task Adicionar(Funcionario funcionario);
        Task<ICollection<Funcionario>> BuscarTodos();
        Task<Funcionario> BuscarPorId(int id);
        Task Atualizar(Funcionario funcionario);
        Task Remover(Funcionario funcionario);
    }
}
