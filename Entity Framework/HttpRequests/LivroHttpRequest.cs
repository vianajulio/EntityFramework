using System.Net.Http.Json;
using System.Text.Json;
using Domain.Livro;
using Domain.Livro.Request;

namespace Entity_Framework.HttpRequests;

public class LivroHttpRequest
{
	private static readonly string apiUrl = "http://localhost:5157/livro";

	public static async Task Criar(CriarLivroRequest request)
	{
		var client = new HttpClient();

		var content = new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, "application/json");

		await client.PostAsync(apiUrl, content);
	}

	public static async Task Atualizar(Guid id, AtualizarLivroRequest request)
	{
		var client = new HttpClient();

		await client.PutAsJsonAsync($"{apiUrl}/{id}", request);
	}

	public static async Task<Livro?> ObterPorId(Guid id)
	{
		var client = new HttpClient();

		var response = await client.GetFromJsonAsync<Livro?>($"{apiUrl}/{id}");

		return response;
	}

	public static async Task<IReadOnlyCollection<Livro>> ObterTodos()
	{
		var client = new HttpClient();

		var response = await client.GetFromJsonAsync<Livro[]>(apiUrl);

		return [.. response];
	}

	public static async Task Deletar(Guid id)
	{
		var client = new HttpClient();

		await client.DeleteAsync($"{apiUrl}/{id}");
	}
}
