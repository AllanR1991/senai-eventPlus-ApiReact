using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using senai_eventPlus_webApi_codeFirst_jwt.Contexts;
using senai_eventPlus_webApi_codeFirst_jwt.Domains;
using senai_eventPlus_webApi_codeFirst_jwt.Interfaces;
using senai_eventPlus_webApi_codeFirst_jwt.Repositories;

namespace senai_eventPlus_webApi_codeFirst_jwt.Controllers
{
    //  Garante que os retornos sejão em JSON
    [Produces("application/json")]
    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/apli/estudio
    [Route("api/[controller]")]
    //  Define que é um controladdor de API.
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuario { get; set; }

        public UsuarioController()
        {
            _usuario = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuários.
        /// </summary>
        /// <returns>Retorna um status code 200</returns>
        /// <response code="200">Lista de Usuários exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListaTodos()
        {
            try
            {
                return StatusCode(200, _usuario.Listartodos());
            }
            catch (Exception)
            {
                return StatusCode(400, "Não foi possivel listar");
            }
        }

        /// <summary>
        /// Lista um usuário.
        /// </summary>
        /// <param name="id">Id Utilizada para buscar o usuário.</param>
        /// <returns>Retorna status code 200</returns>
        /// <response code="200">Lista de Usuários exíbido com sucesso.</response>
        /// <response code="400">Não foi possivel exíbir a lista.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListaUm(Guid id) 
        {
            try
            {
                return StatusCode(200, _usuario.ListarPorId(id));
            }
            catch (Exception)
            {
                return StatusCode(400, "Não foi possivel listar");
            }
        }



        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="novoUsuario">Objeto do tipo Usuário contendo os dados de um novo Usuário.</param>
        /// <returns>Status code 201 se for criado.</returns>
        /// <response code="201">Criado usuário com sucesso.</response>
        /// <response code="400">Erro ao tentar criar um novo usuário.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Novo(Usuario novoUsuario)
        {
            try
            {
                _usuario.Cadastrar(novoUsuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return StatusCode(400, erro);
            }
        }

        /// <summary>
        /// Deleta um Usuário se o mesmo estiver cadastrado.
        /// </summary>
        /// <param name="id">Id contendo UUID((Identificador Universal exclusivo) de um usuário.</param>
        /// <returns>Retorna um status code 204 se for deletado</returns>
        /// <response code="204">Usuário deletado com sucesso.</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Deletar(Guid id)
        {

            try
            {
                Usuario usuarioEncontrado = _usuario.ListarPorId(id);
                if (usuarioEncontrado != null)
                {
                    _usuario.Deletar(id);
                    return StatusCode(204);
                }
                return StatusCode(404, "Usuário não encontrado.");
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Erro = erro, Mensagem = "Ocorreu um Erro" });
            }


        }

        /// <summary>
        /// Altera dados cadastrados de um usuário.
        /// </summary>
        /// <param name="id">Id  utilizada para localizar o Usuário a ser alterado.</param>
        /// <param name="usuarioAlterado">Objeto do tipo Usuário contendo as alterações do usuário.</param>
        /// <returns>Retorna um status code 204 se for alterado</returns>
        /// <response code="204">Usuário alterado com sucesso.</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Alterar(Guid id,Usuario usuarioAlterado) 
        {
            try
            {
                Usuario usuarioEncontrado = _usuario.ListarPorId(id);
                if (usuarioEncontrado != null)
                {
                    _usuario.Alterar(id, usuarioAlterado);
                    return StatusCode(204);                  
                }
                return StatusCode(404, "Usuário não encontrado.");
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Erro = erro, Mensagem = "Ocorreu um Erro" });
            }
        }

    }
}
