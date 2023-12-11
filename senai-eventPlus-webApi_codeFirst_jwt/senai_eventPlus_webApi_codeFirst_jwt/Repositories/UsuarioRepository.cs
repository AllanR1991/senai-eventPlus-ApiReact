using senai_eventPlus_webApi_codeFirst_jwt.Contexts;
using senai_eventPlus_webApi_codeFirst_jwt.Domains;
using senai_eventPlus_webApi_codeFirst_jwt.Interfaces;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using senai_eventPlus_webApi_codeFirst_jwt.Utils;

namespace senai_eventPlus_webApi_codeFirst_jwt.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        EventPlusContext context = new EventPlusContext();

        public void Alterar(Guid id, Usuario usuarioAlterado)
        {
            Usuario usuarioBuscado = context.Usuario.FirstOrDefault(u => u.idUsuario == id);

            if (usuarioAlterado.nome != null)
            {
                usuarioBuscado.nome = usuarioAlterado.nome;
            }
            if (usuarioAlterado.email != null)
            {
                usuarioBuscado.email = usuarioAlterado.email;
            }
            if (usuarioAlterado.senha != null)
            {
                usuarioBuscado.senha = usuarioAlterado.senha;
            }
            if (usuarioAlterado.idTipoUsuario != null)
            {
                usuarioBuscado.idTipoUsuario = usuarioAlterado.idTipoUsuario;
            }

            context.Usuario.Update(usuarioBuscado);

            context.SaveChanges();
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            //  Verifica se o valor contido na variavel idTipoUsuario corresponde a algum tipoUsuario já cadastrado.
            TiposUsuario tiposUsuarioEncontrado = context.TiposUsuario.FirstOrDefault(tp => tp.idTipoUsuario == novoUsuario.idTipoUsuario);

            //  Se o idTipoUsuario não for correspondido sera inputado o valor idTipoUsuario do tipoUsuario Comum.
            if (tiposUsuarioEncontrado == null)
            {
                tiposUsuarioEncontrado = context.TiposUsuario.FirstOrDefault(tp => tp.tipoUsuario == "Comum");
            
                novoUsuario.idTipoUsuario = tiposUsuarioEncontrado.idTipoUsuario;
            }

            novoUsuario.senha = Criptografia.GerarHash(novoUsuario.senha);

            context.Usuario.Add(novoUsuario);
            
            context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Usuario usuarioEncontrado = context.Usuario.FirstOrDefault(u => u.idUsuario == id);
            
            context.Usuario.Remove(usuarioEncontrado);
            
            context.SaveChanges();
            
        }

        public Usuario ListarPorId(Guid id)
        {
            Usuario usuarioBuscado = context.Usuario
                .Select(u => new Usuario
                {
                    idUsuario = u.idUsuario,
                    nome = u.nome,
                    email = u.email,
                    senha = u.senha,

                    tiposUsuario = new TiposUsuario
                    {
                        tipoUsuario = u.tiposUsuario.tipoUsuario
                    }
                }).FirstOrDefault(u => u.idUsuario == id)!;

            if (usuarioBuscado == null)
            {
                return null;
            }

            return usuarioBuscado;
        }

        public List<Usuario> Listartodos()
        {
           return context.Usuario.ToList();
        }

        public Usuario BuscaPorEmailSenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = context.Usuario
                    .Select(u => new Usuario
                    {
                        idUsuario = u.idUsuario,
                        nome = u.nome,
                        email = u.email,
                        senha = u.senha,

                        tiposUsuario = new TiposUsuario
                        {
                            idTipoUsuario = u.idTipoUsuario,
                            tipoUsuario = u.tiposUsuario.tipoUsuario
                        }
                    }).FirstOrDefault(u => u.email == email);

                if(usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.senha);

                    if(confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
