using System.Data.Common;
using App.Services;
using Domain.Entities;
using Domain.Enums;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(MyDbContext db, UserService userService, AuthService authService) : ControllerBase
    {
        private MyDbContext _db = db;

        [HttpPut("UpdateEntity")]
        public async Task<IActionResult> UpdateEntityByUsername(string userUsername,[FromBody] User user)
        {
            await userService.UpdateUserByUsername(userUsername, user);
            return Ok();
        }
        //ограничь доступ
        [HttpPost("CreateNewUser")]
        public async Task<IActionResult> AddEntity(User user)
        {
            await userService.CreateNewUser(user);
            return Ok();
        }
        
        [HttpPost("CheckCode")]
        public async Task<IActionResult> CheckCode(Code code)
        {
            var result = await authService.ConfirmCode(code);
            if(result) return Ok("Success");
            return BadRequest("Bad code");
        }
        
        [HttpPost("SendCodeToEmail")]
        public async Task<IActionResult> SendCodeToEmail(string email)
        {
            await authService.SendConfirmCodeForYourEmail(email);
            return Ok();
        }
        [HttpPost("SendCodeToPhone")]
        public async Task<IActionResult> SendCodeToPhone(string phone)
        {
            await authService.SendConfirmCodeForYourPhone(phone);
            return Ok();
        }

        [HttpPost("OAuth")]
        public async Task OAuthProcedure()
        {
            await authService.OAuth();
        }

        [HttpPost("SetCookies")]
        public async Task SetCookies()
        {
            
        }
        [Authorize]
        [HttpPost("Test")]
        public async Task<IActionResult> Test()
        {
            return Ok("Success");
        }
    }
}
