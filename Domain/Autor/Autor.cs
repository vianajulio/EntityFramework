namespace Domain.Autor;
using Relacionamento;

public class Autor
{
	public Guid Codigo { get; set; }
	public string Nome { get; set; } = default!;
	public DateTime DataNascimento { get; set; }
	public Guid GeneroFavorito { get; set; } = default!;
	public ICollection<LivroAutor> Livros { get; set; } = default!;
}
