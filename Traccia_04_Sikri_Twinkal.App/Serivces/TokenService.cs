using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Traccia_04_Sikri_Twinkal.App.Options;
using Traccia_04_Sikri_Twinkal.App.Abstractions.Services;
using Traccia_04_Sikri_Twinkal.App.Models.Requests;

namespace Traccia_04_Sikri_Twinkal.App.Serivces
{
    public class TokenService : ITokenService
    {
        private readonly JwtAuthenticationOption _jwtAuthOption;
        public TokenService(IOptions<JwtAuthenticationOption> jwtAuthOption)
        {
            _jwtAuthOption = jwtAuthOption.Value;
        }
        public string CreateToken(CreateTokenRequest request)
        { 
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Nome", "Twinkal"));
            claims.Add(new Claim("Cognome", "Sikri"));

            var securityKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes(_jwtAuthOption.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(_jwtAuthOption.Issuer
                , null
                , claims
                , expires: DateTime.Now.AddMinutes(30)
                , signingCredentials: credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
