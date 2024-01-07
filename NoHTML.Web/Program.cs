using Microsoft.AspNetCore.SpaServices;
using NoHTML.App.Extension;
using NoHTML.Web.NoHTML;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSharpPage<WebPage>();
builder.Services.AddSingleton<WebApp>();

var app = builder.Build();

app.UseSharpPage<WebPage>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
