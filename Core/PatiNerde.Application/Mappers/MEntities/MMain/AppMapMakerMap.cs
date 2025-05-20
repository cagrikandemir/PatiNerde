using AutoMapper;
using PatiNerde.Application.Features.Commands.CMain.CMapMarker;
using PatiNerde.Domain.Entities.Main;

namespace PatiNerde.Application.Mappers.MEntities.MMain;

public class AppMapMakerMap: Profile
{
    public AppMapMakerMap()
    {
        CreateMap<AppMapMaker, AppMapMarkerResponse>();

        CreateMap<AppMapMarkerRequest, AppMapMaker>();
    }
}
