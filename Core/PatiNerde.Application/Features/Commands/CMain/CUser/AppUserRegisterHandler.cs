using MediatR;
using PatiNerde.Application.Abtractions.IServices;
using PatiNerde.Domain.Entities.Main;

namespace PatiNerde.Application.Features.Commands.CMain.CUser;

public class AppUserRegisterHandler : IRequestHandler<AppUserRegisterRequest, BaseResponse<AppUserRegisterResponse>>
{
    private readonly IUserService _userService;
    public AppUserRegisterHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<BaseResponse<AppUserRegisterResponse>> Handle(AppUserRegisterRequest request, CancellationToken cancellationToken)
    {
        AppUserRegisterResponse response = new();

        try
        {
            AppUser? user= await _userService.FindByNickOrEmailAsync(request.NickName, request.Email);
            if(user == null)
            {
                user =await _userService.CreateAsync(request.NickName, request.Name, request.SurName, request.Email, request.Password, request.Phone.ToString(), request.City);
                if (user != null)
                {
                    response.Code = "200";
                    response.Title = "Kayıt Başarılı";
                    return response;
                }
                else
                {
                    response.Title = "Kayıt Başarısız";
                    return response;

                }
            }
            else
            {
                response.Title = "Kullanıcı Zaten Var";
                return response;
            }

        }
        catch (Exception ex)
        {

           response.Title=ex.Message;
        }
        return response;
    } 
}
