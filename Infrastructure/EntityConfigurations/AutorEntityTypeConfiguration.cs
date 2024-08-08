using Domain.Autor;
using Domain.Genero;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class AutorEntityTypeConfiguration : IEntityTypeConfiguration<Autor>
{
	public void Configure(EntityTypeBuilder<Autor> builder)
	{
		builder.ToTable("Autor");

		builder.HasKey(a => a.Codigo);

		builder.Property(a => a.Codigo)
			.ValueGeneratedNever()
			.IsRequired();

		builder.Property(a => a.Nome)
			.HasMaxLength(255)
			.IsRequired();

		builder.Property(a => a.DataNascimento)
			.IsRequired();

		builder.HasOne<Genero>()
			.WithMany()
			.HasForeignKey(a => a.GeneroFavorito)
			.OnDelete(DeleteBehavior.NoAction)
			.IsRequired();
	}
}
