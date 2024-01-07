using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NoHTML.App.Core;
using NoHTML.SharpPage.Tags.DocStruct;

namespace NoHTML.App.Extension
{
    public static class WebExtensions
    {
        public static IServiceCollection AddSharpPage<T>(this IServiceCollection services) where T : Html
        {
            services.AddSingleton<ISerializer, XmlSerializer>();
            services.AddSingleton<T>();
            return services;
        }
        public static IApplicationBuilder UseSharpPage<T>(this IApplicationBuilder app, PathString pathMatch) where T : Html
        {
            app.Map(pathMatch, appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    ISerializer? serializer = context.RequestServices.GetService<ISerializer>();
                    T mainElement = context.RequestServices.GetService<T>()??
                    throw new InvalidOperationException($"Service of type '{typeof(T).Name}' is not registered in the service container.");

                    await context.Response.WriteAsync(serializer?.Serialize(mainElement)?? "No serializer");
                });
            });
            return app;
        }
        public static IApplicationBuilder UseSharpPage<T>(this IApplicationBuilder app) where T : Html
        {
            app.UseSharpPage<T>("");
            return app;
        }
    }
}
