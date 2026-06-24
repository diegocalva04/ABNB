using Domain;
using Infraestructure.Data.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure;

public static class InyeccionDependencias
{
    public static void AddInfraestructure(this IServiceCollection services)
    {
        var connectionString = services
            .BuildServiceProvider()
            .GetRequiredService<IConfiguration>()
            .GetConnectionString("abnbdb");
        services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
    }
}
