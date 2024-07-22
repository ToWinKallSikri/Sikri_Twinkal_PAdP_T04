using Traccia_04_Sikri_Twinkal.App.Abstractions.Services;
namespace Traccia_04_Sikri_Twinkal.App.Middlewares
{
    public class MiddlewareUtente
    {
        private RequestDelegate _next;
        public MiddlewareUtente(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IUtenteService aziendaService, IConfiguration configuration)
        {
            context.RequestServices.GetRequiredService<IUtenteService>();
            await _next.Invoke(context);
        }
    }
}
