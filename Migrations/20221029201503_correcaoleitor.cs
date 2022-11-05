using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    public partial class correcaoleitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Leitores",
                table: "Leitores");

            migrationBuilder.RenameTable(
                name: "Leitores",
                newName: "tb_leitor");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tb_leitor",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "tb_leitor",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "tb_leitor",
                newName: "datanascimento");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_leitor",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_leitor",
                table: "tb_leitor",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_leitor",
                table: "tb_leitor");

            migrationBuilder.RenameTable(
                name: "tb_leitor",
                newName: "Leitores");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Leitores",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Leitores",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "datanascimento",
                table: "Leitores",
                newName: "DataNascimento");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Leitores",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leitores",
                table: "Leitores",
                column: "Id");
        }
    }
}
