using PatiNerde.Application.Abtractions.IEntities.IMain;
using PatiNerde.Domain.Entities.Main;
using PatiNerde.Persistence.Contexts;

namespace PatiNerde.Persistence.Entities.Main;

public class AppMapMakerRead : ReadRepository<AppMapMarker, int>, IAppMapMakerRead
{
    public AppMapMakerRead(PatiNerdeDbContext context) : base(context)
    {
    }
}
