namespace Domain.Livro;
using Relacionamento;

public class Livro
{
	public Guid Codigo { get; set; }
	public string Titulo { get; set; } = default!;
	public string Tombo { get; set; } = default!;
	public Guid Genero { get; set; } = default!;
	public ICollection<LivroAutor> Autores { get; set; } = default!;
}
