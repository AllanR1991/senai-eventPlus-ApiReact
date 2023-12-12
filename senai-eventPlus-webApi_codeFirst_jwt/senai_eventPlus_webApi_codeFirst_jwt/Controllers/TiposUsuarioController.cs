using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_eventPlus_webApi_codeFirst_jwt.Domains;
using senai_eventPlus_webApi_codeFirst_jwt.Interfaces;
using senai_eventPlus_webApi_codeFirst_jwt.Repositories;

namespace senai_eventPlus_webApi_codeFirst_jwt.Controllers
{
    //  Garante que os retornos sejão em formato JSON.
    [Produces("application/json")]
    //  Define que a rota de uma requisição será no formato domínio/api/nomeController.
    [Route("api/[controller]")]
    //  Define que é um controlador de API.
    [ApiController]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuario { get; set; }

        public TiposUsuarioController()
        {
            _tiposUsuario = new TiposUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos usuário.
        /// </summary>
        /// <returns>Retorna um status code 200</returns>
        /// <response code="200">Lista de tipos usuário exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListaTodos()
        {
            try
            {
                return StatusCode(200, _tiposUsuario.Listartodos());
            }
            catch (Exception)
            {
                return StatusCode(400, "Não foi possivel listar");
            }
        }

        /// <summary>
        /// Lista um tipos usuário.
        /// </summary>
        /// <param name="id">Id Utilizada para buscar o tipos usuário.</param>
        /// <returns>Retorna status code 200</returns>
        /// <response code="200">Lista de tipos usuário exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListaUm(Guid id)
        {
            try
            {
                return StatusCode(200, _tiposUsuario.ListarPorId(id));
            }
            catch (Exception)
            {
                return StatusCode(400, "Não foi possivel listar");
            }
        }



        /// <summary>
        /// Cadastra um novo tipos usuário.
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto do tipos usuário contendo os dados de um novo tipos usuário.</param>
        /// <returns>Status code 201 se for criado.</returns>
        /// <response code="201">Criado tipos usuário com sucesso.</response>
        /// <response code="400">Erro ao tentar criar um novo tipos usuário.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Novo(TiposUsuario novoTipoUsuario)
        {
            try
            {
                _tiposUsuario.Cadastrar(novoTipoUsuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return StatusCode(400, erro);
            }
        }

        /// <summary>
        /// Deleta um tipos usuário se o mesmo estiver cadastrado.
        /// </summary>
        /// <param name="id">Id contendo UUID((Identificador Universal exclusivo) de um tipos usuário.</param>
        /// <returns>Retorna um status code 204 se for deletado</returns>
        /// <response code="204">tipos usuário deletado com sucesso.</response>
        /// <response code="404">tipos usuário não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Deletar(Guid id)
        {

            try
            {
                TiposUsuario tiposUsuarioEncontrado = _tiposUsuario.ListarPorId(id);
                if (tiposUsuarioEncontrado != null)
                {
                    _tiposUsuario.Deletar(id);
                    return StatusCode(204);
                }
                return StatusCode(404, "tipos usuário não encontrado.");
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Erro = erro, Mensagem = "Ocorreu um Erro" });
            }


        }

        /// <summary>
        /// Altera dados cadastrados de um tipos usuário.
        /// </summary>
        /// <param name="id">Id  utilizada para localizar o tipos usuário a ser alterado.</param>
        /// <param name="tiposUsuarioAlterado">Objeto do tipo tipos usuário contendo as alterações do tipos usuário.</param>
        /// <returns>Retorna um status code 204 se for alterado</returns>
        /// <response code="204">tipos usuário alterado com sucesso.</response>
        /// <response code="404">tipos usuário não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Alterar(Guid id, TiposUsuario tiposUsuarioAlterado)
        {
            try
            {
                TiposUsuario tiposUsuarioEncontrado = _tiposUsuario.ListarPorId(id);
                if (tiposUsuarioEncontrado != null)
                {
                    _tiposUsuario.Alterar(id, tiposUsuarioAlterado);
                    return StatusCode(204);
                }
                return StatusCode(404, "tipos usuário não encontrado.");
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Erro = erro, Mensagem = "Ocorreu um Erro" });
            }
        }

    }
}
