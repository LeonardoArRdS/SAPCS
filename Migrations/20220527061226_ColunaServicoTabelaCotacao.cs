using Microsoft.EntityFrameworkCore.Migrations;

namespace SAPCS.Migrations
{
    public partial class ColunaServicoTabelaCotacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServicoId",
                table: "Cotacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cotacoes_ServicoId",
                table: "Cotacoes",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotacoes_Servicos_ServicoId",
                table: "Cotacoes",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotacoes_Servicos_ServicoId",
                table: "Cotacoes");

            migrationBuilder.DropIndex(
                name: "IX_Cotacoes_ServicoId",
                table: "Cotacoes");

            migrationBuilder.DropColumn(
                name: "ServicoId",
                table: "Cotacoes");
        }
    }
}
