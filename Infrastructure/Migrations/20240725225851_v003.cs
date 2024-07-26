using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autor_Genero_GeneroFavorito",
                table: "Autor");

            migrationBuilder.AddForeignKey(
                name: "FK_Autor_Genero_GeneroFavorito",
                table: "Autor",
                column: "GeneroFavorito",
                principalTable: "Genero",
                principalColumn: "Codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autor_Genero_GeneroFavorito",
                table: "Autor");

            migrationBuilder.AddForeignKey(
                name: "FK_Autor_Genero_GeneroFavorito",
                table: "Autor",
                column: "GeneroFavorito",
                principalTable: "Genero",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
