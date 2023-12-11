using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace senai_eventPlus_webApi_codeFirst_jwt.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
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
                values: new object[] { new Guid("231760d2-258a-4090-bb8f-433d344c4d7d"), "1234567891012", "Rua Niteroi 180", "DevSchool", "Escola Internacional de Desenvolvimento" });

            migrationBuilder.InsertData(
                table: "TipoUsuario",
                columns: new[] { "idTipoUsuario", "tipoUsuario" },
                values: new object[,]
                {
                    { new Guid("3a5689cd-405b-497c-a19c-4d30d46e1e27"), "Comum" },
                    { new Guid("86b6d1fa-bc93-4eaf-a59c-643738438082"), "Administrador" }
                });

            migrationBuilder.InsertData(
                table: "TiposEvento",
                columns: new[] { "idTiposEvento", "tipoEvento" },
                values: new object[,]
                {
                    { new Guid("5b7bec6a-c63b-49b8-9e8b-447931b16d6f"), "C#" },
                    { new Guid("9faaeba4-d33b-4259-aea7-c6458e9bcc83"), "SQL Server" }
                });

            migrationBuilder.InsertData(
                table: "Evento",
                columns: new[] { "idEvento", "dataEvento", "descricao", "horarioEvento", "idInstituicao", "idTipoEvento", "nomeEvento" },
                values: new object[] { new Guid("1755c633-3e97-4a6a-a1ee-7c194b08ec3b"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conceitos básicos do SQL Server, como DDL, DML, DQL.", new TimeSpan(0, 13, 0, 0, 0), new Guid("231760d2-258a-4090-bb8f-433d344c4d7d"), new Guid("9faaeba4-d33b-4259-aea7-c6458e9bcc83"), "Introdução ao banco de dados SQL Server" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "idUsuario", "email", "idTipoUsuario", "nome", "senha" },
                values: new object[,]
                {
                    { new Guid("ec37ff4b-b4f7-4044-8e40-b523dfbbdad0"), "everton@everton.com", new Guid("3a5689cd-405b-497c-a19c-4d30d46e1e27"), "Everton Araujo", "$2a$11$YQ.GjYDSK.uu8uYkHXpTKuNjNE7zi5PgEWR.PAPjifMeh3WgL1IWe" },
                    { new Guid("f07a5c55-0598-45ef-94e9-10aec630ddc0"), "allan@allan.com", new Guid("86b6d1fa-bc93-4eaf-a59c-643738438082"), "Allan Rodrigues", "$2a$11$luLsWzrmhOeauQ3Xi0LPgeyqkgy4kGLXuB4eXMiuAgtVhaHbY9vxO" }
                });

            migrationBuilder.InsertData(
                table: "Comentario",
                columns: new[] { "idComentario", "descricao", "exibe", "idEvento", "idUsuario" },
                values: new object[] { new Guid("fddf3ef0-8dcd-4707-a27d-0b47ed44c89a"), "Excelente evento", true, new Guid("1755c633-3e97-4a6a-a1ee-7c194b08ec3b"), new Guid("ec37ff4b-b4f7-4044-8e40-b523dfbbdad0") });

            migrationBuilder.InsertData(
                table: "PresencasEvento",
                columns: new[] { "idPresencasEvento", "idEvento", "idUsuario", "situacao" },
                values: new object[] { new Guid("52dde104-eff1-45a4-89fb-2b6949a3071c"), new Guid("1755c633-3e97-4a6a-a1ee-7c194b08ec3b"), new Guid("ec37ff4b-b4f7-4044-8e40-b523dfbbdad0"), true });

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
