namespace Domain.Livro;
using Relacionamento;
using Autor;

public class Livro
{
	public Guid Codigo { get; set; }
	public string Titulo { get; set; } = default!;
	public string Tombo { get; set; } = default!;
	public Guid Genero { get; set; } = default!;
	public IReadOnlyCollection<LivroAutor> Autores { get; set; } = default!;
}
