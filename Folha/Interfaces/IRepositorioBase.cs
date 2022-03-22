using Folha.Models;

namespace Folha.Interfaces
{
    public interface IRepositorioBase<T> where T : class
    {
        IQueryable<T> Query { get; }
        Task Adicionar(T entidade);
        Task<ICollection<T>> BuscarTodos();
        Task Atualizar(T entidade);
        Task Remover(T entidade);
    }
}
