using Domain.Genero;
using Domain.Genero.Requests;
using System.Net.Http.Json;
using System.Text.Json;

namespace Entity_Framework.HttpRequests;

public class GeneroHttpRequest
{
	private static readonly string apiUrl = "http://localhost:5157/genero";

	public static async Task Criar(CriarGeneroRequest request)
	{
		var client = new HttpClient();

		var content = new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, "application/json");

		await client.PostAsync(apiUrl, content);
	}

	public static async Task Atualizar(Guid id, AtualizarGeneroRequest request)
	{
		var client = new HttpClient();

		await client.PutAsJsonAsync($"{apiUrl}/{id}", request);
	}

	public static async Task<Genero?> ObterPorId(Guid id)
	{
		var client = new HttpClient();

		var response = await client.GetFromJsonAsync<Genero?>($"{apiUrl}/{id}");

		return response;
	}

	public static async Task<IReadOnlyCollection<Genero>> ObterTodos()
	{
		var client = new HttpClient();

		var response = await client.GetFromJsonAsync<Genero[]>(apiUrl);

		return [.. response];
	}

	public static async Task Deletar(Guid id)
	{
		var client = new HttpClient();

		await client.DeleteAsync($"{apiUrl}/{id}");
	}
}
