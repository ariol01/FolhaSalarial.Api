using Folha.Helpers;
using Folha.Models;
using Folha.Repositorio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Folha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioRepositorio _funcionarioRepositorio;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FuncionarioController(FuncionarioRepositorio funcionarioRepositorio, IHttpContextAccessor httpContextAccessor)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<FuncionarioController>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id > 0)
            {
                var funcionario = await _funcionarioRepositorio.BuscarFuncionarioPorId(id);

                return Ok(funcionario);
            }
            return NotFound("Funcionário não encontrado");
        }

        [HttpGet]
        // GET api/<FuncionarioController>/5
        public async Task<IActionResult> GetAll()
        {
            var funcionarios = await _funcionarioRepositorio.BuscarTodos();
            return Ok(funcionarios);
        }

        // POST api/<FuncionarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                if (CPFHelper.Validar(funcionario.Documento))
                {
                    try
                    {
                        var caminho = _httpContextAccessor.HttpContext.Request.Host.Value;
                        await _funcionarioRepositorio.Adicionar(funcionario);
                        var contracheque = $"https://{caminho}/api/contracheque/{funcionario.Id}";
                        var retorno = new { funcionario, contracheque };
                        return Ok(retorno);
                    }
                    catch (Exception e)
                    {
                        return Problem(e.InnerException.Message);
                        throw;
                    }

                }
            }

            return BadRequest("Informe todos os campos obrigatórios corretamente.");
        }

        // PUT api/<FuncionarioController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Funcionario funcionario)
        {
            if (funcionario is not null)
            {
                if (CPFHelper.Validar(funcionario.Documento))
                {
                    try
                    {
                        await _funcionarioRepositorio.Atualizar(funcionario);
                        return Ok($"Atualizado :\n{funcionario}");
                    }
                    catch (Exception e)
                    {
                        return Problem(e.InnerException.Message);
                        throw;
                    }

                }
            }

            return BadRequest("Informe todos os campos obrigatórios corretamente.");
        }

        // DELETE api/<FuncionarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var funcionario = await _funcionarioRepositorio.BuscarFuncionarioPorId(id);
                await _funcionarioRepositorio.Remover(funcionario);
                return Ok(funcionario);
            }
            return NotFound("Funcionário não encontrado");
        }
    }
}
