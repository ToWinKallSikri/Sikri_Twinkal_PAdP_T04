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
    [Route("api/v1/[controller]")]
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
        [Route("Lista Prenotazioni")]

        public IActionResult GetPrenotazioni(GetPrenotazioneRequest request)
        {
            if (request.PageSize <= 0)
            {
                return BadRequest("Il campo Page Size non può essere 0");
            }
            int? idRisorsa = null;
            if (!string.IsNullOrWhiteSpace(request.BookedResId))
            {
                if (!int.TryParse(request.BookedResId, out int idParsed))
                {
                    return BadRequest("Id Risorsa non valido");
                }
                idRisorsa = idParsed;
                if (idRisorsa.HasValue && !_risorsaService.risorsaExists(idRisorsa.Value))
                {
                    return NotFound("Id Risorsa non presente");
                }

            }
            int totalNum = 0;
            var prenotazioni = _prenotazioneService.GetPrenotazioni(request.PageNumber * request.PageSize, request.PageSize, request.BookedResId, out totalNum);
            var response = new GetPrenotazioneResponse();
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.PageNumber = (int)Math.Ceiling(pageFounded);
            response.Prenotazioni = prenotazioni.Select(s =>
            new App.Models.Dtos.PrenotazioneDto(s)).ToList();
            if (idRisorsa.HasValue && !response.Prenotazioni.Any())
            {
                return NotFound("Nessuna prenotazione trovata per l'Id Risorsa specificato.");
            }

            return Ok(ResponseFactory
            .WithSuccess(response)
                 );
        }

        [HttpPost]
        [Route("Creazione con validazione")]
        public IActionResult CreatePrenotazione(CreatePrenotazioneRequest request)
        {

            var prenotazione = request.ToEntity();
            _prenotazioneService.AddPrenotazione(prenotazione);

            var response = new CreatePrenotazioneResponse();
            response.Prenotazione = new App.Models.Dtos.PrenotazioneDto(prenotazione);

            return Ok(ResponseFactory
                .WithSuccess(response)
                );
        }
    }
}
