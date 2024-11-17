using App;
using App.Configs;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace WebApplication1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        //var key = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;
        //var id = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
        //var connectionString = builder.Configuration.GetConnectionString("Def");
        builder.Services.AddSwaggerGen();
        //builder.Services.ConfigureServices(id , key, connectionString);
        builder.Services.AddControllers();
        builder.Services.AddCors(options=> options.AddPolicy("AllowSpecificOrigin",
            builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));
        
        var app = builder.Build();
        app.UseCors("AllowSpecificOrigin"); // CORS middleware should be placed here
        app.UseHttpsRedirection();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}