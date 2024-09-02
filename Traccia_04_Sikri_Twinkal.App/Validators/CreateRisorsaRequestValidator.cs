using FluentValidation;
using Traccia_04_Sikri_Twinkal.App.Models.Requests;
using Traccia_04_Sikri_Twinkal.Models.Context;
namespace Traccia_04_Sikri_Twinkal.App.Validators
{
    public class CreateRisorsaRequestValidator : AbstractValidator<CreateRisorsaRequest>
    {
        private readonly ServizioDiPrenotazioneContext _dbContext;
        public CreateRisorsaRequestValidator(ServizioDiPrenotazioneContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Nome obbligatorio")
                .MinimumLength(3).WithMessage("Nome troppo corto")
                .MaximumLength(50).WithMessage("Nome troppo lungo");

            RuleFor(x => x.Tipologia)
                .InclusiveBetween(1, 5).WithMessage("IdRisorsaTipologia deve essere tra 1 e 5.");

            RuleFor(x => x.IdRisorsa)
               .NotNull().WithMessage("Id Risorsa obbligatorio")
               .GreaterThan(0).WithMessage("Id Risorsa deve essere maggiore di 0");

            RuleFor(x => x)
                .Must(x => !RisorsaEsistente(x))
                .WithMessage("Risorsa già esistente");

        }

        private bool RisorsaEsistente(CreateRisorsaRequest req)
        {
            return _dbContext.Risorse.Any(x => x.RisorsaId == req.IdRisorsa);
        }
    }
}
