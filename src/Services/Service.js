import axios from 'axios';

/**
 * Módulo para trabalhar com apis. Disponibiliza as rotas da api bem como o serviço com a biblioteca axios
 */



/**
 * Rota para o recurso Evento
 */
export const eventsResource = '/Evento';
/**
 * Rota para o recurso Listar Minhas Presenças
 */
export const myEventsResource = '/PresencasEvento/ListarMinhas';
/**
 * Rota para o recurso Presenças Evento
 */
export const presencesEventResource = '/PresencasEvento';
/**
 * Rota para o recurso Presenças Evento
 */
export const commentaryEventResource = '/Comentario';
/**
 * Rota para o recurso Presenças Evento
 */
export const commentaryEventIAResource = '/Comentario/ComentarioIA';

/**
 * Rota para o recurso Próximos Eventos
 */
export const nextEventResource = '/Evento/ListarProximos';
/**
 * Rota para o recurso Próximos Eventos
 */
export const pastEentResource = '/Evento/ListarEventosAnteriores';
/**
 * Rota para o recurso Tipos de Eventos
 */
export const eventsTypeResource = '/TiposEvento';
/**
 * Rota para o recurso Instituição
 */
export const institutionResource = '/Instituicao';
/**
 * Rota para o recurso Login
 */
export const loginResource = '/Login';

export const detailsEventResource = '/DetalhesEvento'

const apiPort = '7183';
const localApiUri = `https://localhost:${apiPort}/api`;
const externallApiUri = `https://eventplus-allanrs.azurewebsites.net/api`;
// const externalApiUri = null;

const api = axios.create({
    baseURL: externallApiUri
});



export default api;