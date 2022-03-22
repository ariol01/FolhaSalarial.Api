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
        private readonly FuncionarioRepositorio _funcionarioRepositorio;
        public ContrachequeController(FuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }
        
        // GET api/<ContrachequeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            if (id > 0)
            {
                var funcionario = await _funcionarioRepositorio.BuscarFuncionarioPorId(id);
                var descontontosTotal = Lancamento.CalcularTotalDeDescontos(funcionario);
                var salarioLiquido = Lancamento.CalcularSalarioLiquido(funcionario,descontontosTotal);

                var contracheque = new Contracheque(descontontosTotal, salarioLiquido, funcionario);

                return Ok(contracheque);
            }
            return BadRequest();

        }

    }
}
