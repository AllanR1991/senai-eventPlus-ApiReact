using senai_eventPlus_webApi_codeFirst_jwt.Domains;

namespace senai_eventPlus_webApi_codeFirst_jwt.Interfaces
{
    public interface ITiposEventoRepository
    {
        /// <summary>
        /// Criar um novo tipoEvento
        /// </summary>
        /// <param name="novoTiposEvento">Objeto do tipo tipoEvento contendo as informações do novo tipoEvento.</param>
        public void Cadastrar(TiposEvento novoTiposEvento);

        /// <summary>
        /// Deleta um tipoEvento
        /// </summary>
        /// <param name="id">Id utilizada para deletar um tipoEvento.</param>
        public void Deletar(Guid id);

        /// <summary>
        /// Altera os dados de um tipoEvento.
        /// </summary>
        /// <param name="id">Id passada pela URL utilizada para encontrar o tipoEvento a ser alterado.</param>
        /// <param name="tiposEventoAlterado">Objeto do tipo tipoEvento, contendo as alterações de tipoEvento.</param>
        public void Alterar(Guid id, TiposEvento tiposEventoAlterado);

        /// <summary>
        /// Lista todos os TipoEvento cadastrados.
        /// </summary>
        /// <returns>Lista de TipoEvento.</returns>     
        public List<TiposEvento> Listartodos();

        /// <summary>
        /// Lista um único tipoEvento.
        /// </summary>
        /// <param name="id">Id utilizada para encontrar o tipoEvento que desejamos exibir as informações.</param>
        /// <returns>Retorna um objeto do tipo tipoEvento.</returns>
        public TiposEvento ListarPorId(Guid id);
    }
}
