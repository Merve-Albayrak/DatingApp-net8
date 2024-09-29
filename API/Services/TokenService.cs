
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;


namespace API;

public class TokenService(IConfiguration config) : ITokenService
{
    public async Task<string> CreateToken(AppUser user)
    {

        var tokenKey=config["TokenKey"]?? throw new Exception("cannot acces tokenkey from appsettings");
       
       if(tokenKey.Length<64) throw new Exception("your token nedds to be longer");

       var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

       var claims= new List<Claim>

       {

        new (ClaimTypes.NameIdentifier,user.UserName)

       };

var creds= new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
       var tokenDescriptor= new SecurityTokenDescriptor
       {

        Subject=new ClaimsIdentity(claims),
        Expires=DateTime.UtcNow.AddDays(7),
        SigningCredentials= creds

       };
       var tokenHandler=new JwtSecurityTokenHandler();

       var token=tokenHandler.CreateToken(tokenDescriptor);

       return tokenHandler.WriteToken(token);
    }
}
