using System.Net;
using System.Net.Mail;
using Domain.Entities;
using Infrastructure;

namespace App.Services;

public class UserService(UnitOfWork uow)
{
    private UnitOfWork _uow = uow;
    

    public async Task UpdateUserByUsername(string username, User newUser)
    {
        newUser.UserId = (await GetUserByUsername(username)).UserId;
        await _uow.UserRepository.UpdateEntityFromExpressionAsync(newUser,x=>x.Username == username);
        await _uow.SaveChangesAsync();
    }

    public async Task CreateNewUser(User user)
    {
        await _uow.UserRepository.AddNewEntityAsync(user);
        await _uow.SaveChangesAsync();
    }

    public async Task<User> GetUserByUsername(string username)
    {
        return await _uow.UserRepository.GetEntityFirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _uow.UserRepository.GetEntityFirstOrDefaultAsync(x => x.Email == email);
    }
    
     
}