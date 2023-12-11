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
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicao { get; set; }

        public InstituicaoController()
        {
            _instituicao = new InstituicaoRepository();
        }

        /// <summary>
        /// Lista todas as Instituição.
        /// </summary>
        /// <returns>Retorna um status code 200</returns>
        /// <response code="200">Lista de Instituição exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListaTodos()
        {
            try
            {
                return StatusCode(200, _instituicao.Listartodos());
            }
            catch (Exception)
            {
                return StatusCode(400, "Não foi possivel listar");
            }
        }

        /// <summary>
        /// Lista uma Instituição.
        /// </summary>
        /// <param name="id">Id Utilizada para buscar a Instituição.</param>
        /// <returns>Retorna status code 200</returns>
        /// <response code="200">Lista de Instituição exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListaUm(Guid id)
        {
            try
            {
                return StatusCode(200, _instituicao.ListarPorId(id));
            }
            catch (Exception)
            {
                return StatusCode(400, "Não foi possivel listar");
            }
        }



        /// <summary>
        /// Cadastra uma nova Instituição.
        /// </summary>
        /// <param name="novaInstituicao">Objeto do tipo Instituição contendo os dados de uma nova Instituição.</param>
        /// <returns>Status code 201 se for criado.</returns>
        /// <response code="201">Criado Instituição com sucesso.</response>
        /// <response code="400">Erro ao tentar criar uma nova Instituição.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Novo(Instituicao novaInstituicao)
        {
            try
            {
                _instituicao.Cadastrar(novaInstituicao);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return StatusCode(400, erro);
            }
        }

        /// <summary>
        /// Deleta um Instituicao se o mesmo estiver cadastrado.
        /// </summary>
        /// <param name="id">Id contendo UUID((Identificador Universal exclusivo) de um Instituição.</param>
        /// <returns>Retorna um status code 204 se for deletado</returns>
        /// <response code="204">Instituição deletado com sucesso.</response>
        /// <response code="404">Instituição não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Deletar(Guid id)
        {

            try
            {
                Instituicao instituicaoEncontrado = _instituicao.ListarPorId(id);
                if (instituicaoEncontrado != null)
                {
                    _instituicao.Deletar(id);
                    return StatusCode(204);
                }
                return StatusCode(404, "Instituição não encontrado.");
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Erro = erro, Mensagem = "Ocorreu um Erro" });
            }


        }

        /// <summary>
        /// Altera dados cadastrados de um Instituição.
        /// </summary>
        /// <param name="id">Id  utilizada para localizar o Instituição a ser alterado.</param>
        /// <param name="instituicaoAlterado">Objeto do tipo Instituição contendo as alterações do Instituição.</param>
        /// <returns>Retorna um status code 204 se for alterado</returns>
        /// <response code="204">Instituição alterado com sucesso.</response>
        /// <response code="404">Instituição não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Alterar(Guid id, Instituicao instituicaoAlterado)
        {
            try
            {
                Instituicao instituicaoEncontrado = _instituicao.ListarPorId(id);
                if (instituicaoEncontrado != null)
                {
                    _instituicao.Alterar(id, instituicaoAlterado);
                    return StatusCode(204);
                }
                return StatusCode(404, "Instituição não encontrado.");
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Erro = erro, Mensagem = "Ocorreu um Erro" });
            }
        }
    }
}
