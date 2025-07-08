using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimoLivro.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Endereco = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivroName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LivroAutor = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    LivroEditora = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    LivroAnoPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LivroEdicao = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LivroClienteEmprestimos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LceIdCliente = table.Column<int>(type: "int", nullable: false),
                    LceIdLivro = table.Column<int>(type: "int", nullable: false),
                    LceDataEmprestimo = table.Column<DateTime>(type: "datetime", nullable: false),
                    LceDataEntrega = table.Column<DateTime>(type: "datetime", nullable: false),
                    LceEntregue = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroClienteEmprestimos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LIVRO_EMPRESTIMO_CLIENTE",
                        column: x => x.LceIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "GK_LIVRO_CLIENTE_EMPRESTIMO_LIVRO",
                        column: x => x.LceIdLivro,
                        principalTable: "Livro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivroClienteEmprestimos_LceIdCliente",
                table: "LivroClienteEmprestimos",
                column: "LceIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_LivroClienteEmprestimos_LceIdLivro",
                table: "LivroClienteEmprestimos",
                column: "LceIdLivro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroClienteEmprestimos");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
