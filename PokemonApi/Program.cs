using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using PokemonApi.Infrastructure;
using PokemonApi.Services;
using SoapCore;
using PokemonApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();


builder.Services.AddScoped<IPokemonService, PokemonService>();

builder.Services.AddSingleton<IPokemonService, PokemonService>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();


builder.Services.AddDbContext<RelationalDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect( builder.Configuration.GetConnectionString("DefaultConnection"))));

var app = builder.Build();

app.UseSoapEndpoint<IPokemonService>("/PokemonService.svc", new SoapEncoderOptions());

app.Urls.Add("http://0.0.0.0:8090");
app.Run();