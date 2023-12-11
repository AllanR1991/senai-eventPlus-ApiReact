using senai_eventPlus_webApi_codeFirst_jwt.Contexts;
using senai_eventPlus_webApi_codeFirst_jwt.Domains;
using senai_eventPlus_webApi_codeFirst_jwt.Interfaces;

namespace senai_eventPlus_webApi_codeFirst_jwt.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        EventPlusContext context = new EventPlusContext();

        public void Alterar(Guid id, TiposUsuario tiposUsuarioAlterado)
        {
            TiposUsuario tiposUsuarioBuscado = context.TiposUsuario.FirstOrDefault(tp => tp.idTipoUsuario == id);

            if (tiposUsuarioAlterado.tipoUsuario != null)
            {
                tiposUsuarioBuscado.tipoUsuario = tiposUsuarioAlterado.tipoUsuario;
            }

            context.TiposUsuario.Update(tiposUsuarioBuscado);

            context.SaveChanges();
        }

        public void Cadastrar(TiposUsuario novoTiposUsuario)
        {
            context.TiposUsuario.Add(novoTiposUsuario);

            context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposUsuario tiposUsuarioEncontrado = context.TiposUsuario.FirstOrDefault(tp => tp.idTipoUsuario == id);

            context.TiposUsuario.Remove(tiposUsuarioEncontrado);

            context.SaveChanges();
        }

        public TiposUsuario ListarPorId(Guid id)
        {
            return context.TiposUsuario.FirstOrDefault(tp => tp.idTipoUsuario == id);
        }

        public List<TiposUsuario> Listartodos()
        {
            return context.TiposUsuario.ToList();
        }
    }
}
