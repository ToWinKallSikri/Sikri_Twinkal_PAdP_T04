using Azure;
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

        [HttpPost]
        [Route("NuovaTipologia")]
        public IActionResult CreaTipologia(string nomeTipologia)
        {
            if (_risorsaService.CreaTipologia(nomeTipologia, out int id)) 
            {
                return Ok(ResponseFactory.WithSuccess(id));
            }
            else
            {
                return BadRequest("Nome tipologia vuoto o già presente");
            }
        }


        [HttpPost]
        [Route("Crea")]
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
        [Route("CercaDisponibilita")]
        public IActionResult GetDisponibilita(GetDisponibilitaRequest request)
        {
            if (request.PageSize <= 0)
            {
                return BadRequest("Il campo Page Size non può essere 0");
            }

            var disponibilita = _risorsaService.GetDisponibilita(
                request.PageNumber * request.PageSize,
                request.PageSize,
                request.DataInizio,
                request.DataFine,
                request.RisorsaId,
                out int totalItems);

            var totalPages = (int)Math.Ceiling((double)totalItems / request.PageSize);


            var response = new
            {
                Risorse = disponibilita,
                PagineTotali = totalPages,
                PaginaCorrente = request.PageNumber,
                TotaleRisorse = totalItems
            };

            return Ok(ResponseFactory.WithSuccess(response));
        }
    }
}
