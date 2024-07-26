using Api.Extensions;
using Domain.Autor;
using Domain.Genero;
using Domain.Relacionamento;
using Infrastructure.Repository;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IGeneroService, GeneroService>();
builder.Services.AddScoped<GeneroValidator>();
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<AutorValidator>();
builder.Services.AddScoped<ILivroAutorRepository, LivroAutorRepository>();
builder.Services.AddScoped<ILivroAutorService, LivroAutorService>();
builder.Services.AddScoped<LivroAutorValidator>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder
	.Services
	.AddControllers();

builder
	.Services
	.AddEndpointsApiExplorer();

builder
	.Services
	.AddCustomDbContext(builder.Configuration)
	.AddSwaggerGen();

var app = builder.Build();

app.UseMigrateDatabase();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
