using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Reflection;
using Taks1.Persistence.Data;
using Taks1.Services;

namespace Taks1;

public static class DependencyInjection
{
	public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("DefaultConnection")
			?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

		services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(connectionString));

		services
			.AddMapsterConfig()
			.AddFluentValidationConfig();

		services.AddScoped<IInvoiceService, InvoiceService>();

		return services;
	}

	private static IServiceCollection AddMapsterConfig(this IServiceCollection services)
	{

		
		var mappingConfig = TypeAdapterConfig.GlobalSettings;
		mappingConfig.Scan(Assembly.GetExecutingAssembly());
		services.AddSingleton<IMapper>(new Mapper(mappingConfig));


		return services;
	}

	private static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
	{
		services
			.AddFluentValidationAutoValidation()
			.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


		return services;
	}
}