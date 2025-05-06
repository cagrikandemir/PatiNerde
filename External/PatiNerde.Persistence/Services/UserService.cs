using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PatiNerde.Application.Abtractions.IEntities.IMain;
using PatiNerde.Application.Abtractions.IServices;
using PatiNerde.Domain.Entities.Main;

namespace PatiNerde.Persistence.Services;

public class UserService : IUserService
{
    private readonly IAppUserRead _tableRead;
    private readonly IAppUserWrite _tableWrite;
    public UserService(IAppUserRead tableRead, IAppUserWrite tableWrite)
    {
        _tableRead = tableRead;
        _tableWrite = tableWrite;
    }
    public async Task<AppUser?> CreateAsync(AppUser user)
    {
        await _tableWrite.AddAsync(user);
        await _tableWrite.SaveAsync();
        return user;
    }
    public async Task<AppUser?>CreateAsync(string NickName, string Name, string SurName, string Email, string Password, string Phone, string City)
    {
        AppUser user = new()
        {
            NickName = NickName,
            Name = Name,
            SurName = SurName,
            Email = Email,
            Password = Password,
            Phone = Phone,
            City = City
        };
        return await CreateAsync(user);
    }

    public async Task<AppUser?> FindByNickNameAsync(string NickName)
    {
        return await _tableRead.Table.Where(x=>x.NickName == NickName).FirstOrDefaultAsync();
    }

    public async Task<AppUser?> FindByUserEmailAsync(string Email)
    {
        return await _tableRead.Table.Where(x=>x.Email == Email).FirstOrDefaultAsync();
    }

    public async Task<AppUser?> FindByNickOrEmailAsync(string userName, string email)
    {
        return await _tableRead.Table.Where(x=>x.NickName==userName ||x.Email == email)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> SetUserEmailAsync(AppUser user, string email)
    {
        try
        {
            user.Email = email;
            await _tableWrite.SaveAsync();
        }
        catch (Exception )
        {
            return false;
        }
        return true;
    }

    public async Task<bool> SetUserNameAsync(AppUser user, string userName)
    {
        try
        {
            user.NickName = userName;
          await _tableWrite.SaveAsync();
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> SetUserPasswordAsync(AppUser user, string password)
    {
        try
        {
            user.Password = password;
            await _tableWrite.SaveAsync();
        }
        catch (Exception)
        {

            return false;
        }
        return true;
    }

    public async Task<bool> UpdateAsync(AppUser user)
    {
        EntityEntry entity = _tableWrite.Table.Update(user);
        return entity.State==await Task.FromResult(EntityState.Modified);
    }
}
