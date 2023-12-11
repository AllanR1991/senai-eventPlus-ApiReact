using Microsoft.EntityFrameworkCore;
using senai_eventPlus_webApi_codeFirst_jwt.Contexts;
using senai_eventPlus_webApi_codeFirst_jwt.Domains;
using senai_eventPlus_webApi_codeFirst_jwt.DTO;
using senai_eventPlus_webApi_codeFirst_jwt.Interfaces;

namespace senai_eventPlus_webApi_codeFirst_jwt.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        EventPlusContext context = new EventPlusContext();

        public void Alterar(Guid id, Comentario comentarioAlterado)
        {
            Comentario comentarioBuscado = context.Comentario.FirstOrDefault(c => c.idComentario == id);

            if (comentarioAlterado.idUsuario != null)
            {
                comentarioBuscado.idUsuario = comentarioAlterado.idUsuario;
            }
            if (comentarioAlterado.idEvento != null)
            {
                comentarioBuscado.idEvento = comentarioAlterado.idEvento;
            }
            if (comentarioAlterado.descricao != null)
            {
                comentarioBuscado.descricao = comentarioAlterado.descricao;
            }
            if (comentarioAlterado.exibe != null)
            {
                comentarioBuscado.exibe = comentarioAlterado.exibe;
            }

            context.Comentario.Update(comentarioBuscado);

            context.SaveChanges();
        }

        public void Cadastrar(Comentario novoComentario)
        {
            context.Comentario.Add(novoComentario);

            context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Comentario comentarioEncontrado = context.Comentario.FirstOrDefault(c => c.idComentario == id);

            context.Comentario.Remove(comentarioEncontrado);

            context.SaveChanges();

        }

        public Comentario ListarPorId(Guid id)
        {
            return context.Comentario
                .Select(c => new Comentario
                {
                    descricao = c.descricao,
                    exibe = c.exibe,
                    
                    usuario = new Usuario
                    {
                        nome = c.usuario.nome
                    },

                    evento = new Evento 
                    {
                        nomeEvento = c.evento.nomeEvento,
                    }

                }).FirstOrDefault(c => c.idComentario == id)!;
        }

        public List<ComentarioEventoDTO> Listartodos()
        {
            return context.Comentario
                .Select(c => new ComentarioEventoDTO
                {
                    Descricao = c.descricao,
                    Exibe = c.exibe,
                    NomeUsuario = c.usuario.nome,
                    NomeEvento = c.evento.nomeEvento
                }).ToList();            
        }


        public Comentario BuscarPorIdUsuario(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return context.Comentario
                    .Select(c => new Comentario
                    {
                        idComentario = c.idComentario,
                        descricao = c.descricao,
                        exibe = c.exibe,
                        idUsuario = c.idUsuario,
                        idEvento = c.idEvento,

                        usuario = new Usuario
                        {
                            nome = c.usuario!.nome
                        },

                        evento = new Evento
                        {
                            nomeEvento = c.evento!.nomeEvento,
                        }

                    }).FirstOrDefault(c => c.idUsuario == idUsuario && c.idEvento == idEvento)!;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}