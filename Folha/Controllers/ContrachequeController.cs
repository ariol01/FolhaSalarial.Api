using Folha.Interfaces;
using Folha.Models;
using Folha.Repositorio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Folha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContrachequeController : ControllerBase
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public ContrachequeController(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }
        
        /// <summary>
        /// Lista o contracheque de um funcionário da to-do List
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o contracheque do funcionário da to-do List</returns>
        // GET api/<ContrachequeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            if (id > 0)
            {
                var funcionario = await _funcionarioRepositorio.BuscarPorId(id);
                var descontontosTotal = Lancamento.CalcularTotalDeDescontos(funcionario);
                var salarioLiquido = Lancamento.CalcularSalarioLiquido(funcionario,descontontosTotal);

                var contracheque = new Contracheque(descontontosTotal, salarioLiquido, funcionario);

                return Ok(contracheque);
            }
            return BadRequest();

        }

    }
}
