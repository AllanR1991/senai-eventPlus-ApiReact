using senai_eventPlus_webApi_codeFirst_jwt.Contexts;
using senai_eventPlus_webApi_codeFirst_jwt.Domains;
using senai_eventPlus_webApi_codeFirst_jwt.Interfaces;

namespace senai_eventPlus_webApi_codeFirst_jwt.Repositories
{
    public class PresencasEventoRepository : IPresencasEventoRepository
    {
        EventPlusContext context = new EventPlusContext();

        public void Alterar(Guid id, PresencasEvento presencasEventoAlterado)
        {
            PresencasEvento presencasEventoBuscado = context.PresencasEvento.FirstOrDefault(pe => pe.idPresencasEvento == id);

            if (presencasEventoAlterado.idUsuario != null)
            {
                presencasEventoBuscado.idUsuario = presencasEventoAlterado.idUsuario;
            }
            if (presencasEventoAlterado.idEvento != null)
            {
                presencasEventoBuscado.idEvento = presencasEventoAlterado.idEvento;
            }
            if (presencasEventoAlterado.situacao != null)
            {
                presencasEventoBuscado.situacao = presencasEventoAlterado.situacao;
            }            

            context.PresencasEvento.Update(presencasEventoBuscado);

            context.SaveChanges();
        }

        public void Cadastrar(PresencasEvento novoPresencasEvento)
        {            
            context.PresencasEvento.Add(novoPresencasEvento);

            context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            PresencasEvento presencasEventoEncontrado = context.PresencasEvento.FirstOrDefault(pe => pe.idPresencasEvento == id);

            context.PresencasEvento.Remove(presencasEventoEncontrado);

            context.SaveChanges();

        }

        public PresencasEvento ListarPorId(Guid id)
        {
            return context.PresencasEvento
                .Select(p => new PresencasEvento
                {
                    idPresencasEvento = p.idPresencasEvento,
                    situacao = p.situacao,

                    evento = new Evento
                    {
                        dataEvento = p.evento.dataEvento,
                        nomeEvento = p.evento.nomeEvento,
                        descricao = p.evento.descricao,

                        instituicao = new Instituicao
                        {
                            nomeFantasia = p.evento.instituicao.nomeFantasia
                        }
                    }
                }).FirstOrDefault(p => p.idPresencasEvento == id);
        }

        public List<PresencasEvento> ListarMinhas(Guid id)
        {
            return context.PresencasEvento
                .Select(p => new PresencasEvento
                {
                    idPresencasEvento = p.idPresencasEvento,
                    situacao = p.situacao,
                    idUsuario = p.idUsuario,

                    evento = new Evento
                    {
                        idEvento = p.idEvento,
                        dataEvento = p.evento.dataEvento,
                        nomeEvento = p.evento.nomeEvento,
                        descricao = p.evento.descricao,

                        instituicao = new Instituicao
                        {
                            idInstituicao = p.evento.idInstituicao,
                            nomeFantasia = p.evento.instituicao.nomeFantasia
                        }
                    }
                }).Where(p => p.idUsuario == id).ToList();
        }
        
        public List<PresencasEvento> ListarTodos()
        {
            return context.PresencasEvento.ToList();
        }

    }
}
