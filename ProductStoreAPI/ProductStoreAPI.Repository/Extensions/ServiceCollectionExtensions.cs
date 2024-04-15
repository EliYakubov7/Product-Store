using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductStoreAPI.Repository.Repositories.Auth;
using ProductStoreAPI.Repository.Repositories.Product;
using ProductStoreAPI.Repository.Repositories.User;

namespace ProductStoreAPI.Repository.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddMySqlConnection(
			this IServiceCollection services,
			IConfiguration configuration,
			string assembly)
		{
			var connectionString = configuration.GetConnectionString("ProductStoreConnection");

			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), sql => sql.MigrationsAssembly(assembly));
			});

			return services;
		}

		public static IServiceCollection AddRepositoryInfrastructure(this IServiceCollection services)
		{
			return
				services
					.AddTransient<IUserRepository, UserRepository>()
					.AddTransient<IProductRepository, ProductRepository>()
					.AddTransient<IAuthRepository, AuthRepository>();
		}
	}
}
