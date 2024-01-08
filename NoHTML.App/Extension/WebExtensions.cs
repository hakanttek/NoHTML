using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NoHTML.App.Core;
using NoHTML.FakeJS.ScriptEngine;
using NoHTML.SharpPage.Tags.DocStruct;

namespace NoHTML.App.Extension
{
    public static class WebExtensions
    {
        public static IServiceCollection AddSharpPage<T>(this IServiceCollection services) where T : Html
        {
            services.AddSingleton<ISerializer, XmlSerializer>();
            services.AddSingleton<T>();
            services.AddSingleton<ClientApp<T>>();
            return services;
        }
        public static IServiceCollection AddFakeJS<T, I>(this IServiceCollection services) where T : JSParser where I : JSRuntimeManager
        {
            services.AddSingleton<IJSParser, T>();
            services.AddSingleton<IJSRuntimeManager, I>();
            return services;
        }
        public static IApplicationBuilder UseNoHTML<T>(this IApplicationBuilder app, PathString pathMatch) where T : Html
        {
            app.Map(pathMatch, appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    var app = context.RequestServices.GetService<ClientApp<T>>()
                    ?? throw new InvalidOperationException($"Service of type '{typeof(T).Name}' is not registered in the service container.");

                    context.Response.ContentType = app.ContentType;

                    await context.Response.WriteAsync(app.ToPlainText());
                });
            });
            return app;
        }
        public static IApplicationBuilder UseNoHTML<T>(this IApplicationBuilder app) where T : Html
        {
            app.UseNoHTML<T>(string.Empty);
            return app;
        }
    }
}
