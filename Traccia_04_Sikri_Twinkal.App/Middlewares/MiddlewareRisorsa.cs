using Traccia_04_Sikri_Twinkal.App.Abstractions.Services;
namespace Traccia_04_Sikri_Twinkal.App.Middlewares
{
    public class MiddlewareRisorsa
    {
        private RequestDelegate _next;
        public MiddlewareRisorsa(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IRisorsaService aziendaService, IConfiguration configuration)
        {
            context.RequestServices.GetRequiredService<IRisorsaService>();
            await _next.Invoke(context);
        }
    }
}
