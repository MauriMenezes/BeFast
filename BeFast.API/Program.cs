using BeFast.API.Configurations;
using BeFast.Application;
using BeFast.Infrastructure;
using BeFast.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

services.AddApiConfiguration();
services.AddApplication();
services.AddInfrastructure(configuration);

var app = builder.Build();

app.AddAppConfiguration();
app.Run();
