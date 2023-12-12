using senai_eventPlus_webApi_codeFirst_jwt.Domains;
using senai_eventPlus_webApi_codeFirst_jwt.DTO;

namespace senai_eventPlus_webApi_codeFirst_jwt.Interfaces
{
    public interface IComentarioRepository
    {
        /// <summary>
        /// Criar um novo comentário
        /// </summary>
        /// <param name="novoComentario">Objeto do tipo comentário contendo as informações do novo comentário.</param>
        public void Cadastrar(Comentario novoComentario);

        /// <summary>
        /// Deleta um comentário
        /// </summary>
        /// <param name="id">Id utilizada para deletar um comentário.</param>
        public void Deletar(Guid id);

        /// <summary>
        /// Altera os dados de um comentário.
        /// </summary>
        /// <param name="id">Id passada pela URL utilizada para encontrar o comentário a ser alterada.</param>
        /// <param name="comentarioAlterado">Objeto do tipo comentário, contendo as alterações do comentário.</param>
        public void Alterar(Guid id, Comentario comentarioAlterado);

        /// <summary>
        /// Lista todos os comentário cadastrados.
        /// </summary>
        /// <returns>Lista de comentário.</returns>     
        public List<Comentario> Listartodos();

        /// <summary>
        /// Lista um único comentário.
        /// </summary>
        /// <param name="id">Id utilizada para encontrar o comentário que desejamos exibir as informações.</param>
        /// <returns>Retorna um objeto do tipo comentário.</returns>
        public Comentario ListarPorId(Guid id);


        public Comentario BuscarPorIdUsuario(Guid idUsuario, Guid idEvento);
    }
}
