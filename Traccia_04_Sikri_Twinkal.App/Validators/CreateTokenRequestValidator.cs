using FluentValidation;
using Traccia_04_Sikri_Twinkal.App.Models.Requests;
using Traccia_04_Sikri_Twinkal.App.Extensions;

namespace Traccia_04_Sikri_Twinkal.App.Validators
{
    public class CreateTokenRequestValidator : AbstractValidator<CreateTokenRequest>
    {
        public CreateTokenRequestValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("Il campo Email è obbligatorio")
                .NotNull()
                .WithMessage("Il campo Email non può essere nullo")
                .EmailAddress()
                .WithMessage("Il campo Email deve essere un effettivo indirizzo e-mail");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Il campo password è obbligatorio")
                .NotNull()
                .WithMessage("Il campo password non può essere nullo")
                .MinimumLength(6)
                .WithMessage("Il campo password deve essere almeno lungo 6 caratteri")
                .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$"
                , "Il campo password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale"
                );
        }
    }
}
