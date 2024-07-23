using System.Reflection;
using Domain.Autor;
using Domain.Genero;
using Domain.Livro;
using Domain.Relacionamento;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
	public DbSet<Autor> Autor { get; set; }
	public DbSet<Livro> Livro { get; set; }
	public DbSet<Genero> Genero { get; set; }
	public DbSet<LivroAutor> LivroAutor { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
