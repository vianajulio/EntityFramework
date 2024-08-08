using Domain.Genero;
using Domain.Genero.Requests;
using Entity_Framework.HttpRequests;

namespace Entity_Framework.ConsoleView;

public static class GeneroConsole
{
	public static async Task Criar()
	{
		Console.WriteLine("Criar Genero");

		var dadosValidos = false;

		var nome = string.Empty;
		bool maiorIdade = false;

		while (!dadosValidos)
		{
			Console.Write("Nome: ");
			nome = Console.ReadLine();

			Console.Write("Maior idade (S / N): ");
			var classificacao = Console.ReadLine();

			if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(classificacao))
			{
				if (classificacao.Equals("s") || classificacao.Equals("n"))
				{
					maiorIdade = classificacao.Equals("s") ? false : true;

					dadosValidos = true;
				}
			}
		}

		try
		{
			await GeneroHttpRequest.Criar(new CriarGeneroRequest(nome, maiorIdade));

			Console.Write("\nContinuar: ");
			Console.ReadKey();
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Não foi possivel cadastrar: {ex}");
		}
	}

	public static async Task Atualizar()
	{
		Console.WriteLine("Atualizar Genero");

		var dadosValidos = false;

		var codigo = new Guid();

		var nome = string.Empty;
		bool maiorIdade = false;

		while (!dadosValidos)
		{
			Console.Clear();

			Console.Write("Atualizar Genero");
			Console.Write("\nCódigo do gênero: ");
			var codigoValido = Guid.TryParse(Console.ReadLine(), out codigo);

			Console.Write("Nome: ");
			nome = Console.ReadLine();

			Console.Write("Maior idade (S / N): ");
			var classificacaoMaior = Console.ReadLine().ToLower();

			if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(classificacaoMaior) || !codigoValido)
				continue;

			if (!classificacaoMaior.Equals("s") && !classificacaoMaior.Equals("n"))
				continue;

			maiorIdade = classificacaoMaior.Equals("s") ? true : false;

			dadosValidos = true;
		}

		try
		{
			await GeneroHttpRequest.Atualizar(codigo, new AtualizarGeneroRequest(nome, maiorIdade));

			Console.Write("\nAtualizado com sucesso.");
			Console.Write("Continuar: ");
			Console.ReadKey();
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Não foi possivel atualizar: {ex}");
		}
	}

	public static async Task Listar()
	{
		Console.Clear();

		var dados = await GeneroHttpRequest.ObterTodos();

		Console.WriteLine("Generos:\n");
		foreach (var genero in dados)
		{
			Console.WriteLine($"Código: {genero.Codigo}");
			Console.WriteLine($"Nome: {genero.Nome}");
			Console.WriteLine(genero.MaiorIdade ? "+18" : "Livre");
			Console.WriteLine("------");
		}
		Console.Write("Continuar: ");
		Console.ReadKey();
	}

	public static async Task ObterPorCodigo()
	{
		Console.Clear();

		var codigo = new Guid();

		bool codigoValido = false;

		while (!codigoValido)
		{
			Console.Write("Código do gênero: ");
			codigoValido = Guid.TryParse(Console.ReadLine(), out codigo);

			if (!codigoValido)
			{
				Console.WriteLine("Código inválido. Por favor, tente novamente.");
			}
		}


		var genero = await GeneroHttpRequest.ObterPorId(codigo);

		Console.WriteLine($"Nome: {genero.Nome}");
		Console.WriteLine(genero.MaiorIdade ? "+18" : "Livre");

		Console.Write("\nContinuar: ");
		Console.ReadKey();
	}


	public static async Task Deletar()
	{
		Console.WriteLine("Deletar Gênero\n");

		var codigo = new Guid();
		bool codigoValido = false;

		while (!codigoValido)
		{
			Console.Write("Código do gênero: ");
			codigoValido = Guid.TryParse(Console.ReadLine(), out codigo);

			if (!codigoValido)
			{
				Console.WriteLine("Código inválido. Por favor, tente novamente.");
			}
		}

		try
		{
			await GeneroHttpRequest.Deletar(codigo);
			Console.WriteLine("Gênero deletado com sucesso.");
			Console.Write("Continuar: ");
			Console.ReadKey();
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Erro ao deletar gênero: {ex.Message}");
		}
	}
}
