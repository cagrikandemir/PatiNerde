using PatiNerde.Domain.Entities.Main;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace PatiNerde.Application.Features.Commands.CMain.CMapMarker;

public class AppMapMarkerRequest : IRequest<BaseResponse<AppMapMarkerResponse>>
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required float Enlem { get; set; }
    public required float Boylam { get; set; }
    public required int CreateByUserId { get; set; }

}
