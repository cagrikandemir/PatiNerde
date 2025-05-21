using MediatR;
using PatiNerde.Domain.Entities.Main;

namespace PatiNerde.Application.Features.Commands.CMain.CMapMarker;

public class AppMapMarkerRemoveRequest :IRequest<BaseResponse<AppMapMarkerRemoveResponse>>
{

    public required int MapMakerId { get; set; }
    public required int CreateByUserId { get; set; }
}
