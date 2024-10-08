﻿using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Traccia_04_Sikri_Twinkal.App.Factories;

namespace Traccia_04_Sikri_Twinkal.Web.Extensions
{
    public static class MiddlewareExtensions
    {
        public static WebApplication? AddWebMiddleware(this WebApplication? app)
        {
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.Use(async (HttpContext context, Func<Task> next) =>
            {
                //await context.Response.WriteAsync("Prova");
                await next.Invoke();
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var res = ResponseFactory
                            .WithError(contextFeature.Error);
                        await context.Response.WriteAsJsonAsync(
                            res
                            );
                    }
                });
            });

            app.MapControllers();
            return app;
        }
    }
}
