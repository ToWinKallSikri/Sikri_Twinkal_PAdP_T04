using Traccia_04_Sikri_Twinkal.App.Abstractions.Services;

namespace Traccia_04_Sikri_Twinkal.App.Middlewares
{
    public class MiddlewarePrenotazione
    {
        private RequestDelegate _next;
        public MiddlewarePrenotazione(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IPrenotazioneService aziendaService, IConfiguration configuration)
        {
            context.RequestServices.GetRequiredService<IPrenotazioneService>();
            await _next.Invoke(context);
        }
    }
}
