using senai_eventPlus_webApi_codeFirst_jwt.Domains;

namespace senai_eventPlus_webApi_codeFirst_jwt.Interfaces
{
    public interface IInstituicaoRepository
    {
        /// <summary>
        /// Criar uma nova instituição
        /// </summary>
        /// <param name="novaInstituicao">Objeto do tipo instituição contendo as informações da nova instituição.</param>
        public void Cadastrar(Instituicao novaInstituicao);

        /// <summary>
        /// Deleta uma instituição
        /// </summary>
        /// <param name="id">Id utilizada para deletar uma instituição.</param>
        public void Deletar(Guid id);

        /// <summary>
        /// Altera os dados de uma instituição.
        /// </summary>
        /// <param name="id">Id passada pela URL utilizada para encontrar a instituição a ser alterada.</param>
        /// <param name="instituicaoAlterada">Objeto do tipo instituição, contendo as alterações de instituição.</param>
        public void Alterar(Guid id, Instituicao instituicaoAlterada);

        /// <summary>
        /// Lista todas as instituição cadastrados.
        /// </summary>
        /// <returns>Lista de instituição.</returns>     
        public List<Instituicao> Listartodos();

        /// <summary>
        /// Lista uma única instituição.
        /// </summary>
        /// <param name="id">Id utilizada para encontrar a instituição que desejamos exibir as informações.</param>
        /// <returns>Retorna um objeto do tipo instituição.</returns>
        public Instituicao ListarPorId(Guid id);
    }
}
