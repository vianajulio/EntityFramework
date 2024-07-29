namespace Domain.Relacionamento;
using Livro;
using Autor;
using Domain.Exceptions;
using Domain.Relacionamento.Request;

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

	public static LivroAutor CriarLivroAutor(CriarLivroAutorRequest command, LivroAutorValidator validator)
	{
		validator.ValidateCommand(command);

		return new LivroAutor(command.LivroCodigo, command.AutorCodigo);
	}

	public static LivroAutor AtualizarLivroAutor(AtualizarLivroAutorRequest command, LivroAutorValidator validator)
	{
		validator.ValidateCommand(command);

		return new LivroAutor(command.LivroCodigo, command.AutorCodigo);
	}
}
