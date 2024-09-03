using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traccia_04_Sikri_Twinkal.App.Abstractions.Services;
using Traccia_04_Sikri_Twinkal.App.Factories;
using Traccia_04_Sikri_Twinkal.App.Models.Requests;
using Traccia_04_Sikri_Twinkal.App.Models.Responses;

namespace Traccia_04_Sikri_Twinkal.Web.Controllers
{
    [ApiController]
    [Route("api/v1/Prenota")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PrenotazioneController : ControllerBase
    {
        private readonly IPrenotazioneService _prenotazioneService;
        private readonly IRisorsaService _risorsaService;
        public PrenotazioneController(IPrenotazioneService prenotazioneService, IRisorsaService risorsaService)
        {
            _prenotazioneService = prenotazioneService;
            _risorsaService = risorsaService;
        }

        

        [HttpPost]
        public IActionResult CreatePrenotazione(CreatePrenotazioneRequest request)
        {
            var prenotazione = request.ToEntity(int.Parse(User.Claims.First(c => c.Type == "Id").Value));
            _prenotazioneService.AddPrenotazione(prenotazione);

            var response = new CreatePrenotazioneResponse();
            response.Prenotazione = new App.Models.Dtos.PrenotazioneDto(prenotazione);

            return Ok(ResponseFactory
                .WithSuccess(response)
                );
        }
    }
}
