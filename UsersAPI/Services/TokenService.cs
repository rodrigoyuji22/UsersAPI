using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using UsersAPI.Models;

namespace UsersAPI.Services;

public class TokenService
{
    public string GenerateToken(Usuario usuario)
    {
        var claims = new Claim[]
        {
            new Claim("Username", usuario.UserName),
            new Claim("Id", usuario.Id)
        };
        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("s8u943iwjkmghjlkpfghmlp2"));
        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(expires: DateTime.Now.AddMinutes(10), claims: claims, signingCredentials: signingCredentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}