using Microsoft.AspNetCore.SpaServices;
using NoHTML.App.Extension;
using NoHTML.FakeJS.ScriptEngine;
using NoHTML.Web.NoHTML;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSharpPage<NoHTML.Web.NoHTML.Index>();
builder.Services.AddFakeJS<JSParser, JSRuntimeManager>();

builder.Services.AddSingleton<AppRoot>();

var app = builder.Build();

app.UseNoHTML<NoHTML.Web.NoHTML.Index>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
