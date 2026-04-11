using Microsoft.EntityFrameworkCore;
using SmartMonitoring.Api.Data;
using SmartMonitoring.Api.Endpoints;
using SmartMonitoring.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AnomalyDetectionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Smart Monitoring API is running");
app.MapSensorEndpoints();
app.MapAlertEndpoints();

app.Run();