using Traccia_04_Sikri_Twinkal.App.Middlewares;

namespace Traccia_04_Sikri_Twinkal.App.Extensions
{
    public static class MiddlewareExtension
    {
        public static WebApplication? AddApplicationMiddleware(this WebApplication? app)
        {
            app.UseMiddleware<MiddlewarePrenotazione>();
            app.UseMiddleware<MiddlewareRisorsa>();
            app.UseMiddleware<MiddlewareUtente>();
            return app;
        }
    }
}
