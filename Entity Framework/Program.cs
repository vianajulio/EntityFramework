
using Domain.Genero.Requests;
using Entity_Framework.ConsoleView;
using Entity_Framework.HttpRequests;

internal class Program
{
	private static async Task Main(string[] args)
	{
		await MenuAsync();
	}
	private static async Task MenuAsync()
	{
		Console.Clear();

		Console.WriteLine("--- Selecione uma Opção ---");
		Console.WriteLine("1 - Genero");
		Console.WriteLine("2 - Autor");
		Console.WriteLine("3 - Livro");
		Console.WriteLine("0 - Sair");

		var opcao = await ValidaOpcaoAsync();

		switch (opcao)
		{
			case 1:
				await GeneroAsync();
				break;
			case 2:
				AutorAsync();
				break;
			case 3:
				LivroAsync();
				break;
			case 0:
				break;
		}
	}

	private static async Task<int> ValidaOpcaoAsync()
	{
		int opcao;
		Console.Write("\nOpção: ");
		var opcaoValia = int.TryParse(Console.ReadLine(), out opcao);

		if (!opcaoValia)
		{
			Console.WriteLine("\nOpção inválida.");
			Console.ReadKey();
			await MenuAsync();
		}

		return opcao;
	}

	private static async Task LivroAsync()
	{
		Console.Clear();

		Console.WriteLine("--- Livro ---");
		Console.WriteLine("1 - Cadastrar");
		Console.WriteLine("2 - Atualizar");
		Console.WriteLine("3 - Listar");
		Console.WriteLine("4 - Buscar por ID");
		Console.WriteLine("5 - Deletar");
		Console.WriteLine("0 - Voltar");

		var opcao = await ValidaOpcaoAsync();

		switch (opcao)
		{
			case 1:
				await LivroConsole.Criar();
				await LivroAsync();
				break;
			case 2:
				LivroAsync();
				break;
			case 3:
				await LivroConsole.Listar();
				await LivroAsync();
				break;
			case 4:
				await LivroConsole.ObterPorCodigo();
				await LivroAsync();
				break;
			case 5:
				LivroAsync();
				break;
			case 0:
				MenuAsync();
				break;
			default:
				Console.WriteLine("Opção invalida.");
				Console.ReadKey();
				LivroAsync();
				break;
		}
	}
	private static async Task AutorAsync()
	{
		Console.Clear();

		Console.WriteLine("--- Autor ---");
		Console.WriteLine("1 - Cadastrar");
		Console.WriteLine("2 - Atualizar");
		Console.WriteLine("3 - Listar");
		Console.WriteLine("4 - Buscar por ID");
		Console.WriteLine("5 - Deletar");
		Console.WriteLine("0 - Voltar");

		var opcao = await ValidaOpcaoAsync();

		switch (opcao)
		{
			case 1:
				AutorAsync();
				break;
			case 2:
				AutorAsync();
				break;
			case 3:
				AutorAsync();
				break;
			case 4:
				AutorAsync();
				break;
			case 5:
				AutorAsync();
				break;
			case 0:
				MenuAsync();
				break;
			default:
				Console.WriteLine("Opção invalida.");
				Console.ReadKey();
				AutorAsync();
				break;
		}
	}
	private static async Task GeneroAsync()
	{
		Console.Clear();

		Console.WriteLine("--- Genero ---");
		Console.WriteLine("1 - Cadastrar");
		Console.WriteLine("2 - Atualizar");
		Console.WriteLine("3 - Listar");
		Console.WriteLine("4 - Buscar por ID");
		Console.WriteLine("5 - Deletar");
		Console.WriteLine("0 - Voltar");

		var opcao = await ValidaOpcaoAsync();

		switch (opcao)
		{
			case 1:
				await GeneroConsole.Criar();
				await GeneroAsync();
				break;
			case 2:
				await GeneroConsole.Atualizar();
				await GeneroAsync();
				break;
			case 3:
				await GeneroConsole.Listar();
				await GeneroAsync();
				break;
			case 4:
				await GeneroConsole.ObterPorCodigo();
				await GeneroAsync();
				break;
			case 5:
				await GeneroConsole.Deletar();
				await GeneroAsync();
				break;
			case 0:
				await MenuAsync();
				break;
			default:
				Console.WriteLine("Opção invalida.");
				Console.ReadKey();
				await GeneroAsync();
				break;
		}
	}
}