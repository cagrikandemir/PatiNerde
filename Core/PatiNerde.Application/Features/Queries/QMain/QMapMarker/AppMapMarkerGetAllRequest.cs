using MediatR;

namespace PatiNerde.Application.Features.Queries.QMain.QMapMarker;

public class AppMapMarkerGetAllRequest : IRequest<BaseResponse<AppMapMarkerGetAllResponse>>
{
}
