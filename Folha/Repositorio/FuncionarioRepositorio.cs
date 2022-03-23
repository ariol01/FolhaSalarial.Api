using Folha.Infraestrutura;
using Folha.Interfaces;
using Folha.Models;
using Microsoft.EntityFrameworkCore;

namespace Folha.Repositorio
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        protected readonly DataFolhaContext _contexto;

        public FuncionarioRepositorio(DataFolhaContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Adicionar(Funcionario funcionario)
        {
            await _contexto.AddAsync(funcionario);
          var retorno = await _contexto.SaveChangesAsync();
          return retorno;
        }

        public async Task<ICollection<Funcionario>> BuscarTodos()
        {
          return await _contexto.Funcionarios.ToListAsync();
        }

        public async Task<Funcionario> BuscarPorId(int id)
        {
            return await _contexto.Funcionarios.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task Atualizar(Funcionario funcionario)
        {
            _contexto.Update(funcionario);
            await _contexto.SaveChangesAsync();
        }

        public async Task Remover(Funcionario funcionario)
        {
             _contexto.Remove(funcionario);
             await _contexto.SaveChangesAsync();
        }
    }
}
