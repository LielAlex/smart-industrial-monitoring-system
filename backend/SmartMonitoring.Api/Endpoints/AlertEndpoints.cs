using SmartMonitoring.Api.Data;

namespace SmartMonitoring.Api.Endpoints;

public static class AlertEndpoints
{
    public static void MapAlertEndpoints(this WebApplication app)
    {
        app.MapGet("/api/alerts", (AppDbContext db) =>
        {
            var alerts = db.Alerts
                .OrderByDescending(x => x.CreatedAt)
                .Take(100)
                .ToList();

            return Results.Ok(alerts);
        });
    }
}