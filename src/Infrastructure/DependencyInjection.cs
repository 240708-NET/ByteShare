//using ByteShare.Application.Common.Interface;
using ByteShare.Application.Persistence;
using ByteShare.Domain.Entities;
using ByteShare.Infrastructure.Persistence;
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

        services.AddScoped<IRepository<User>, Repository<User>>();
        services.AddScoped<IRepository<Recipe>, Repository<Recipe>>();
        services.AddScoped<IRepository<RecipeRating>, Repository<RecipeRating>>();
        services.AddScoped<IRepository<RecipeIngredient>, Repository<RecipeIngredient>>();
        services.AddScoped<IRepository<Ingredient>, Repository<Ingredient>>();

        return services;
    }
}
