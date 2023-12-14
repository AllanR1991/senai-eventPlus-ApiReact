using Microsoft.EntityFrameworkCore;
using senai_eventPlus_webApi_codeFirst_jwt.Contexts;
using senai_eventPlus_webApi_codeFirst_jwt.Domains;
using senai_eventPlus_webApi_codeFirst_jwt.Interfaces;

namespace senai_eventPlus_webApi_codeFirst_jwt.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        EventPlusContext context = new EventPlusContext();

        public void Alterar(Guid id, Evento eventoAlterado)
        {
            Evento eventoBuscado = context.Evento.FirstOrDefault(e => e.idEvento == id);

            if (eventoAlterado.idInstituicao != null)
            {
                eventoBuscado.idInstituicao = eventoAlterado.idInstituicao;
            }
            if (eventoAlterado.idTipoEvento != null)
            {
                eventoBuscado.idTipoEvento = eventoAlterado.idTipoEvento;
            }
            if (eventoAlterado.nomeEvento != null)
            {
                eventoBuscado.nomeEvento = eventoAlterado.nomeEvento;
            }
            if (eventoAlterado.descricao != null)
            {
                eventoBuscado.descricao = eventoAlterado.descricao;
            }
            if (eventoAlterado.dataEvento != null)
            {
                eventoBuscado.dataEvento = eventoAlterado.dataEvento;
            }
            if (eventoAlterado.horarioEvento != null)
            {
                eventoBuscado.horarioEvento = eventoAlterado.horarioEvento;
            }            

            context.Evento.Update(eventoBuscado);

            context.SaveChanges();
        }

        public void Cadastrar(Evento novoEvento)
        {
            context.Evento.Add(novoEvento);

            context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Evento eventoEncontrado = context.Evento.FirstOrDefault(e => e.idEvento == id);

            context.Evento.Remove(eventoEncontrado);

            context.SaveChanges();

        }

        public Evento ListarPorId(Guid id)
        {
            return context.Evento.FirstOrDefault(e => e.idEvento == id);
        }

        public List<Evento> Listartodos()
        {
            try
            {
                return context.Evento.Select(e => new Evento
                {
                    idEvento = e.idEvento,
                    dataEvento = e.dataEvento,
                    nomeEvento = e.nomeEvento,
                    descricao = e.descricao,
                    idTipoEvento = e.idTipoEvento,
                    tipoEvento = new TiposEvento
                    {
                        idTiposEvento = e.idTipoEvento,
                        tipoEvento = e.tipoEvento!.tipoEvento
                    },
                    idInstituicao = e.idInstituicao,
                    instituicao = new Instituicao
                    {
                        idInstituicao = e.idInstituicao,
                        nomeFantasia = e.instituicao!.nomeFantasia
                    }
                }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> ListarProximos()
        {
            try
            {
                return context.Evento
                    .Where(e => e.dataEvento > DateTime.Now).OrderBy(e => e.dataEvento).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> ListarEventosAnteriores()
        {
            try
            {
                return context.Evento
                    .Where(e => e.dataEvento < DateTime.Now).OrderBy(e => e.dataEvento).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
