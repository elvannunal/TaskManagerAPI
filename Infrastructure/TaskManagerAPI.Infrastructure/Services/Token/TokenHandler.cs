using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TaskManagerAPI.Application.Abstractions.Token;

namespace TaskManagerAPI.Infrastructure.Services.Token;

public class TokenHandler : ITokenHandler

{
    private readonly IConfiguration _configuration;

    public TokenHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Application.Dto.Token CreateAccessToken(int date)
    {
        Application.Dto.Token token = new();
        
        //Securşty key in simetriğini alıyoruzz 
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
        
        //şifrelenmiş kimliği oluşturuyoruz

        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512);
        
        //oluşturulacak token ayarlarını veriyoruz.
        
        token.Expration= DateTime.UtcNow.AddDays(date);

        JwtSecurityToken securityToken = new(
            audience: _configuration["Token:Audience"],
            issuer: _configuration["Token:Issuer"],
            expires: token.Expration,
            notBefore: DateTime.Now,
            signingCredentials: signingCredentials
        );
        
        //Token oluşturucu sınıfından bir örnek alalım
        JwtSecurityTokenHandler tokenHandler = new();
        token.AccessToken = tokenHandler.WriteToken(securityToken);
        return token;

    }
} 