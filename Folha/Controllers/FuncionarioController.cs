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
        /// <summary>
        /// Retorna o item da to-do List
        /// </summary>
        /// <param name="id"></param>
        /// <returns> O item da to-do List</returns>
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
        /// <summary>
        /// Lista os itens da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Returna os itens da To-do list cadastrados</response>
        [HttpGet]
        // GET api/<FuncionarioController>/5
        public async Task<IActionResult> GetAll()
        {
            var funcionarios = await _funcionarioRepositorio.BuscarTodos();
            return Ok(funcionarios);
        }

        /// <summary>
        /// Cria um to-do List
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns> um item criado to-do List </returns>
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

        /// <summary>
        /// Atualiza o salario da To-do List
        /// </summary>
        /// <param name="salarioBruto"></param>
        /// <param name="id"></param>
        /// <returns> um item Atualizado da to-do List</returns>
        // PUT api/<FuncionarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] double salarioBruto, int id)
        {
            if ( id > 0)
            {
                var funcioarioObj = await _funcionarioRepositorio.BuscarFuncionarioPorId(id);

                if (CPFHelper.Validar(funcioarioObj.Documento))
                {
                    try
                    {
                        funcioarioObj.AlterarSalario(salarioBruto);
                        await _funcionarioRepositorio.Atualizar(funcioarioObj);
                        return Ok(funcioarioObj);
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
        /// <summary>
        /// Remove um item da to-do List
        /// </summary>
        /// <param name="id"></param>
        /// <returns> O item é removido da to-do List</returns>
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
