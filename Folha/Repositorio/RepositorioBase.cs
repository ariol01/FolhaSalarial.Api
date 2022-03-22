using Folha.Infraestrutura;
using Folha.Interfaces;
using Folha.Models;
using Microsoft.EntityFrameworkCore;

namespace Folha.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected readonly DataFolhaContext _contexto;
        public IQueryable<T> Query => _contexto.Set<T>();

        public RepositorioBase(DataFolhaContext db)
        {
            _contexto = db;
        }

        public async Task Adicionar(T entidade)
        {
            await _contexto.AddAsync(entidade);
            await _contexto.SaveChangesAsync();
        }

        public async Task<ICollection<T>> BuscarTodos()
        {
            var resultados = await _contexto.Set<T>().ToListAsync();
            return resultados;
        }

       public async Task AdicionarVarios(IEnumerable<T> entidades)
        {
            await _contexto.AddRangeAsync(entidades);
            await _contexto.SaveChangesAsync();
        }

        public async Task Atualizar(T entidade)
        {
            _contexto.Update(entidade);
            await _contexto.SaveChangesAsync();
        }

        public async Task Remover(T entidade)
        {
            _contexto.Remove(entidade);
            await _contexto.SaveChangesAsync();
        }

        public void IDisposableDispose()
        {
            _contexto.Dispose();
        }
    }
}
