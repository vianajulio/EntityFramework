using Domain.Livro.Request;
using Entity_Framework.HttpRequests;

namespace Entity_Framework.ConsoleView;

public class LivroConsole
{
	public static async Task Criar()
	{
		Console.Clear();

		Console.WriteLine("Criar Livro:");

		var titulo = string.Empty;
		var tombo = string.Empty;
		var generoId = new Guid();

		var dadosValidos = false;

		while (!dadosValidos)
		{
			try
			{
				Console.Write("Titulo: ");
				titulo = Console.ReadLine();

				Console.Write("Tombo: ");
				tombo = Console.ReadLine();

				Console.Write("Codigo genero: ");
				generoId = Guid.Parse(Console.ReadLine());

				if (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(tombo))
					continue;

				dadosValidos = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				Console.ReadKey();
				continue;
			}
		}

		try
		{
			await LivroHttpRequest.Criar(new CriarLivroRequest(titulo, tombo, generoId));

			Console.Write("Cadastrado com sucesso.");
			Console.Write("\nContinuar: ");
			Console.ReadKey();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
			Console.ReadKey();
		}
	}

	public static async Task Atualizar()
	{
		Console.Clear();

		Console.WriteLine("Atualizar Livro:\n");

		var dadosValidos = false;

		var codigoLivro = Guid.Empty;
		var titulo = string.Empty;
		var tombo = string.Empty;
		var generoId = Guid.Empty;


		while (!dadosValidos)
		{
			Console.Write("Codigo livro: ");
			var validaCodLivro = Guid.TryParse(Console.ReadLine(), out codigoLivro);

			Console.Write("Titulo: ");
			titulo = Console.ReadLine();

			Console.Write("Tombo: ");
			tombo = Console.ReadLine();

			Console.Write("Codigo genero: ");
			var validaCodGenero = Guid.TryParse(Console.ReadLine(), out generoId);

			if (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(tombo))
				continue;

			if (!validaCodLivro || !validaCodGenero)
				continue;

			dadosValidos = true;
		}

		try
		{
			await LivroHttpRequest.Atualizar(codigoLivro, new AtualizarLivroRequest(titulo, tombo, generoId));

			Console.Write("\nAtualizado com sucesso.");
			Console.Write("Continuar: ");
			Console.ReadKey();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}

	public static async Task Listar()
	{
		Console.Clear();

		Console.WriteLine("Livros:");

		var dados = await LivroHttpRequest.ObterTodos();

		foreach (var livro in dados)
		{
			Console.WriteLine(livro.Codigo);
			Console.WriteLine(livro.Titulo);
			Console.WriteLine(await GeneroHttpRequest.ObterPorId(livro.Genero));
			//criar LivroAutorHttp
			Console.WriteLine("");
		}

		Console.Write("\nContinuar: ");
		Console.ReadKey();
	}

	public static async Task ObterPorCodigo()
	{
		Console.Clear();

		Console.WriteLine("Livro:");

		var codigoValido = false;
		var livroCodigo = Guid.NewGuid();

		while (!codigoValido)
		{
			Console.Write("Codigo livro: ");
			codigoValido = Guid.TryParse(Console.ReadLine(), out livroCodigo);

			if (!codigoValido)
			{
				Console.Write("Valor invalido");
				Console.ReadKey();
				continue;
			}

			codigoValido = true;
		}

		try
		{
			var livro = await LivroHttpRequest.ObterPorId(livroCodigo);

			var autores = await LivroAutorHttpRequest.ObterAutoresPorCodigoLivroAsync(livroCodigo);

			Console.WriteLine(livro.Codigo);
			Console.WriteLine(livro.Titulo);
			Console.WriteLine(livro.Tombo);
			Console.WriteLine(await GeneroHttpRequest.ObterPorId(livro.Genero));
			foreach (var autor in autores)
			{
				Console.WriteLine(autor.Codigo);
				Console.WriteLine(autor.Nome);
				Console.WriteLine(await GeneroHttpRequest.ObterPorId(autor.GeneroFavorito));
			}

		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}


	}

}
