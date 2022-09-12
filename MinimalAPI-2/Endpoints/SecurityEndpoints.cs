using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MinimalAPI_2.Data;
using MinimalAPI_2.DTOs;
using MinimalAPI_2.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MinimalAPI_2.Endpoints
{
    public static class SecurityEndpoints
    {
        public static void MapSecurityEndpoints(this WebApplication app)
        {
            app.MapPost("/api/security/getToken",
 (User user) =>
{

    if (user.UserName == "testuser" && user.Password == "testpassword")
    {
        var issuer = app.Configuration["Jwt:Issuer"];
        var audience = app.Configuration["Jwt:Audience"];
        var securityKey = new SymmetricSecurityKey
    (Encoding.UTF8.GetBytes(app.Configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey,
SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(issuer: issuer,
            audience: audience,
            signingCredentials: credentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);

        return Results.Ok(stringToken);
    }
    else
    {
        return Results.Unauthorized();
    }
});


         
        }
    }
}
