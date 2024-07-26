namespace Domain.Autor;

using Domain.Autor.Resquest;
using Domain.Exceptions;
using Relacionamento;
using Livro;

public class Autor
{
	public Guid Codigo { get; set; }
	public string Nome { get; set; } = default!;
	public DateTime DataNascimento { get; set; }
	public Guid GeneroFavorito { get; set; } = default!;
	public IReadOnlyCollection<LivroAutor> Livros { get; set; } = default!;

	public Autor(string nome, DateTime dataNascimento, Guid generoFavorito)
	{
		Codigo = Guid.NewGuid();
		Nome = nome;
		DataNascimento = dataNascimento;
		GeneroFavorito = generoFavorito;
	}

	public Autor(string nome, DateTime dataNascimento, Guid generoFavorito, IReadOnlyCollection<LivroAutor> livros)
	{
		Codigo = Guid.NewGuid();
		Nome = nome;
		DataNascimento = dataNascimento;
		GeneroFavorito = generoFavorito;
		Livros = livros;
	}

	public static Autor CriarAutor(CriarAutorRequest command, AutorValidator validator)
	{
		validator.ValidateCommand(command);

		return new Autor(command.Nome, command.DataNascimento, command.GeneroFavoritoId);
	}

	public static Autor AtualizarAutor(AtualizarAutorRequest command, AutorValidator validator)
	{
		validator.ValidateCommand(command);

		return new Autor(command.Nome, command.DataNascimento, command.GeneroFavoritoId);
	}
}
