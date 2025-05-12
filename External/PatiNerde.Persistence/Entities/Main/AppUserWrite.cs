using PatiNerde.Application.Abtractions.IEntities.IMain;
using PatiNerde.Domain.Entities.Main;
using PatiNerde.Persistence.Contexts;

namespace PatiNerde.Persistence.Entities.Main;

public class AppUserWrite : WriteRepository<AppUser, int> ,IAppUserWrite
{
    public AppUserWrite(PatiNerdeDbContext context) : base(context)
    {
    }
}
