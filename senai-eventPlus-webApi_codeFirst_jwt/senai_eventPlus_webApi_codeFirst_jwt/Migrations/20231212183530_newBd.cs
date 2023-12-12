using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace senai_eventPlus_webApi_codeFirst_jwt.Migrations
{
    /// <inheritdoc />
    public partial class newBd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    idInstituicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cnpj = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    endereco = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    razaoSocial = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    nomeFantasia = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.idInstituicao);
                });

            migrationBuilder.CreateTable(
                name: "TiposEvento",
                columns: table => new
                {
                    idTiposEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipoEvento = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEvento", x => x.idTiposEvento);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    idTipoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipoUsuario = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.idTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    idEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idInstituicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idTipoEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nomeEvento = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    dataEvento = table.Column<DateTime>(type: "DATE", nullable: false),
                    horarioEvento = table.Column<TimeSpan>(type: "TIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.idEvento);
                    table.ForeignKey(
                        name: "FK_Evento_Instituicao_idInstituicao",
                        column: x => x.idInstituicao,
                        principalTable: "Instituicao",
                        principalColumn: "idInstituicao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evento_TiposEvento_idTipoEvento",
                        column: x => x.idTipoEvento,
                        principalTable: "TiposEvento",
                        principalColumn: "idTiposEvento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    senha = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    idTipoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario_idTipoUsuario",
                        column: x => x.idTipoUsuario,
                        principalTable: "TipoUsuario",
                        principalColumn: "idTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    idComentario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    exibe = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.idComentario);
                    table.ForeignKey(
                        name: "FK_Comentario_Evento_idEvento",
                        column: x => x.idEvento,
                        principalTable: "Evento",
                        principalColumn: "idEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentario_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PresencasEvento",
                columns: table => new
                {
                    idPresencasEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    situacao = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresencasEvento", x => x.idPresencasEvento);
                    table.ForeignKey(
                        name: "FK_PresencasEvento_Evento_idEvento",
                        column: x => x.idEvento,
                        principalTable: "Evento",
                        principalColumn: "idEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresencasEvento_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Instituicao",
                columns: new[] { "idInstituicao", "cnpj", "endereco", "nomeFantasia", "razaoSocial" },
                values: new object[] { new Guid("cd362236-3720-4143-9b41-a2ae822b625f"), "1234567891012", "Rua Niteroi 180", "DevSchool", "Escola Internacional de Desenvolvimento" });

            migrationBuilder.InsertData(
                table: "TipoUsuario",
                columns: new[] { "idTipoUsuario", "tipoUsuario" },
                values: new object[,]
                {
                    { new Guid("4833f49b-57d1-4c9e-a06b-6baa7bdc51d4"), "Comum" },
                    { new Guid("f36a1eeb-7da0-4494-8d7f-75ab065b5ef9"), "Administrador" }
                });

            migrationBuilder.InsertData(
                table: "TiposEvento",
                columns: new[] { "idTiposEvento", "tipoEvento" },
                values: new object[,]
                {
                    { new Guid("798a82a9-603f-4acb-9e95-c702516521a2"), "SQL Server" },
                    { new Guid("9b990fd5-3453-4e78-93d7-d3744e286c7a"), "C#" }
                });

            migrationBuilder.InsertData(
                table: "Evento",
                columns: new[] { "idEvento", "dataEvento", "descricao", "horarioEvento", "idInstituicao", "idTipoEvento", "nomeEvento" },
                values: new object[] { new Guid("5f1f1303-ca5e-49ae-9965-49b0d68d8a22"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conceitos básicos do SQL Server, como DDL, DML, DQL.", new TimeSpan(0, 13, 0, 0, 0), new Guid("cd362236-3720-4143-9b41-a2ae822b625f"), new Guid("798a82a9-603f-4acb-9e95-c702516521a2"), "Introdução ao banco de dados SQL Server" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "idUsuario", "email", "idTipoUsuario", "nome", "senha" },
                values: new object[,]
                {
                    { new Guid("2cc26499-e267-43f9-9a2b-ac8c456020e6"), "allan@allan.com", new Guid("f36a1eeb-7da0-4494-8d7f-75ab065b5ef9"), "Allan Rodrigues", "$2a$11$C2RPbDEaAqTlNwdkf/sXqud7UwCVy2pSk/f/O4WHN82SgMJRyH5/W" },
                    { new Guid("620f8aa7-0f7f-4f2d-85dc-3093e7c18568"), "everton@everton.com", new Guid("4833f49b-57d1-4c9e-a06b-6baa7bdc51d4"), "Everton Araujo", "$2a$11$JluE6BFJjlxWmcDZDqfX.O9pbnlVNGttCo77Tolv4fjpVA.bokV9u" }
                });

            migrationBuilder.InsertData(
                table: "Comentario",
                columns: new[] { "idComentario", "descricao", "exibe", "idEvento", "idUsuario" },
                values: new object[] { new Guid("1ca7e7e3-19f7-472f-aaf2-978ecb1dd1c6"), "Excelente evento", true, new Guid("5f1f1303-ca5e-49ae-9965-49b0d68d8a22"), new Guid("620f8aa7-0f7f-4f2d-85dc-3093e7c18568") });

            migrationBuilder.InsertData(
                table: "PresencasEvento",
                columns: new[] { "idPresencasEvento", "idEvento", "idUsuario", "situacao" },
                values: new object[] { new Guid("2c7f43b4-e14d-467a-b14e-7a09e70182b8"), new Guid("5f1f1303-ca5e-49ae-9965-49b0d68d8a22"), new Guid("620f8aa7-0f7f-4f2d-85dc-3093e7c18568"), true });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_idEvento",
                table: "Comentario",
                column: "idEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_idUsuario",
                table: "Comentario",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_idInstituicao",
                table: "Evento",
                column: "idInstituicao");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_idTipoEvento",
                table: "Evento",
                column: "idTipoEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicao_cnpj",
                table: "Instituicao",
                column: "cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PresencasEvento_idEvento",
                table: "PresencasEvento",
                column: "idEvento");

            migrationBuilder.CreateIndex(
                name: "IX_PresencasEvento_idUsuario",
                table: "PresencasEvento",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TiposEvento_tipoEvento",
                table: "TiposEvento",
                column: "tipoEvento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoUsuario_tipoUsuario",
                table: "TipoUsuario",
                column: "tipoUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_email",
                table: "Usuario",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idTipoUsuario",
                table: "Usuario",
                column: "idTipoUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "PresencasEvento");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropTable(
                name: "TiposEvento");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
