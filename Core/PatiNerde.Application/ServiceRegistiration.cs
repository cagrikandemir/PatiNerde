using Microsoft.Extensions.DependencyInjection;
using PatiNerde.Application.Features.Commands.CMain.CMapMarker;
using PatiNerde.Application.Features.Commands.CMain.CUser;
using PatiNerde.Application.Features.Queries.QMain.QMapMarker;
using System.Reflection;

namespace PatiNerde.Application;

public static class ServiceRegistiration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {    
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AppUserRegisterHandler).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AppMapMarkerAddHandler).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AppMapMarkerRemoveHandler).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AppMapMarkerUpdateHandler).Assembly));
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(AppMapMarkerGetAllHandler).Assembly));

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

}
