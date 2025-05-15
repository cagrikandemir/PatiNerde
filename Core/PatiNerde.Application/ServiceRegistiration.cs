using Microsoft.Extensions.DependencyInjection;
using PatiNerde.Application.Features.Commands.CMain.CUser;
using System.Reflection;

namespace PatiNerde.Application;

public static class ServiceRegistiration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));


        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AppUserRegisterHandler).Assembly));

    }

}
