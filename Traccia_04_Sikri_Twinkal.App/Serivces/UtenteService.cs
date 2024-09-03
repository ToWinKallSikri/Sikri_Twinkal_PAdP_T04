using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Traccia_04_Sikri_Twinkal.App.Abstractions.Services;
using Traccia_04_Sikri_Twinkal.App.Models.Requests;
using Traccia_04_Sikri_Twinkal.App.Options;
using Traccia_04_Sikri_Twinkal.Models.Entities;
using Traccia_04_Sikri_Twinkal.Models.Repositories;

namespace Traccia_04_Sikri_Twinkal.App.Serivces
{
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;
        private readonly JwtAuthenticationOption _jwtAuthOption;
        public UtenteService(IOptions<JwtAuthenticationOption> jwtAuthOption,UtenteRepository utenteRepository)
        {
            _utenteRepository = utenteRepository;
            _jwtAuthOption = jwtAuthOption.Value;
        }

        public List<Utente> GetUtenti()
        {
            return new List<Utente>();
            
        }

        public Utente? GetUtenteById(int id)
        {
            return _utenteRepository.Ottieni(id);
        }

        public void AddUtente(Utente utente)
        {
            _utenteRepository.Aggiungi(utente);
            _utenteRepository.Save();
        }

        public List<Utente> GetUtenti(int from, int num, string? name, out int totalNum)
        {
            return _utenteRepository.GetUtenti(from, num, name, out totalNum);
        }
        public bool CreateToken(CreateTokenRequest request, out string token)
        {
            var user = _utenteRepository.DaEmail(request.Email);
            if (user == null || user.Password != request.Password)
            {
                token = string.Empty;
                return false;
            }
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Nome", user.Nome));
            claims.Add(new Claim("Cognome", user.Cognome));
            claims.Add(new Claim("Email", user.Email));
            claims.Add(new Claim("Id", user.UtenteId.ToString()));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAuthOption.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(_jwtAuthOption.Issuer
                , null
                , claims
                , expires: DateTime.Now.AddMinutes(30)
                , signingCredentials: credentials
                );

            token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return true;
        }
    }
}
