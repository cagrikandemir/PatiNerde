using MediatR;

namespace PatiNerde.Application.Features.Commands.CMain.CMapMarker;

public class AppMapMarkerUpdateRequest : IRequest<BaseResponse<AppMapMarkerUpdateResponse>>
{
    public int MapMakerId { get; set; }
    public int CreateByUserId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public float Enlem { get; set; }
    public float Boylam { get; set; }
    public bool IsActive { get; set; }
}
