using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAPCS.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCli = table.Column<string>(type: "varchar(100)", nullable: false),
                    TelCli = table.Column<string>(type: "varchar(11)", nullable: false),
                    ValTel = table.Column<string>(type: "varchar(11)", nullable: false),
                    CPFCli = table.Column<string>(type: "varchar(11)", nullable: true),
                    EmailCli = table.Column<string>(type: "varchar(60)", nullable: true),
                    ValEmail = table.Column<string>(type: "varchar(11)", nullable: true),
                    DtNascCli = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusCli = table.Column<int>(type: "int", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DtModificacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFunc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelFunc = table.Column<string>(type: "varchar(13)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seguradoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSegur = table.Column<string>(type: "varchar(50)", nullable: false),
                    EndSegur = table.Column<string>(type: "varchar(100)", nullable: true),
                    TelSegur = table.Column<string>(type: "varchar(13)", nullable: true),
                    SiteSegur = table.Column<string>(type: "varchar(40)", nullable: true),
                    NomeContSegur = table.Column<string>(type: "varchar(80)", nullable: true),
                    EmailContSegur = table.Column<string>(type: "varchar(50)", nullable: true),
                    StatusSegur = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguradoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApolicesSegur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeArquivo = table.Column<string>(type: "varchar(30)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApolicesSegur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApolicesSegur_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApolicesSegur_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cotacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    StatusCot = table.Column<int>(type: "int", nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtModificacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cotacoes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotacoes_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(50)", nullable: false),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeServ = table.Column<string>(type: "varchar(60)", nullable: true),
                    SeguradoraId = table.Column<int>(type: "int", nullable: false),
                    StatusServ = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Seguradoras_SeguradoraId",
                        column: x => x.SeguradoraId,
                        principalTable: "Seguradoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApolicesSegur_ClienteId",
                table: "ApolicesSegur",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ApolicesSegur_FuncionarioId",
                table: "ApolicesSegur",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotacoes_ClienteId",
                table: "Cotacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotacoes_FuncionarioId",
                table: "Cotacoes",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_SeguradoraId",
                table: "Servicos",
                column: "SeguradoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FuncionarioId",
                table: "Usuarios",
                column: "FuncionarioId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApolicesSegur");

            migrationBuilder.DropTable(
                name: "Cotacoes");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Seguradoras");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
