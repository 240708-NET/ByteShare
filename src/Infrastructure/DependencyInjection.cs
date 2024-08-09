using ByteShare.Application.Repository;
using ByteShare.Domain.Entities;
using ByteShare.Infrastructure.Persistence;
using ByteShare.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ByteShare.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options
            .UseSqlServer(
                connection,
                // TODO: Need to get the migration assembly dynamically.
                // b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                b => b.MigrationsAssembly("ByteShare.Web.API")
            )
        );

        //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRecipeRepository, RecipeRepository>();
        services.AddScoped<IRepository<Rating, int?>, GenericRepository<Rating, int?>>();
        services.AddScoped<IRepository<Ingredient, int?>, GenericRepository<Ingredient, int?>>();

        return services;
    }
}
