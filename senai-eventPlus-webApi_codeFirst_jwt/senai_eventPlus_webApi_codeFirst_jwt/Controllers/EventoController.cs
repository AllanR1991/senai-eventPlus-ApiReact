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
    public class EventoController : ControllerBase
    {
        private IEventoRepository _evento { get; set; }

        public EventoController()
        {
            _evento = new EventoRepository();
        }

        /// <summary>
        /// Lista todas os Evento.
        /// </summary>
        /// <returns>Retorna um status code 200</returns>
        /// <response code="200">Lista de Evento exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListaTodos()
        {
            try
            {
                return StatusCode(200, _evento.Listartodos());
            }
            catch (Exception)
            {
                return StatusCode(400, "Não foi possivel listar");
            }
        }

        /// <summary>
        /// Lista todos os eventos que tem a dataEvento > hoje.
        /// </summary>
        /// <returns>Retorna um status code 200</returns>
        /// <response code="200">Lista proximos eventos exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista de proximos eventos.</response>
        [HttpGet("ListarProximos")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ProximosEventos()
        {
            try
            {
                return Ok(_evento.ListarProximos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Lista um Evento.
        /// </summary>
        /// <param name="id">Id Utilizada para buscar o Evento.</param>
        /// <returns>Retorna status code 200</returns>
        /// <response code="200">Lista de Evento exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListaUm(Guid id)
        {
            try
            {
                return StatusCode(200, _evento.ListarPorId(id));
            }
            catch (Exception)
            {
                return StatusCode(400, "Não foi possivel listar");
            }
        }


        
        /// <summary>
        /// Cadastra um novo Evento.
        /// </summary>
        /// <param name="novoEvento">Objeto do tipo Evento contendo os dados de um novo Evento.</param>
        /// <returns>Status code 201 se for criado.</returns>
        /// <response code="201">Criado Evento com sucesso.</response>
        /// <response code="400">Erro ao tentar criar um novo Evento.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Novo(Evento novoEvento)
        {
            try
            {
                _evento.Cadastrar(novoEvento);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return StatusCode(400, erro);
            }
        }

        /// <summary>
        /// Deleta um Evento se o mesmo estiver cadastrado.
        /// </summary>
        /// <param name="id">Id contendo UUID((Identificador Universal exclusivo) de um Evento.</param>
        /// <returns>Retorna um status code 204 se for deletado</returns>
        /// <response code="204">Evento deletado com sucesso.</response>
        /// <response code="404">Evento não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Deletar(Guid id)
        {

            try
            {
                Evento eventoEncontrado = _evento.ListarPorId(id);
                if (eventoEncontrado != null)
                {
                    _evento.Deletar(id);
                    return StatusCode(204);
                }
                return StatusCode(404, "Evento não encontrado.");
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Erro = erro, Mensagem = "Ocorreu um Erro" });
            }


        }

        /// <summary>
        /// Altera dados cadastrados de um Evento.
        /// </summary>
        /// <param name="id">Id  utilizada para localizar o Evento a ser alterado.</param>
        /// <param name="eventoAlterado">Objeto do tipo Evento contendo as alterações do Evento.</param>
        /// <returns>Retorna um status code 204 se for alterado</returns>
        /// <response code="204">Evento alterado com sucesso.</response>
        /// <response code="404">Evento não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Alterar(Guid id, Evento eventoAlterado)
        {
            try
            {
                Evento eventoEncontrado = _evento.ListarPorId(id);
                if (eventoEncontrado != null)
                {
                    _evento.Alterar(id, eventoAlterado);
                    return StatusCode(204);
                }
                return StatusCode(404, "Evento não encontrado.");
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Erro = erro, Mensagem = "Ocorreu um Erro" });
            }
        }
    }
}
