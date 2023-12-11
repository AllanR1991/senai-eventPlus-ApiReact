    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_eventPlus_webApi_codeFirst_jwt.Domains;
using senai_eventPlus_webApi_codeFirst_jwt.Interfaces;
using senai_eventPlus_webApi_codeFirst_jwt.Repositories;

namespace senai_eventPlus_webApi_codeFirst_jwt.Controllers
{
    //  Garante que os retornos sejão em JSON
    [Produces("application/json")]
    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    [Route("api/[controller]")]
    //  Define que é um controladdor de API.
    [ApiController]
    public class PresencasEventoController : ControllerBase
    {
        private IPresencasEventoRepository _presencasEvento { get; set; }

        public PresencasEventoController()
        {
            _presencasEvento = new PresencasEventoRepository();
        }

        /// <summary>
        /// Lista todos as PresencasEvento.
        /// </summary>
        /// <returns>Retorna um status code 200</returns>
        /// <response code="200">Lista de PresencasEvento exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListaTodos()
        {
            try
            {
                return StatusCode(200, _presencasEvento.ListarTodos());
            }
            catch (Exception)
            {
                return StatusCode(400, "Não foi possivel listar");
            }
        }

        /// <summary>
        /// Lista uma PresencasEvento.
        /// </summary>
        /// <param name="id">Id Utilizada para buscar o PresencasEvento.</param>
        /// <returns>Retorna status code 200</returns>
        /// <response code="200">Lista de PresencasEvento exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListaUm(Guid id)
        {
            try
            {
                return StatusCode(200, _presencasEvento.ListarPorId(id));
            }
            catch (Exception)
            {
                return StatusCode(400, "Não foi possivel listar");
            }
        }



        /// <summary>
        /// Cadastra um novo PresencasEvento.
        /// </summary>
        /// <param name="novoPresencasEvento">Objeto do tipo PresencasEvento contendo os dados de um novo PresencasEvento.</param>
        /// <returns>Status code 201 se for criado.</returns>
        /// <response code="201">Criado PresencasEvento com sucesso.</response>
        /// <response code="400">Erro ao tentar criar um novo PresencasEvento.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Novo(PresencasEvento novoPresencasEvento)
        {
            try
            {
                _presencasEvento.Cadastrar(novoPresencasEvento);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return StatusCode(400, erro);
            }
        }

        /// <summary>
        /// Deleta um PresencasEvento se o mesmo estiver cadastrado.
        /// </summary>
        /// <param name="id">Id contendo UUID((Identificador Universal exclusivo) de um PresencasEvento.</param>
        /// <returns>Retorna um status code 204 se for deletado</returns>
        /// <response code="204">PresencasEvento deletado com sucesso.</response>
        /// <response code="404">PresencasEvento não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Deletar(Guid id)
        {

            try
            {
                PresencasEvento presencasEventoEncontrado = _presencasEvento.ListarPorId(id);
                if (presencasEventoEncontrado != null)
                {
                    _presencasEvento.Deletar(id);
                    return StatusCode(204);
                }
                return StatusCode(404, "PresencasEvento não encontrado.");
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Erro = erro, Mensagem = "Ocorreu um Erro" });
            }


        }

        /// <summary>
        /// Altera dados cadastrados de um PresencasEvento.
        /// </summary>
        /// <param name="id">Id  utilizada para localizar o PresencasEvento a ser alterado.</param>
        /// <param name="presencasEventoAlterado">Objeto do tipo PresencasEvento contendo as alterações do PresencasEvento.</param>
        /// <returns>Retorna um status code 204 se for alterado</returns>
        /// <response code="204">PresencasEvento alterado com sucesso.</response>
        /// <response code="404">PresencasEvento não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Alterar(Guid id, PresencasEvento presencasEventoAlterado)
        {
            try
            {
                PresencasEvento presencasEventoEncontrado = _presencasEvento.ListarPorId(id);
                if (presencasEventoEncontrado != null)
                {
                    _presencasEvento.Alterar(id, presencasEventoAlterado);
                    return StatusCode(204);
                }
                return StatusCode(404, "PresencasEvento não encontrado.");
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Erro = erro, Mensagem = "Ocorreu um Erro" });
            }
        }


        [HttpGet("ListarMinhas/{id}")]
        public IActionResult GetMyList(Guid id)
        {
            try
            {
                return Ok(_presencasEvento.ListarMinhas(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
