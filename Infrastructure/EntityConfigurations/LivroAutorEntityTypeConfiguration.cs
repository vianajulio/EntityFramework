using Domain.Relacionamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class LivroAutorEntityTypeConfiguration : IEntityTypeConfiguration<LivroAutor>
{
	public void Configure(EntityTypeBuilder<LivroAutor> builder)
	{
		builder.ToTable("LivroAutor");

		builder.HasKey(la => new { la.LivroCodigo, la.AutorCodigo });

		builder.HasOne(la => la.Autor)
			.WithMany(l => l.Livros)
			.HasForeignKey(la => la.LivroCodigo);

		builder.HasOne(la => la.Livro)
			.WithMany(a => a.Autores)
			.HasForeignKey(la => la.AutorCodigo);
	}
}
