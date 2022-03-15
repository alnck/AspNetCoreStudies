using BP.Api.Extensions;
using BP.Api.Models;
using BP.Api.Service;
using BP.Api.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
  .AddFluentValidation(i => i.RunDefaultMvcValidationAfterFluentValidationExecutes = false);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.ConfigureMapping();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddTransient<IValidator<ContactDVO>, ContactValidator>();
builder.Services.AddHttpClient("googleapi", config =>
{
  config.BaseAddress = new Uri("http://www.google.com");
  config.DefaultRequestHeaders.Add("Authorization", "deneme 1234");
});

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

builder.Configuration
  .SetBasePath(System.IO.Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json")
  .AddJsonFile($"appsettings.{env}.json")
  .AddEnvironmentVariables();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCostumHealthCheck();
app.UseResponseCaching();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
