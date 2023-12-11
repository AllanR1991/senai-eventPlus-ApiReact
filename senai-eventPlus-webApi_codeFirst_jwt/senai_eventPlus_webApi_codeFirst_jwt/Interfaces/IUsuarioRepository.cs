using senai_eventPlus_webApi_codeFirst_jwt.Domains;

namespace senai_eventPlus_webApi_codeFirst_jwt.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Criar um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto do tipo Usuário contendo as informações do novo usuário.</param>
        public void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">Id utilizada para deletar um usuário.</param>
        public void Deletar(Guid id);

        /// <summary>
        /// Altera os dados de um usuário.
        /// </summary>
        /// <param name="id">Id passada pela URL utilizada para encontrar o usuário a ser alterado.</param>
        /// <param name="usuarioAlterado">Objeto do tipo Usuário, contendo as alterações de usuários.</param>
        public void Alterar(Guid id, Usuario usuarioAlterado);

        /// <summary>
        /// Lista todos os Usuários cadastrados.
        /// </summary>
        /// <returns>Lista de Usuários.</returns>     
        public List<Usuario> Listartodos();

        /// <summary>
        /// Lista um único usuário.
        /// </summary>
        /// <param name="id">Id utilizada para encontrar o usuário que desejamos exibir as informações.</param>
        /// <returns>Retorna um objeto do tipo Usuário.</returns>
        public Usuario ListarPorId(Guid id);

        public Usuario BuscaPorEmailSenha(string email, string senha);
    }
}
