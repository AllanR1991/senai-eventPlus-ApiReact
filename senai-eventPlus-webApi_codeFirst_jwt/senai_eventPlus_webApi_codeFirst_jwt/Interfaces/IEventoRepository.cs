using senai_eventPlus_webApi_codeFirst_jwt.Domains;

namespace senai_eventPlus_webApi_codeFirst_jwt.Interfaces
{
    public interface IEventoRepository
    {
        /// <summary>
        /// Criar um novo evento
        /// </summary>
        /// <param name="novoEvento">Objeto do tipo evento contendo as informações do novo evento.</param>
        public void Cadastrar(Evento novoEvento);

        /// <summary>
        /// Deleta um evento
        /// </summary>
        /// <param name="id">Id utilizada para deletar um evento.</param>
        public void Deletar(Guid id);

        /// <summary>
        /// Altera os dados de um evento.
        /// </summary>
        /// <param name="id">Id passada pela URL utilizada para encontrar o evento a ser alterada.</param>
        /// <param name="eventoAlterado">Objeto do tipo evento, contendo as alterações do evento.</param>
        public void Alterar(Guid id, Evento eventoAlterado);

        /// <summary>
        /// Lista todos os evento cadastrados.
        /// </summary>
        /// <returns>Lista de evento.</returns>     
        public List<Evento> Listartodos();

        /// <summary>
        /// Lista um único evento.
        /// </summary>
        /// <param name="id">Id utilizada para encontrar o evento que desejamos exibir as informações.</param>
        /// <returns>Retorna um objeto do tipo evento.</returns>
        public Evento ListarPorId(Guid id);


        /// <summary>
        /// Lista proximos eventos
        /// </summary>
        /// <returns>Retorna uma lista com eventos que irão ocorrer.</returns>
        List<Evento> ListarProximos();

        /// <summary>
        /// Lista eventos que ja ocorreram.
        /// </summary>
        /// <returns>Retorna uma lista com eventos que ja ocorreu.</returns>
        List<Evento> ListarEventosAnteriores();
    }
}
