using senai_eventPlus_webApi_codeFirst_jwt.Domains;

namespace senai_eventPlus_webApi_codeFirst_jwt.Interfaces
{
    public interface IPresencasEventoRepository
    {
        /// <summary>
        /// Criar um novo presencasEvento
        /// </summary>
        /// <param name="novoPresencasEvento">Objeto do tipo presencasEvento contendo as informações do novo presencasEvento.</param>
        public void Cadastrar(PresencasEvento novoPresencasEvento);

        /// <summary>
        /// Deleta um presencasEvento
        /// </summary>
        /// <param name="id">Id utilizada para deletar um presencasEvento.</param>
        public void Deletar(Guid id);

        /// <summary>
        /// Altera os dados de um presencasEvento.
        /// </summary>
        /// <param name="id">Id passada pela URL utilizada para encontrar o presencasEvento a ser alterado.</param>
        /// <param name="presencasEventoAlterado">Objeto do tipo presencasEvento, contendo as alterações de presencasEvento.</param>
        public void Alterar(Guid id, PresencasEvento presencasEventoAlterado);

        /// <summary>
        /// Lista todos os presencasEvento cadastrados.
        /// </summary>
        /// <returns>Lista de presencasEvento.</returns>     
        public List<PresencasEvento> ListarTodos();

        /// <summary>
        /// Lista um único presencasEvento.
        /// </summary>
        /// <param name="id">Id utilizada para encontrar o presencasEvento que desejamos exibir as informações.</param>
        /// <returns>Retorna um objeto do tipo presencasEvento.</returns>
        public PresencasEvento ListarPorId(Guid id);


        public List<PresencasEvento> ListarMinhas(Guid id);
    }
}
