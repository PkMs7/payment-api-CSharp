using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testes.Migrations
{
    public partial class TesteVendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DadosVendedorId = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdutosVendidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusVenda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Vendedores_DadosVendedorId",
                        column: x => x.DadosVendedorId,
                        principalTable: "Vendedores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_DadosVendedorId",
                table: "Vendas",
                column: "DadosVendedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Vendedores");
        }
    }
}
