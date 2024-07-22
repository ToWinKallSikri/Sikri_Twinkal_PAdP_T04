using FluentValidation;
using Traccia_04_Sikri_Twinkal.App.Extensions;
using Traccia_04_Sikri_Twinkal.App.Models.Requests;

namespace Traccia_04_Sikri_Twinkal.App.Validators
{
    public class CreateUtenteRequestValidator : AbstractValidator<CreateUtenteRequest>
    {
        public CreateUtenteRequestValidator() 
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Il campo Nome è obbligatorio (vuoto)")
                .NotNull()
                .WithMessage("Il campo Nome è obbligatorio (nullo)")
                .MinimumLength(3)
                .WithMessage("Il campo Nome deve essere lungo almeno 3 caratteri");

            RuleFor(x => x.Cognome)
                .NotEmpty()
                .WithMessage("Il campo Cognome è obbligatorio (vuoto)")
                .NotNull()
                .WithMessage("Il campo Cognome è obbligatorio (nullo)")
                .MinimumLength(3)
                .WithMessage("Il campo Cognome deve essere lungo almeno 3 caratteri");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Il campo Email è obbligatorio (vuoto)")
                .NotNull()
                .WithMessage("Il campo Email è obbligatorio (nullo)")
                .EmailAddress()
                .WithMessage("Il campo Email non è un indirizzo email valido");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Il campo Password è obbligatorio (vuoto)")
                .NotNull()
                .WithMessage("Il campo Password è obbligatorio (nullo)")
                .MinimumLength(6)
                .WithMessage("Il campo password deve essere almeno lungo 6 caratteri")
                .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$"
                , "Il campo password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale"
                );
        }

    }
}
