using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ITsena_back.Services;

public class JwtService
{
    private string secureKey = "JWT Security";
    //GENERATE TOKEN
    public string Generator(int uid)
    {
        // Security data
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
        var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        var jwtHeader = new JwtHeader(credentials);

        var jwtPayload = new JwtPayload(uid.ToString(), null, null, null, DateTime.Now.AddDays(7));
        var securityToken = new JwtSecurityToken(jwtHeader, jwtPayload);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    //CHECK TOKEN VALIDATION
    public JwtSecurityToken Checker(string jwt)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secureKey);
        tokenHandler.ValidateToken(
            jwt,
            new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
            },
            out SecurityToken validateToken
        );
        return (JwtSecurityToken)validateToken;
    }
}