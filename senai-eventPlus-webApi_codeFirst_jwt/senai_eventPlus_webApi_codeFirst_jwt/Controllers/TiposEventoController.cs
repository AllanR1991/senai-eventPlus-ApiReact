using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_eventPlus_webApi_codeFirst_jwt.Domains;
using senai_eventPlus_webApi_codeFirst_jwt.Interfaces;
using senai_eventPlus_webApi_codeFirst_jwt.Repositories;

namespace senai_eventPlus_webApi_codeFirst_jwt.Controllers
{
    //  Garante que os retornos sejão em JSON.
    [Produces("application/json")]
    //  Define que a rotas de uma requisição será no formato dominio/api/nomeController
    [Route("api/[controller]")]
    //  Define que é um controladdor de API.
    [ApiController]
    public class TiposEventoController : ControllerBase
    {
        private ITiposEventoRepository _tiposEvento { get; set; }

        public TiposEventoController()
        {
            _tiposEvento = new TiposEventoRepository();
        }

        /// <summary>
        /// Lista todos os tiposEvento.
        /// </summary>
        /// <returns>Retorna um status code 200</returns>
        /// <response code="200">Lista de tiposEvento exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListaTodos()
        {
            try
            {
                return StatusCode(200, _tiposEvento.Listartodos());
            }
            catch (Exception)
            {
                return StatusCode(400, "Não foi possivel listar");
            }
        }

        /// <summary>
        /// Lista um tiposEvento.
        /// </summary>
        /// <param name="id">Id Utilizada para buscar o tiposEvento.</param>
        /// <returns>Retorna status code 200</returns>
        /// <response code="200">Lista de tiposEvento exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListaUm(Guid id)
        {
            try
            {
                return StatusCode(200, _tiposEvento.ListarPorId(id));
            }
            catch (Exception)
            {
                return StatusCode(400, "Não foi possivel listar");
            }
        }



        /// <summary>
        /// Cadastra um novo tiposEvento.
        /// </summary>
        /// <param name="novoTiposEvento">Objeto do tipo tiposEvento contendo os dados de um novo tiposEvento.</param>
        /// <returns>Status code 201 se for criado.</returns>
        /// <response code="201">Criado tiposEvento com sucesso.</response>
        /// <response code="400">Erro ao tentar criar um novo tiposEvento.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Novo(TiposEvento novoTiposEvento)
        {
            try
            {
                _tiposEvento.Cadastrar(novoTiposEvento);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return StatusCode(400, erro);
            }
        }

        /// <summary>
        /// Deleta um tiposEvento se o mesmo estiver cadastrado.
        /// </summary>
        /// <param name="id">Id contendo UUID((Identificador Universal exclusivo) de um tiposEvento.</param>
        /// <returns>Retorna um status code 204 se for deletado</returns>
        /// <response code="204">tiposEvento deletado com sucesso.</response>
        /// <response code="404">tiposEvento não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Deletar(Guid id)
        {

            try
            {
                TiposEvento tiposEventoEncontrado = _tiposEvento.ListarPorId(id);
                if (tiposEventoEncontrado != null)
                {
                    _tiposEvento.Deletar(id);
                    return StatusCode(204);
                }
                return StatusCode(404, "tiposEvento não encontrado.");
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Erro = erro, Mensagem = "Ocorreu um Erro" });
            }


        }

        /// <summary>
        /// Altera dados cadastrados de um tiposEvento.
        /// </summary>
        /// <param name="id">Id  utilizada para localizar o tiposEvento a ser alterado.</param>
        /// <param name="tiposEventoAlterado">Objeto do tipo tiposEvento contendo as alterações do tiposEvento.</param>
        /// <returns>Retorna um status code 204 se for alterado</returns>
        /// <response code="204">tiposEvento alterado com sucesso.</response>
        /// <response code="404">tiposEvento não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Alterar(Guid id, TiposEvento tiposEventoAlterado)
        {
            try
            {
                TiposEvento tiposEventoEncontrado = _tiposEvento.ListarPorId(id);
                if (tiposEventoEncontrado != null)
                {
                    _tiposEvento.Alterar(id, tiposEventoAlterado);
                    return StatusCode(204);
                }
                return StatusCode(404, "tiposEvento não encontrado.");
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Erro = erro, Mensagem = "Ocorreu um Erro" });
            }
        }
    }
}
