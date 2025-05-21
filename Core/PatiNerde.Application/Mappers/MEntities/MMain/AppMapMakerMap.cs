using AutoMapper;
using PatiNerde.Application.Features.Commands.CMain.CMapMarker;
using PatiNerde.Domain.Entities.Main;

namespace PatiNerde.Application.Mappers.MEntities.MMain;

public class AppMapMakerMap: Profile
{
    public AppMapMakerMap()
    {
        CreateMap<AppMapMarker, AppMapMarkerAddResponse>();
        CreateMap<AppMapMarkerAddRequest, AppMapMarker>();

        CreateMap<AppMapMarker, AppMapMarkerRemoveResponse>();
        CreateMap<AppMapMarkerRemoveRequest, AppMapMarker>();

        CreateMap<AppMapMarker, AppMapMarkerUpdateResponse>();
        CreateMap<AppMapMarkerUpdateRequest, AppMapMarker>();   
    }
}
