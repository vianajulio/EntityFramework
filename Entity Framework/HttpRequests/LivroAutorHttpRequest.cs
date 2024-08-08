using Domain.Autor;
using Domain.Livro;
using System.Net.Http.Json;

namespace Entity_Framework.HttpRequests;

public class LivroAutorHttpRequest
{
	private static readonly string apiUrl = "http://localhost:5157/livroautor";

	public static async Task<Autor[]?> ObterAutoresPorCodigoLivroAsync(Guid id)
	{
		var client = new HttpClient();

		var autores =  await client.GetFromJsonAsync<Autor[]>($"{apiUrl}/autor/{id}");

		return autores;
	}

	public static async Task<Livro[]?> ObterLivrosPorCodigoAutorAsync(Guid id)
	{
		var client = new HttpClient();

		var livros = await client.GetFromJsonAsync<Livro[]>($"{apiUrl}/livro/{id}");

		return livros;
	}
}
