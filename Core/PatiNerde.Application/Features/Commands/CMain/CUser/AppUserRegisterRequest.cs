using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PatiNerde.Application.Features.Commands.CMain.CUser;

public class AppUserRegisterRequest :IRequest<BaseResponse<AppUserRegisterResponse>>
{
    [MaxLength(50)]
    public required string NickName { get; set; }
    [MaxLength(50)]
    public required string Name { get; set; }
    [MaxLength(50)]
    public required string SurName { get; set; }
    [MaxLength(50),EmailAddress]
    public required string Email { get; set; }
    [MaxLength(50)]
    public required string Password { get; set; }
    public required int Phone { get; set; }
    [MaxLength(50)]
    public required string City { get; set; }

}
