using DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AddTransient sürekli oluþturuyor.
builder.Services.AddTransient<INumGenerator, NumGenerator>(); 
builder.Services.AddScoped<INumGenerator2, NumGenerator2>();

//// AddScoped 1 request de 1 defa oluþturulur.
//builder.Services.AddScoped<INumGenerator, NumGenerator>();
//builder.Services.AddScoped<INumGenerator2, NumGenerator2>();

//builder.Services.AddSingleton<INumGenerator, NumGenerator>();
//builder.Services.AddSingleton<INumGenerator2, NumGenerator2>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
