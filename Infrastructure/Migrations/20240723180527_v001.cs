using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    MaiorIdade = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Codigo);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GeneroFavorito = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Autor_Genero_GeneroFavorito",
                        column: x => x.GeneroFavorito,
                        principalTable: "Genero",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(type: "char(36)", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Tombo = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Genero = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Livros_Genero_Genero",
                        column: x => x.Genero,
                        principalTable: "Genero",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LivroAutor",
                columns: table => new
                {
                    LivroCodigo = table.Column<Guid>(type: "char(36)", nullable: false),
                    AutorCodigo = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAutor", x => new { x.LivroCodigo, x.AutorCodigo });
                    table.ForeignKey(
                        name: "FK_LivroAutor_Autor_LivroCodigo",
                        column: x => x.LivroCodigo,
                        principalTable: "Autor",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAutor_Livros_AutorCodigo",
                        column: x => x.AutorCodigo,
                        principalTable: "Livros",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Autor_GeneroFavorito",
                table: "Autor",
                column: "GeneroFavorito");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_AutorCodigo",
                table: "LivroAutor",
                column: "AutorCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_Genero",
                table: "Livros",
                column: "Genero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroAutor");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
