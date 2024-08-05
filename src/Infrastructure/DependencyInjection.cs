using ByteShare.Application.Common.Interface;
using ByteShare.Application.Repository;
using ByteShare.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ByteShare.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            options.UseSqlServer(
                connection,
                // TODO: Need to get the migration assembly dynamically.
                // b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                b => b.MigrationsAssembly("ByteShare.Web.Api")
            )
        );

        //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
