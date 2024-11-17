using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using Domain.Entities;
using Domain.Enums;
using Google.Apis.Auth.AspNetCore3;
using Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace App.Services;

public class AuthService(UnitOfWork uow,IHttpContextAccessor accessor)
{
    private const string RedirectUri = "";
    private readonly CodeService _codeService = new CodeService(uow);
    private const string FromEmail = "";
    private const  string Password = ""; 
    private const  string SmtpServer = "";
    private IHttpContextAccessor _accessor = accessor;
    
    //Sends message for your email
    public async Task SendConfirmCodeForYourEmail(string userEmail)
    {
        var code = await _codeService.CreateCode();
        
        var mail = new MailMessage(FromEmail, userEmail);
        mail.Subject = "Authentication Code";
        mail.Body = code.ToString();

        var client = new SmtpClient(SmtpServer, 587)
        {
            Credentials = new NetworkCredential(FromEmail, Password),
            EnableSsl = true
        };
        
        await client.SendMailAsync(mail);
        Console.WriteLine("Mail sent successfully.");
        
        await _codeService.AddCodeToDb(new Code()
        {
            SentCode = code,
            UserPhoneOrEmail = userEmail
        });
    }

    
    public async Task SendConfirmCodeForYourPhone(string phoneNumber)
    {
        //Sends message for your phone
        var code = await _codeService.CreateCode();
        
        await _codeService.AddCodeToDb(new Code()
        {
            SentCode = code,
            UserPhoneOrEmail = phoneNumber
        }); 
        
    }

    public async Task<bool> ConfirmCode(Code code)
    {
        return await _codeService.CheckCode(code.SentCode,code.UserPhoneOrEmail);
    }
    
    
    public async Task OAuth()
    {
        await _accessor.HttpContext.ChallengeAsync(GoogleOpenIdConnectDefaults.AuthenticationScheme,new AuthenticationProperties()
        {
            RedirectUri = "https://www.google.ru/?hl=ru"
        });
    }
}