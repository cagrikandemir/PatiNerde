using PatiNerde.Domain.Entities.Main;

namespace PatiNerde.Application.Abtractions.IServices;

public interface IUserService
{
    Task<AppUser?> FindByNickNameAsync(string NickName);

    Task<AppUser?> FindByUserEmailAsync(string Email);

    Task<AppUser?> FindByNickOrEmailAsync(string userName, string email);

    Task<AppUser?> CreateAsync(AppUser user);
    Task<AppUser?> CreateAsync(string NickName, string Name, string SurName,string Email,string Password,string Phone,string City);

    Task<bool>UpdateAsync(AppUser user);

    Task<bool> SetUserNameAsync(AppUser user, string userName);

    Task<bool> SetUserEmailAsync(AppUser user, string email);

    Task<bool> SetUserPasswordAsync(AppUser user, string password);

}
