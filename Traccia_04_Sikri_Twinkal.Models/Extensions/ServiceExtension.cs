using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Traccia_04_Sikri_Twinkal.Models.Context;
using Traccia_04_Sikri_Twinkal.Models.Repositories;

namespace Traccia_04_Sikri_Twinkal.Models.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<ServizioDiPrenotazioneContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });

            services.AddScoped<UtenteRepository>();


            services.AddScoped<RisorsaRepository>();


            services.AddScoped<PrenotazioneRepository>();



            return services;
        }
    }
}