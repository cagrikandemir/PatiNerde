using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PatiNerde.Application.Abtractions.IEntities.IMain;
using PatiNerde.Persistence.Contexts;
using PatiNerde.Persistence.Entities.Main;

namespace PatiNerde.Persistence;

public static class ServiceRegistiration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<PatiNerdeDbContext>(options => options
        .UseSqlServer("Server=localhost;Database=PatiNerde;Trusted_Connection=True;TrustServerCertificate=True;"));
    }
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAppUserWrite, AppUserWrite>();
        services.AddScoped<IAppUserRead, AppUserRead>();

    }

}
