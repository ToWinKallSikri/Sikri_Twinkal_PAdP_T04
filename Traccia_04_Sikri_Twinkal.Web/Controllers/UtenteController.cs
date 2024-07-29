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

        [HttpGet]
        [Route("Ricerca Utente tramite ID/{id:int}")]
        public IActionResult GetUtenteById(int id)
        {
            var utente = _utenteService.GetUtenteById(id);

            if (utente == null)
            {
                return NotFound(new { Message = "Utente non trovato." });
            }

            var utenteDto = new UtenteDto(utente);
            return Ok(ResponseFactory.WithSuccess(utenteDto));
        }

        [HttpPost]
        [Route("Lista Utenti")]
        public IActionResult GetUtenti(GetUtenteRequest request)
        {
            if (request.PageSize <= 0)
            {
                return BadRequest("Il campo Page Size non può essere 0");
            }

            int totalNum = 0;
            var utenti = _utenteService.GetUtenti(request.PageNumber * request.PageSize, request.PageSize, request.Name, out totalNum);
            if (!utenti.Any())
            {
                return Ok(new { Message = "Nessun utente trovato" });
            }

            var response = new GetUtenteResponse();
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.PageNumber = (int)Math.Ceiling(pageFounded);
            response.Utenti = utenti.Select(s =>
            new App.Models.Dtos.UtenteDto(s)).ToList();

            return Ok(ResponseFactory
                .WithSuccess(response)
                );

        }

        [HttpPost]
        [Route("Creazione senza validazione")]
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
