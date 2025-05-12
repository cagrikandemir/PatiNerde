using Microsoft.Extensions.DependencyInjection;
using PatiNerde.Application.Abtractions.IEntities.IMain;

namespace PatiNerde.Application;

public static class ServiceRegistiration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAppUserWrite, AppUserWrite>();
        services.AddScoped<IAppUserRead, AppUserRead>();

    }

}
