using PatiNerde.Application.Abtractions.IEntities;
using PatiNerde.Application.Abtractions.IEntities.IMain;
using PatiNerde.Domain.Entities.Main;
using PatiNerde.Persistence.Contexts;

namespace PatiNerde.Persistence.Entities.Main;

public class AppMapMakerWrite : WriteRepository<AppMapMaker, int>, IAppMapMakerWrite
{
    public AppMapMakerWrite(PatiNerdeDbContext context) : base(context)
    {
    }
}
