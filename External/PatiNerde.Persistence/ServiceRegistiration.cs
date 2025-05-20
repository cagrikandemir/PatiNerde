using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PatiNerde.Application.Abtractions.IEntities;
using PatiNerde.Application.Abtractions.IEntities.IMain;
using PatiNerde.Application.Abtractions.IServices;
using PatiNerde.Application.Features.Commands.CMain.CUser;
using PatiNerde.Persistence.Contexts;
using PatiNerde.Persistence.Entities;
using PatiNerde.Persistence.Entities.Main;
using PatiNerde.Persistence.Services;

namespace PatiNerde.Persistence;

public static class ServiceRegistiration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<PatiNerdeDbContext>(options => options
        .UseSqlServer("Server=localhost;Database=PatiNerde;Trusted_Connection=True;TrustServerCertificate=True;"));



        services.AddScoped(typeof(IReadRepository<,>), typeof(ReadRepository<,>));
        services.AddScoped(typeof(IWriteRepository<,>), typeof(WriteRepository<,>));
        services.AddScoped<IAppUserRead, AppUserRead>();
        services.AddScoped<IAppUserWrite, AppUserWrite>();
        services.AddScoped<IAppMapMakerRead, AppMapMakerRead>();
        services.AddScoped<IAppMapMakerWrite, AppMapMakerWrite>();

        services.AddScoped<IUserService, UserService>();

    }
}
