using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class AjustesNoRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produtos_ProdutoId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_ProdutoId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Vendas");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdProduto",
                table: "Vendas",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produtos_IdProduto",
                table: "Vendas",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produtos_IdProduto",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_IdProduto",
                table: "Vendas");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Vendas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ProdutoId",
                table: "Vendas",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produtos_ProdutoId",
                table: "Vendas",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }
    }
}
