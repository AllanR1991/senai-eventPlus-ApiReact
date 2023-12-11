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
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepository _comentario { get; set; }

        public ComentarioController()
        {
            _comentario = new ComentarioRepository();
        }

        /// <summary>
        /// Lista todas os comentário.
        /// </summary>
        /// <returns>Retorna um status code 200</returns>
        /// <response code="200">Lista de comentário exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListaTodos()
        {
            try
            {
                return StatusCode(200, _comentario.Listartodos());
            }
            catch (Exception)
            {
                return StatusCode(400, "Não foi possivel listar");
            }
        }

        /// <summary>
        /// Lista um comentário.
        /// </summary>
        /// <param name="id">Id Utilizada para buscar o comentário.</param>
        /// <returns>Retorna status code 200</returns>
        /// <response code="200">Lista de comentário exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListaUm(Guid id)
        {
            try
            {
                return StatusCode(200, _comentario.ListarPorId(id));
            }
            catch (Exception)
            {
                return StatusCode(400, "Não foi possivel listar");
            }
        }

        /// <summary>
        /// Lista um comentário.
        /// </summary>
        /// <param name="id">Id Utilizada para buscar o comentário.</param>
        /// <returns>Retorna status code 200</returns>
        /// <response code="200">Lista de comentário exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista.</response>
        [HttpGet("BuscaIdUsuarioIdEvento")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListaComentarioUsarioEvento(Guid idUsuario, Guid idEvento)
        {
            try
            {                
                return StatusCode(200, _comentario.BuscarPorIdUsuario(idUsuario, idEvento));
            }
            catch (Exception)
            {
                return StatusCode(400, "Não foi possivel listar");
            }
        }



        /// <summary>
        /// Cadastra um novo comentário.
        /// </summary>
        /// <param name="novoComentario">Objeto do tipo comentário contendo os dados de um novo comentário.</param>
        /// <returns>Status code 201 se for criado.</returns>
        /// <response code="201">Criado comentário com sucesso.</response>
        /// <response code="400">Erro ao tentar criar um novo comentário.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Novo(Comentario novoComentario)
        {
            try
            {
                _comentario.Cadastrar(novoComentario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return StatusCode(400, erro);
            }
        }

        /// <summary>
        /// Deleta um Comentario se o mesmo estiver cadastrado.
        /// </summary>
        /// <param name="id">Id contendo UUID((Identificador Universal exclusivo) de um comentário.</param>
        /// <returns>Retorna um status code 204 se for deletado</returns>
        /// <response code="204">comentário deletado com sucesso.</response>
        /// <response code="404">comentário não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Deletar(Guid id)
        {

            try
            {
                Comentario comentarioEncontrado = _comentario.ListarPorId(id);
                if (comentarioEncontrado != null)
                {
                    _comentario.Deletar(id);
                    return StatusCode(204);
                }
                return StatusCode(404, "comentário não encontrado.");
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Erro = erro, Mensagem = "Ocorreu um Erro" });
            }


        }

        /// <summary>
        /// Altera dados cadastrados de um comentário.
        /// </summary>
        /// <param name="id">Id  utilizada para localizar o comentário a ser alterado.</param>
        /// <param name="comentarioAlterado">Objeto do tipo comentário contendo as alterações do comentário.</param>
        /// <returns>Retorna um status code 204 se for Alterado</returns>
        /// <response code="204">comentário Alterado com sucesso.</response>
        /// <response code="404">comentário não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Alterar(Guid id, Comentario comentarioAlterado)
        {
            try
            {
                Comentario comentarioEncontrado = _comentario.ListarPorId(id);
                if (comentarioEncontrado != null)
                {
                    _comentario.Alterar(id, comentarioAlterado);
                    return StatusCode(204);
                }
                return StatusCode(404, "comentário não encontrado.");
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Erro = erro, Mensagem = "Ocorreu um Erro" });
            }
        }
    }
}
