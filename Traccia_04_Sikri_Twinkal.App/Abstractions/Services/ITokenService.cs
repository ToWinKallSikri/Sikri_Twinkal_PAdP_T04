using Traccia_04_Sikri_Twinkal.App.Models.Requests;

namespace Traccia_04_Sikri_Twinkal.App.Abstractions.Services
{
    public interface ITokenService
    {
        string CreateToken(CreateTokenRequest tokenRequest);
    }
}
