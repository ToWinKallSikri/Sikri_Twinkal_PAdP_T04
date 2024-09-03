using Traccia_04_Sikri_Twinkal.Web.Extensions;
using Traccia_04_Sikri_Twinkal.App.Extensions;
using Traccia_04_Sikri_Twinkal.Models.Extensions;
using Traccia_04_Sikri_Twinkal.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Traccia_04_Sikri_Twinkal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.
                AddWebServices(builder.Configuration).
                AddApplicationServices(builder.Configuration).
                AddModelServices(builder.Configuration);


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.AddWebMiddleware()
               .AddApplicationMiddleware();

            using (var scope = app.Services.CreateScope())
            {
                var db = (ServizioDiPrenotazioneContext)scope.ServiceProvider.GetService(typeof(ServizioDiPrenotazioneContext));
                db.Database.Migrate();
            }

            app.Run();

        }
    }
}
