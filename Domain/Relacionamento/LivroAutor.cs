namespace Domain.Relacionamento;
using Livro;
using Autor;

public class LivroAutor
{
	public Guid LivroCodigo { get; set; }
	public Guid AutorCodigo { get; set; }
	public Livro Livro { get; set; }
	public Autor Autor { get; set; }

	public LivroAutor(Guid livroCodigo, Guid autorCodigo)
	{
		LivroCodigo = livroCodigo;
		AutorCodigo = autorCodigo;
	}
}
