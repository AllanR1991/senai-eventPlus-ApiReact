﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using senai_eventPlus_webApi_codeFirst_jwt.Contexts;

#nullable disable

namespace senai_eventPlus_webApi_codeFirst_jwt.Migrations
{
    [DbContext(typeof(EventPlusContext))]
    [Migration("20231214105845_criadoBdSenai")]
    partial class criadoBdSenai
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("senai_eventPlus_webApi_codeFirst_jwt.Domains.Comentario", b =>
                {
                    b.Property<Guid>("idComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("exibe")
                        .HasColumnType("BIT");

                    b.Property<Guid>("idEvento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("idComentario");

                    b.HasIndex("idEvento");

                    b.HasIndex("idUsuario");

                    b.ToTable("Comentario");

                    b.HasData(
                        new
                        {
                            idComentario = new Guid("88de2103-3dc3-42b6-a781-8e604bc6c970"),
                            descricao = "Excelente evento",
                            exibe = true,
                            idEvento = new Guid("d172d66a-72a6-44be-86db-cd78ccd3a9c3"),
                            idUsuario = new Guid("3c06d1ee-e3a2-4597-a843-5610f7c4e664")
                        });
                });

            modelBuilder.Entity("senai_eventPlus_webApi_codeFirst_jwt.Domains.Evento", b =>
                {
                    b.Property<Guid>("idEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("dataEvento")
                        .HasColumnType("DATE");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("horarioEvento")
                        .HasColumnType("TIME");

                    b.Property<Guid>("idInstituicao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idTipoEvento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nomeEvento")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("idEvento");

                    b.HasIndex("idInstituicao");

                    b.HasIndex("idTipoEvento");

                    b.ToTable("Evento");

                    b.HasData(
                        new
                        {
                            idEvento = new Guid("d172d66a-72a6-44be-86db-cd78ccd3a9c3"),
                            dataEvento = new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            descricao = "Conceitos básicos do SQL Server, como DDL, DML, DQL.",
                            horarioEvento = new TimeSpan(0, 13, 0, 0, 0),
                            idInstituicao = new Guid("7fd75a5c-0d2d-4cee-b977-3e59231f3cea"),
                            idTipoEvento = new Guid("4194aaa3-4e6f-46ca-9a15-8d20920e9f86"),
                            nomeEvento = "Introdução ao banco de dados SQL Server"
                        });
                });

            modelBuilder.Entity("senai_eventPlus_webApi_codeFirst_jwt.Domains.Instituicao", b =>
                {
                    b.Property<Guid>("idInstituicao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR(14)");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("nomeFantasia")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("razaoSocial")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("idInstituicao");

                    b.HasIndex("cnpj")
                        .IsUnique();

                    b.ToTable("Instituicao");

                    b.HasData(
                        new
                        {
                            idInstituicao = new Guid("7fd75a5c-0d2d-4cee-b977-3e59231f3cea"),
                            cnpj = "1234567891012",
                            endereco = "Rua Niteroi 180",
                            nomeFantasia = "DevSchool",
                            razaoSocial = "Escola Internacional de Desenvolvimento"
                        });
                });

            modelBuilder.Entity("senai_eventPlus_webApi_codeFirst_jwt.Domains.PresencasEvento", b =>
                {
                    b.Property<Guid>("idPresencasEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idEvento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("situacao")
                        .HasColumnType("BIT");

                    b.HasKey("idPresencasEvento");

                    b.HasIndex("idEvento");

                    b.HasIndex("idUsuario");

                    b.ToTable("PresencasEvento");

                    b.HasData(
                        new
                        {
                            idPresencasEvento = new Guid("eeafae0f-e480-4dbe-b2bd-bcac81ceae1f"),
                            idEvento = new Guid("d172d66a-72a6-44be-86db-cd78ccd3a9c3"),
                            idUsuario = new Guid("3c06d1ee-e3a2-4597-a843-5610f7c4e664"),
                            situacao = true
                        });
                });

            modelBuilder.Entity("senai_eventPlus_webApi_codeFirst_jwt.Domains.TiposEvento", b =>
                {
                    b.Property<Guid>("idTiposEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("tipoEvento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("idTiposEvento");

                    b.HasIndex("tipoEvento")
                        .IsUnique();

                    b.ToTable("TiposEvento");

                    b.HasData(
                        new
                        {
                            idTiposEvento = new Guid("4194aaa3-4e6f-46ca-9a15-8d20920e9f86"),
                            tipoEvento = "SQL Server"
                        },
                        new
                        {
                            idTiposEvento = new Guid("dc9ae37d-368a-4479-b815-326d4d25dc0e"),
                            tipoEvento = "C#"
                        });
                });

            modelBuilder.Entity("senai_eventPlus_webApi_codeFirst_jwt.Domains.TiposUsuario", b =>
                {
                    b.Property<Guid>("idTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("tipoUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("idTipoUsuario");

                    b.HasIndex("tipoUsuario")
                        .IsUnique();

                    b.ToTable("TipoUsuario");

                    b.HasData(
                        new
                        {
                            idTipoUsuario = new Guid("39f8698e-f8a2-4562-bf88-b94c7fa84870"),
                            tipoUsuario = "Administrador"
                        },
                        new
                        {
                            idTipoUsuario = new Guid("a4907676-c091-4c49-a583-e1cf61bf7994"),
                            tipoUsuario = "Comum"
                        });
                });

            modelBuilder.Entity("senai_eventPlus_webApi_codeFirst_jwt.Domains.Usuario", b =>
                {
                    b.Property<Guid>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR(150)");

                    b.Property<Guid>("idTipoUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("idUsuario");

                    b.HasIndex("email")
                        .IsUnique();

                    b.HasIndex("idTipoUsuario");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            idUsuario = new Guid("4c23093b-8809-4f6e-97fc-7231e33bde16"),
                            email = "allan@allan.com",
                            idTipoUsuario = new Guid("39f8698e-f8a2-4562-bf88-b94c7fa84870"),
                            nome = "Allan Rodrigues",
                            senha = "$2a$11$E.2fjgfCq3GZUuvrI6bZ6eV60RRAsW08VMcRlWIzIVAlAcevD.koa"
                        },
                        new
                        {
                            idUsuario = new Guid("3c06d1ee-e3a2-4597-a843-5610f7c4e664"),
                            email = "everton@everton.com",
                            idTipoUsuario = new Guid("a4907676-c091-4c49-a583-e1cf61bf7994"),
                            nome = "Everton Araujo",
                            senha = "$2a$11$eMxOzyJSldsrYUOPwfTkeut5XFfCMGrDgrfv9pmUy.qPql/KqnKhq"
                        });
                });

            modelBuilder.Entity("senai_eventPlus_webApi_codeFirst_jwt.Domains.Comentario", b =>
                {
                    b.HasOne("senai_eventPlus_webApi_codeFirst_jwt.Domains.Evento", "evento")
                        .WithMany()
                        .HasForeignKey("idEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("senai_eventPlus_webApi_codeFirst_jwt.Domains.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("idUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("evento");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("senai_eventPlus_webApi_codeFirst_jwt.Domains.Evento", b =>
                {
                    b.HasOne("senai_eventPlus_webApi_codeFirst_jwt.Domains.Instituicao", "instituicao")
                        .WithMany()
                        .HasForeignKey("idInstituicao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("senai_eventPlus_webApi_codeFirst_jwt.Domains.TiposEvento", "tipoEvento")
                        .WithMany()
                        .HasForeignKey("idTipoEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("instituicao");

                    b.Navigation("tipoEvento");
                });

            modelBuilder.Entity("senai_eventPlus_webApi_codeFirst_jwt.Domains.PresencasEvento", b =>
                {
                    b.HasOne("senai_eventPlus_webApi_codeFirst_jwt.Domains.Evento", "evento")
                        .WithMany()
                        .HasForeignKey("idEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("senai_eventPlus_webApi_codeFirst_jwt.Domains.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("idUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("evento");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("senai_eventPlus_webApi_codeFirst_jwt.Domains.Usuario", b =>
                {
                    b.HasOne("senai_eventPlus_webApi_codeFirst_jwt.Domains.TiposUsuario", "tiposUsuario")
                        .WithMany()
                        .HasForeignKey("idTipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tiposUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
