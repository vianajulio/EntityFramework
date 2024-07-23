using Domain.Genero;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityConfigurations;
public class GeneroEntityTypeConfiguration : IEntityTypeConfiguration<Genero>
{
	public void Configure(EntityTypeBuilder<Genero> builder)
	{
		builder.ToTable("Genero");

		builder.HasKey(g => g.Codigo);

		builder.Property(g => g.Codigo)
			.ValueGeneratedNever()
			.IsRequired();

		builder.Property(g => g.Nome)
			.HasMaxLength(255)
			.IsRequired();

		builder.Property(g => g.MaiorIdade)
			.IsRequired();
	}
}
