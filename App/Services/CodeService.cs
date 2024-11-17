using Domain.Entities;
using Infrastructure;

namespace App.Services;

public class CodeService(UnitOfWork uow)
{
    private readonly UnitOfWork _uow = uow;
    
    public async Task<bool> CheckCode(string code, string userIdentifier)
    {
        var res = await _uow.CodeRepository.GetEntityFirstOrDefaultAsync(x =>
            x.SentCode == code && userIdentifier == x.UserPhoneOrEmail);
        return res != null;
    }
    public async Task<string> CreateCode()
    {
        var code = "";
        await Task.Run(async () =>
        {
            var rnd = new Random();
            code = rnd.Next(100000, 999999).ToString();
            
        });
        return code;
    }

    public async Task AddCodeToDb(Code codeEntity)
    {
        await _uow.CodeRepository.AddNewEntityAsync(codeEntity);
        await _uow.SaveChangesAsync();
    }
}