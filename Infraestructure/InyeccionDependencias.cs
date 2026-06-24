using Domain;
using Infraestructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

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
