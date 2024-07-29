using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroAutor_Autor_LivroCodigo",
                table: "LivroAutor");

            migrationBuilder.DropForeignKey(
                name: "FK_LivroAutor_Livros_AutorCodigo",
                table: "LivroAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_LivroAutor_Autor_AutorCodigo",
                table: "LivroAutor",
                column: "AutorCodigo",
                principalTable: "Autor",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LivroAutor_Livros_LivroCodigo",
                table: "LivroAutor",
                column: "LivroCodigo",
                principalTable: "Livros",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroAutor_Autor_AutorCodigo",
                table: "LivroAutor");

            migrationBuilder.DropForeignKey(
                name: "FK_LivroAutor_Livros_LivroCodigo",
                table: "LivroAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_LivroAutor_Autor_LivroCodigo",
                table: "LivroAutor",
                column: "LivroCodigo",
                principalTable: "Autor",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LivroAutor_Livros_AutorCodigo",
                table: "LivroAutor",
                column: "AutorCodigo",
                principalTable: "Livros",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
