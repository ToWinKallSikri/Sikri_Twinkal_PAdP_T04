using Microsoft.AspNetCore.Mvc;
using Traccia_04_Sikri_Twinkal.App.Abstractions.Services;
using Traccia_04_Sikri_Twinkal.App.Factories;
using Traccia_04_Sikri_Twinkal.App.Models.Requests;
using Traccia_04_Sikri_Twinkal.App.Models.Responses;

namespace Traccia_04_Sikri_Twinkal.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TokenController : Controller
    {

        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Creazione di un token")]
        public IActionResult Create(CreateTokenRequest request)
        {
            string token = _tokenService.CreateToken(request);
            return Ok(
                ResponseFactory.WithSuccess(
                    new CreateTokenResponse(token)
                    )
                );

        }
    }
}
