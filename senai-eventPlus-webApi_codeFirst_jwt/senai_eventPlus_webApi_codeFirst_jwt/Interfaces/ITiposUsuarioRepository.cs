using senai_eventPlus_webApi_codeFirst_jwt.Domains;

namespace senai_eventPlus_webApi_codeFirst_jwt.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        /// <summary>
        /// Criar um novo tipo usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto do tipo usuário contendo as informações do novo tipo usuário.</param>
        public void Cadastrar(TiposUsuario novoTipoUsuario);

        /// <summary>
        /// Deleta um tipo usuário
        /// </summary>
        /// <param name="id">Id utilizada para deletar um tipo usuário.</param>
        public void Deletar(Guid id);

        /// <summary>
        /// Altera os dados de um tipo usuário.
        /// </summary>
        /// <param name="id">Id passada pela URL utilizada para encontrar o usuarioa ser alterado.</param>
        /// <param name="tipoUsuarioAlterado">Objeto do tipo tipo usuário, contendo as alterações de usurios.</param>
        public void Alterar(Guid id, TiposUsuario tipoUsuarioAlterado);

        /// <summary>
        /// Lista todos os Usuários cadastrados.
        /// </summary>
        /// <returns>Lista de Usuários.</returns>     
        public List<TiposUsuario> Listartodos();

        /// <summary>
        /// Lista um único tipo usuário.
        /// </summary>
        /// <param name="id">Id utilizada para encontrar o tipo usuário que desejamos exibir as informações.</param>
        /// <returns>Retorna um objeto do tipo tipo usuário.</returns>
        public TiposUsuario ListarPorId(Guid id);
    }
}
