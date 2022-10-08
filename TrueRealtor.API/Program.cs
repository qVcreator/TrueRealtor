using TrueRealtor.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.SetupServices();

var app = builder.Build();

app.SetupApp();
