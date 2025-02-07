using System.Text.Json.Serialization;
using Fiap.Hackathon.AppointmentScheduler.Api;
using Fiap.Hackathon.AppointmentScheduler.Api.Configurations;
using Fiap.Hackathon.AppointmentScheduler.Api.Middlewares;
using Fiap.Hackathon.AppointmentScheduler.Application.Options;
using Fiap.Hackathon.AppointmentScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureSwagger();

builder.Services.Configure<JwtTokenOptions>(
    builder.Configuration.GetSection("JwtTokenOptions"));

builder.Services.AddHealthChecks()
    .AddNpgSql(Environment.GetEnvironmentVariable("CONNECTION_STRING_DB_POSTGRES") ??
               throw new Exception("CONNECTION_STRING_DB_POSTGRES not found."));

builder.Services.AddDbContext<AppointmentSchedulerDbContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING_DB_POSTGRES")));

builder.Services.Configure<JwtTokenOptions>(builder.Configuration.GetSection("JwtTokenOptions"));

builder.ConfigureAuth();

builder.Services.RegisterRepositories();
builder.Services.RegisterApplicationServices();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseHealthcheck();
app.UseMiddleware<ExceptionMiddleware>();
app.Run();