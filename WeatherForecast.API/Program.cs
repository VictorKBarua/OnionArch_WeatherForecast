using Microsoft.EntityFrameworkCore;
using WeatherForecast.Dal;
using WeatherForecast.Dal.Repositories;
using WeatherForecast.UtilitiesService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherDbConnection"), providerOptions => providerOptions.EnableRetryOnFailure()));

builder.Services.AddScoped(typeof(IForecastRepositories<>), typeof(ForecastRepositories<>));
builder.Services.AddTransient<IForecastServices, ForecastServices>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
