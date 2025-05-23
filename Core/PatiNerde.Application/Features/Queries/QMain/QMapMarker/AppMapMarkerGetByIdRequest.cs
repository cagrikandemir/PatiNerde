using MediatR;

namespace PatiNerde.Application.Features.Queries.QMain.QMapMarker;

public class AppMapMarkerGetByIdRequest : IRequest<BaseResponse<AppMapMarkerGetByIdResponse>>
{
    public int MapMakerId { get; set; }
}
