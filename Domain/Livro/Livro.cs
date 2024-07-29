namespace Domain.Livro;

using Domain.Exceptions;
using Domain.Livro.Request;
using Relacionamento;

public class Livro
{
	public Guid Codigo { get; set; }
	public string Titulo { get; set; } = default!;
	public string Tombo { get; set; } = default!;
	public Guid Genero { get; set; } = default!;
	public IReadOnlyCollection<LivroAutor> Autores { get; set; } = default!;

	public Livro()
	{

	}

	public Livro(string titulo, string tombo, Guid genero, IReadOnlyCollection<Guid> autoresId)
	{
		Titulo = titulo;
		Tombo = tombo;
		Genero = genero;
		Autores = autoresId.Select(x => new LivroAutor(Codigo, x)).ToList();
	}

	public Livro(Guid codigo, string titulo, string tombo, Guid genero)
	{
		Codigo = codigo;
		Titulo = titulo;
		Tombo = tombo;
		Genero = genero;
		//Autores = autoresId.Select(x => new LivroAutor(Codigo, x)).ToList();
	}

	public static Livro CriarLivro(CriarLivroRequest command, LivroValidator validator)
	{
		validator.ValidateCommand(command);

		return new Livro(Guid.NewGuid(), command.Titulo, command.Tombo, command.Genero);
	}

	public static Livro AtualizarLivro(AtualizarLivroRequest command, LivroValidator validator)
	{
		validator.ValidateCommand(command);

		return new Livro(command.Titulo, command.Tombo, command.Genero, command.AutoresCodigo);
	}
}
