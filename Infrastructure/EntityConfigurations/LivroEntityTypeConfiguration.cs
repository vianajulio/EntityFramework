using Domain.Genero;
using Domain.Livro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;
public class LivroEntityTypeConfiguration : IEntityTypeConfiguration<Livro>
{
	public void Configure(EntityTypeBuilder<Livro> builder)
	{
		builder.ToTable("Livros");

		builder.HasKey(l => l.Codigo);

		builder.Property(l => l.Codigo)
			.ValueGeneratedNever()
			.IsRequired();

		builder.Property(l => l.Titulo)
			.HasMaxLength(255)
			.IsRequired();

		builder.Property(l => l.Tombo)
			.HasMaxLength(255)
			.IsRequired();

		builder.HasOne<Genero>()
			.WithMany()
			.HasForeignKey(l => l.Genero)
			.IsRequired();
	}
}
