using Microsoft.AspNetCore.Mvc;
using Traccia_04_Sikri_Twinkal.App.Abstractions.Services;
using Traccia_04_Sikri_Twinkal.App.Factories;
using Traccia_04_Sikri_Twinkal.App.Models.Dtos;
using Traccia_04_Sikri_Twinkal.App.Models.Requests;
using Traccia_04_Sikri_Twinkal.App.Models.Responses;

namespace Traccia_04_Sikri_Twinkal.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteService _utenteService;


        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }

        [HttpPost]
        [Route("Signin")]
        public IActionResult Create(CreateTokenRequest request)
        {
            bool result = _utenteService.CreateToken(request, out string token);
            if (result)
            {
                return Ok(
                ResponseFactory.WithSuccess(
                    new CreateTokenResponse(token)
                    )
                );
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("CreaUtente")]
        public IActionResult CreateUtente(CreateUtenteRequest request)
        {
            var utente = request.ToEntity();
            _utenteService.AddUtente(utente);

            var response = new CreateUtenteResponse();
            response.Utente = new App.Models.Dtos.UtenteDto(utente);

            return Ok(
                ResponseFactory
                .WithSuccess(response)
                );
        }

    }
}
