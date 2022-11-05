using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    public partial class configuratabaladois : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Livros",
                table: "Livros");

            migrationBuilder.RenameTable(
                name: "Livros",
                newName: "tb_livro");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tb_livro",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "tb_livro",
                newName: "genero");

            migrationBuilder.RenameColumn(
                name: "Autor",
                table: "tb_livro",
                newName: "autor");

            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "tb_livro",
                newName: "ano");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_livro",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_livro",
                table: "tb_livro",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_livro",
                table: "tb_livro");

            migrationBuilder.RenameTable(
                name: "tb_livro",
                newName: "Livros");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Livros",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "genero",
                table: "Livros",
                newName: "Genero");

            migrationBuilder.RenameColumn(
                name: "autor",
                table: "Livros",
                newName: "Autor");

            migrationBuilder.RenameColumn(
                name: "ano",
                table: "Livros",
                newName: "Ano");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Livros",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livros",
                table: "Livros",
                column: "Id");
        }
    }
}
