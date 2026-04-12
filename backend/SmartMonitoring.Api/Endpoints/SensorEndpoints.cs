using SmartMonitoring.Api.Contracts;
using SmartMonitoring.Api.Data;
using SmartMonitoring.Api.Models;
using SmartMonitoring.Api.Services;

namespace SmartMonitoring.Api.Endpoints;

public static class SensorEndpoints
{
    public static void MapSensorEndpoints(this WebApplication app)
    {
        app.MapPost("/api/sensors", async (
            CreateSensorDataRequest request,
            AppDbContext db,
            AnomalyDetectionService anomalyService) =>
        {
            var sensorData = new SensorData
            {
                MachineId = request.MachineId,
                Temperature = request.Temperature,
                Pressure = request.Pressure,
                Timestamp = request.Timestamp.UtcDateTime
            };

            db.SensorData.Add(sensorData);

            var alert = anomalyService.Detect(sensorData);
            if (alert != null)
            {
                db.Alerts.Add(alert);
            }

            await db.SaveChangesAsync();

            return Results.Ok(new
            {
                message = "Sensor data stored successfully",
                alertTriggered = alert != null
            });
        });

        app.MapGet("/api/sensors", (AppDbContext db) =>
        {
            var data = db.SensorData
                .OrderByDescending(x => x.Timestamp)
                .Take(100)
                .ToList();

            return Results.Ok(data);
        });
    }
}