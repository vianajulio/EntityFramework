using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class LivroAutorController : ControllerBase
{
	private readonly ILivroAutorService _livroAutorService;

	public LivroAutorController(ILivroAutorService livroAutorService)
	{
		_livroAutorService = livroAutorService;
	}




}
