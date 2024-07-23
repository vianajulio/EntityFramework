using Api.Extensions;
using Domain.Genero.Validators;
using Infrastructure.Repository;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IGeneroService, GeneroService>();
builder.Services.AddScoped<GeneroValidator>();

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
