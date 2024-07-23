using System.Reflection;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class DatabaseExtensions
{
	// utilizado para configurar o banco de dados no projeto
	public static IServiceCollection AddCustomDbContext(this IServiceCollection services,
		IConfiguration configuration)
	{
		ArgumentException.ThrowIfNullOrEmpty(configuration.GetConnectionString("DataConnection"));

		services.AddDbContext<DataContext>(options =>
			{
				options.UseMySQL(configuration.GetConnectionString("DataConnection")!,
					sqlOptions =>
					{
						sqlOptions.MigrationsAssembly(typeof(DataContext).GetTypeInfo().Assembly.GetName().Name);
						sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(5), null!);
					});
			}
		);

		return services;
	}

	// configuração da criação da migration da database
	public static IApplicationBuilder UseMigrateDatabase(this IApplicationBuilder appBuilder)
	{
		using var scope = appBuilder.ApplicationServices.CreateScope();
		
		using var context = scope.ServiceProvider.GetRequiredService<DataContext>();

		context.Database.Migrate();

		return appBuilder;
	}

}
