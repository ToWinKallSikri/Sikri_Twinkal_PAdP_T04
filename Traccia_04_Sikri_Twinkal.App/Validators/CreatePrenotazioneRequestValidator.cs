using FluentValidation;
using Traccia_04_Sikri_Twinkal.App.Models.Requests;
using Traccia_04_Sikri_Twinkal.Models.Context;

namespace Traccia_04_Sikri_Twinkal.App.Validators
{
    public class CreatePrenotazioneRequestValidator : AbstractValidator<CreatePrenotazioneRequest>
    {
        public CreatePrenotazioneRequestValidator(ServizioDiPrenotazioneContext myDbContext)
        {
            RuleFor(x => x.DataInizio)
                .NotNull().WithMessage("Data Inizio prenotazione obbligatoria")
                .Must(date => DataAccettabile(date)).WithMessage("Data non valida");

            RuleFor(x => x.DataFine)
                .NotNull().WithMessage("Data Fine prenotazione obbligatoria")
                .Must(date => DataAccettabile(date)).WithMessage("Data non valida")
                .GreaterThanOrEqualTo(x => x.DataInizio).WithMessage("La data di fine prenotazione deve essere dopo " +
                                                                                 "o corrispondere alla data d'inizio");

            RuleFor(x => x)
            .Must(req =>
                !myDbContext.Prenotazioni.Any(x => x.RisorsaId == req.RisorsaId
                                               && x.DataFine > req.DataInizio
                                               && x.DataInizio < req.DataFine)
                )
                .WithMessage("La risorsa non è disponibile per le date selezionate.");

        }

        private bool DataAccettabile(DateOnly? date)
        {
            return date != null && date >= DateOnly.FromDateTime(DateTime.Now);
        }
    }

}

