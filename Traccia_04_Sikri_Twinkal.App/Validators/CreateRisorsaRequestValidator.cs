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
        }
    }
}
