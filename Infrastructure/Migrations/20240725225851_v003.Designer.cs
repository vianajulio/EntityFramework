﻿// <auto-generated />
using System;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240725225851_v003")]
    partial class v003
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Autor.Autor", b =>
                {
                    b.Property<Guid>("Codigo")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("GeneroFavorito")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Codigo");

                    b.HasIndex("GeneroFavorito");

                    b.ToTable("Autor", (string)null);
                });

            modelBuilder.Entity("Domain.Genero.Genero", b =>
                {
                    b.Property<Guid>("Codigo")
                        .HasColumnType("char(36)");

                    b.Property<bool>("MaiorIdade")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Codigo");

                    b.ToTable("Genero", (string)null);
                });

            modelBuilder.Entity("Domain.Livro.Livro", b =>
                {
                    b.Property<Guid>("Codigo")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Genero")
                        .HasColumnType("char(36)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Tombo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Codigo");

                    b.HasIndex("Genero");

                    b.ToTable("Livros", (string)null);
                });

            modelBuilder.Entity("Domain.Relacionamento.LivroAutor", b =>
                {
                    b.Property<Guid>("LivroCodigo")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AutorCodigo")
                        .HasColumnType("char(36)");

                    b.HasKey("LivroCodigo", "AutorCodigo");

                    b.HasIndex("AutorCodigo");

                    b.ToTable("LivroAutor", (string)null);
                });

            modelBuilder.Entity("Domain.Autor.Autor", b =>
                {
                    b.HasOne("Domain.Genero.Genero", null)
                        .WithMany()
                        .HasForeignKey("GeneroFavorito")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Livro.Livro", b =>
                {
                    b.HasOne("Domain.Genero.Genero", null)
                        .WithMany()
                        .HasForeignKey("Genero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Relacionamento.LivroAutor", b =>
                {
                    b.HasOne("Domain.Livro.Livro", "Livro")
                        .WithMany("Autores")
                        .HasForeignKey("AutorCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Autor.Autor", "Autor")
                        .WithMany("Livros")
                        .HasForeignKey("LivroCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Domain.Autor.Autor", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("Domain.Livro.Livro", b =>
                {
                    b.Navigation("Autores");
                });
#pragma warning restore 612, 618
        }
    }
}
