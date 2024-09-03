using FluentValidation;
using Traccia_04_Sikri_Twinkal.App.Models.Requests;
using Traccia_04_Sikri_Twinkal.Models.Context;

namespace Traccia_04_Sikri_Twinkal.App.Validators
{
    public class GetDisponibilitaRequestValidator : AbstractValidator<GetDisponibilitaRequest>

    {
        public GetDisponibilitaRequestValidator(ServizioDiPrenotazioneContext dbContext)
        {
            RuleFor(x => x.DataInizio)
                .NotNull().WithMessage("Data Inizio prenotazione obbligatoria")
                .Must(date => DataAccettabile(date)).WithMessage("Data non valida");

            RuleFor(x => x.DataFine)
                .NotNull().WithMessage("Data Fine prenotazione obbligatoria")
                .Must(date => DataAccettabile(date)).WithMessage("Data non valida")
                .GreaterThanOrEqualTo(x => x.DataInizio).WithMessage("La data di fine prenotazione deve essere dopo " +
                                                                                 "o corrispondere alla data d'inizio");

            When(x => x.RisorsaId.HasValue, () =>
            {
                RuleFor(x => x.RisorsaId)
                    .Must(tmp => dbContext.Risorse.Any(x => x.RisorsaId == tmp))
                    .WithMessage("La risorsa non esiste.");

                RuleFor(x => x)
                    .Must(req => RisorsaDisponibile(req, dbContext))
                    .WithMessage("La risorsa non è disponibile per le date selezionate.");
            });


        }

        public bool DataAccettabile(DateOnly? data)
        {
            return data != null;
        }

        public bool RisorsaDisponibile(GetDisponibilitaRequest req, ServizioDiPrenotazioneContext dbContext)
        {
            if (req.RisorsaId != null)
            {
                return true;
            }
            return !dbContext.Prenotazioni.Any(x => x.RisorsaId == req.RisorsaId
                                                 && x.DataInizio >= req.DataInizio
                                                 && x.DataFine <= req.DataFine);
        }
    }
}
