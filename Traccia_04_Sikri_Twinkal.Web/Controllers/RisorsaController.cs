using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RisorsaController : ControllerBase
    {
        private readonly IRisorsaService _risorsaService;
        private readonly IValidator<CreateRisorsaRequest> _validator;

        public RisorsaController(IRisorsaService risorsaService, IValidator<CreateRisorsaRequest> validator)
        {
            _risorsaService = risorsaService;
            _validator = validator;
        }


        [HttpGet]
        [Route("Ricera tramite ID/{id:int}")]
        public IActionResult GetRisorsa(int id)
        {
            var risorsa = _risorsaService.GetRisorsa(id);

            if (risorsa == null)
            {
                return NotFound("Risorsa non trovata");
            }
            
            var risorsaDto = new RisorsaDto(risorsa);
            return Ok(risorsaDto);
        }

        [HttpPost]
        [Route("Lista Risorse")]
        public IActionResult GetRisorse([FromQuery] GetRisorsaRequest request)
        {
            if (request.PageSize <= 0)
            {
                return BadRequest("Il campo Page Size non può essere 0");
            }
            int totalNum = 0;
            var risorse = _risorsaService.GetRisorse(request.PageSize, request.PageNumber, request.RisorsaId, out totalNum);
            return Ok(new {risorse, totalNum});


        }

        [HttpPost]
        [Route("Creazione con validazione")]
        public IActionResult CreateRisorsa(CreateRisorsaRequest request)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var risorsa = request.ToEntity();
            _risorsaService.AddRisorsa(risorsa);

            var response = new CreateRisorsaResponse
            {
                Risorsa = new RisorsaDto(risorsa)
            };

            return Ok(ResponseFactory.WithSuccess(response));
        }

        [HttpPost]
        [Route("Ricerca disponibilità con validazione")]
        public IActionResult GetDisponibilita(GetDisponibilitaRequest request)
        {
            if (request.PageSize <= 0)
            {
                return BadRequest("Il campo Page Size non può essere 0");
            }

            int totalItems;
            var disponibilita = _risorsaService.GetDisponibilita(
                (request.PageNumber - 1) * request.PageSize,
                request.PageSize,
                request.DataInizio,
                request.DataFine,
                request.RisorsaId,
                out totalItems);

            var totalPages = (int)Math.Ceiling((double)totalItems / request.PageSize);


            var response = new
            {
                Risorse = disponibilita,
                TotalPages = totalPages,
                TotalItems = totalItems
            };

            return Ok(ResponseFactory.WithSuccess(response));
        }
    }
}
