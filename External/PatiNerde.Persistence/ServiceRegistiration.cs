using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PatiNerde.Persistence.Contexts;

namespace PatiNerde.Persistence;

public static class ServiceRegistiration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<PatiNerdeDbContext>(options => options
        .UseSqlServer("Server=localhost;Database=PatiNerde;Trusted_Connection=True;TrustServerCertificate=True;"));
    }
}
