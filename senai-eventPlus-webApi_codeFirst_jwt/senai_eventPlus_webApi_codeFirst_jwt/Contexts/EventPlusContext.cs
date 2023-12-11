using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using senai_eventPlus_webApi_codeFirst_jwt.Domains;
using senai_eventPlus_webApi_codeFirst_jwt.Utils;

namespace senai_eventPlus_webApi_codeFirst_jwt.Contexts
{
    public class EventPlusContext : DbContext
    {
        //  Dbset<> é utilizado para efetuar as consultas no banco de dados.
        //  Utilização : Dbset<ClasseDomain> nomeQualquer {get; set;}

        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<PresencasEvento> PresencasEvento { get; set; }
        public DbSet<TiposEvento> TiposEvento { get;set; }
        public DbSet<TiposUsuario> TiposUsuario { get;set; }
        public DbSet<Usuario> Usuario { get; set; }

        //  Configurando o acesso ao banco de dados.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = ALLANR1991-DESK\\SQLEXPRESS; Database = EventPlus_CodeFirst; User Id = sa; pwd = 123456; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        //  Configurando dados presetados nos banco de dados.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Guid tipoUsuarioAdm, tipoUsuarioComum;

            modelBuilder.Entity<TiposUsuario>()
                .HasData(
                    new TiposUsuario
                    {
                        idTipoUsuario = tipoUsuarioAdm =  Guid.NewGuid(),
                        tipoUsuario = "Administrador"
                    },
                    new TiposUsuario
                    {
                        idTipoUsuario = tipoUsuarioComum = Guid.NewGuid() ,
                        tipoUsuario = "Comum"
                    }
                );
            
            Guid usuarioAllan, usuarioEverton;

            modelBuilder.Entity<Usuario>()
                .HasData(
                    new Usuario
                    {
                        idUsuario = usuarioAllan = Guid.NewGuid(),
                        idTipoUsuario = tipoUsuarioAdm,
                        nome = "Allan Rodrigues",
                        email  = "allan@allan.com",
                        senha = Criptografia.GerarHash("allan")
                    },
                    new Usuario
                    {
                        idUsuario = usuarioEverton = Guid.NewGuid(),
                        idTipoUsuario = tipoUsuarioComum,
                        nome = "Everton Araujo",
                        email = "everton@everton.com",
                        senha = Criptografia.GerarHash("everton")
                    }
                );

            Guid tipoEventoCSharp, tipoEventoSql;

            modelBuilder.Entity<TiposEvento>()
                .HasData(
                    new TiposEvento
                    { 
                        idTiposEvento = tipoEventoSql =  Guid.NewGuid(),
                        tipoEvento = "SQL Server"
                    },
                    new TiposEvento
                    {
                        idTiposEvento = tipoEventoCSharp = Guid.NewGuid(),
                        tipoEvento = "C#"
                    }
                );

            Guid instituicaoDevSchool;

            modelBuilder.Entity<Instituicao>()
                .HasData(
                    new Instituicao
                    {
                        idInstituicao = instituicaoDevSchool = Guid.NewGuid(),
                        cnpj = "1234567891012",
                        endereco = "Rua Niteroi 180",
                        razaoSocial = "Escola Internacional de Desenvolvimento",                       
                        nomeFantasia = "DevSchool"
                    }
                );


            Guid eventoSql;

            modelBuilder.Entity<Evento>()
                .HasData(
                    new Evento
                    {
                        idEvento = eventoSql = Guid.NewGuid(),
                        idInstituicao = instituicaoDevSchool,
                        idTipoEvento = tipoEventoSql,
                        nomeEvento = "Introdução ao banco de dados SQL Server",
                        descricao = "Conceitos básicos do SQL Server, como DDL, DML, DQL.",
                        dataEvento = DateTime.Parse("2023-08-10"),
                        horarioEvento = TimeSpan.Parse("13:00:00")                   
                    }
                );

            modelBuilder.Entity<PresencasEvento>()
                .HasData(
                    new PresencasEvento
                    {
                        idPresencasEvento = Guid.NewGuid(),
                        idEvento = eventoSql,
                        idUsuario = usuarioEverton,
                        situacao = true
                    }
                );

            modelBuilder.Entity<Comentario>()
                .HasData(
                    new Comentario
                    {
                        idComentario = Guid.NewGuid(),
                        idUsuario = usuarioEverton,
                        idEvento = eventoSql,
                        descricao = "Excelente evento",
                        exibe = true
                    }
                );
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
