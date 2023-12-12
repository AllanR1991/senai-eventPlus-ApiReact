using senai_eventPlus_webApi_codeFirst_jwt.Contexts;
using senai_eventPlus_webApi_codeFirst_jwt.Domains;
using senai_eventPlus_webApi_codeFirst_jwt.Interfaces;

namespace senai_eventPlus_webApi_codeFirst_jwt.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {
        EventPlusContext context = new EventPlusContext();

        public void Alterar(Guid id, TiposEvento tiposEventoAlterado)
        {
            TiposEvento tiposEventoBuscado = context.TiposEvento.FirstOrDefault(tpe => tpe.idTiposEvento == id);

            if (tiposEventoAlterado.tipoEvento != null)
            {
                tiposEventoBuscado.tipoEvento = tiposEventoAlterado.tipoEvento;
            }

            context.TiposEvento.Update(tiposEventoBuscado);

            context.SaveChanges();
        }

        public void Cadastrar(TiposEvento novoTiposEvento)
        {            
            context.TiposEvento.Add(novoTiposEvento);

            context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposEvento tiposEventoEncontrado = context.TiposEvento.FirstOrDefault(tpe => tpe.idTiposEvento == id);

            context.TiposEvento.Remove(tiposEventoEncontrado);

            context.SaveChanges();

        }

        public TiposEvento ListarPorId(Guid id)
        {
            return context.TiposEvento.FirstOrDefault(tpe => tpe.idTiposEvento == id);
        }

        public List<TiposEvento> Listartodos()
        {
            return context.TiposEvento.OrderBy(tp=> tp.tipoEvento).ToList();
        }
    }
}
