using SmartMonitoring.Api.Models;

namespace SmartMonitoring.Api.Services;

public class AnomalyDetectionService
{
    public Alert? Detect(SensorData data)
    {
        if (data.Temperature > 80)
        {
            return new Alert
            {
                MachineId = data.MachineId,
                Message = $"High temperature detected: {data.Temperature}",
                Severity = "high",
                CreatedAt = DateTime.UtcNow
            };
        }

        if (data.Pressure > 150)
        {
            return new Alert
            {
                MachineId = data.MachineId,
                Message = $"High pressure detected: {data.Pressure}",
                Severity = "high",
                CreatedAt = DateTime.UtcNow
            };
        }

        return null;
    }
}