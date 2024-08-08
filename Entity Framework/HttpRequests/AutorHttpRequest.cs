using Domain.Autor;
using Domain.Autor.Resquest;
using System.Net.Http.Json;
using System.Text.Json;

namespace Entity_Framework.HttpRequests;

public class AutorHttpRequest
{
	private static readonly string apiUrl = "http://localhost:5157/livro";

	public static async Task Criar(CriarAutorRequest request)
	{
		var client = new HttpClient();

		var content = new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, "application/json");

		await client.PostAsync(apiUrl, content);
	}

	public static async Task Atualizar(Guid id, AtualizarAutorRequest request)
	{
		var client = new HttpClient();

		await client.PutAsJsonAsync($"{apiUrl}/{id}", request);
	}

	public static async Task<Autor?> ObterPorId(Guid id)
	{
		var client = new HttpClient();

		var response = await client.GetFromJsonAsync<Autor?>($"{apiUrl}/{id}");

		return response;
	}

	public static async Task<IReadOnlyCollection<Autor>> ObterTodos()
	{
		var client = new HttpClient();

		var response = await client.GetFromJsonAsync<Autor[]>(apiUrl);

		return [.. response];
	}

	public static async Task Deletar(Guid id)
	{
		var client = new HttpClient();

		await client.DeleteAsync($"{apiUrl}/{id}");
	}
}
