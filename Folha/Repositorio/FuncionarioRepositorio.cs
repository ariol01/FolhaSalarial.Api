using Folha.Infraestrutura;
using Folha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Folha.Repositorio
{
    public class FuncionarioRepositorio : RepositorioBase<Funcionario>
    {
        public FuncionarioRepositorio(DataFolhaContext db) : base(db)
        {

        }
        public async Task<Funcionario> BuscarFuncionarioPorId(int id)
        {
            var resultado = await _contexto.Set<Funcionario>().FirstOrDefaultAsync(x => x.Id == id);
            return resultado;
        }
    }
}
