using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Traccia_04_Sikri_Twinkal.App.Abstractions.Services;
using Traccia_04_Sikri_Twinkal.App.Serivces;
using Traccia_04_Sikri_Twinkal.App.Validators;
using Traccia_04_Sikri_Twinkal.Models.Context;
using Traccia_04_Sikri_Twinkal.Models.Repositories;

namespace Traccia_04_Sikri_Twinkal.App.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(
                AppDomain.CurrentDomain.GetAssemblies().
                FirstOrDefault(assembly => assembly.GetName().Name == "Traccia_04_Sikri_Twinkal.App")
            );

            services.AddValidatorsFromAssemblyContaining<CreateRisorsaRequestValidator>();

            services.AddScoped<IUtenteService, UtenteService>();
            services.AddScoped<IRisorsaService, RisorsaService>();
            services.AddScoped<IPrenotazioneService, PrenotazioneService>();

            return services;
        }

    }

}
