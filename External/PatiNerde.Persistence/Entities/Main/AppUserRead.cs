using PatiNerde.Application.Abtractions.IEntities.IMain;
using PatiNerde.Domain.Entities.Main;
using PatiNerde.Persistence.Contexts;

namespace PatiNerde.Persistence.Entities.Main;

public class AppUserRead : ReadRepository<AppUser, int>, IAppUserRead
{
    public AppUserRead(PatiNerdeDbContext context) : base(context)
    {
    }
}
