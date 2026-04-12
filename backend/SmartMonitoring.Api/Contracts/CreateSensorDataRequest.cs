namespace SmartMonitoring.Api.Contracts;

public class CreateSensorDataRequest
{
    public string MachineId { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public double Pressure { get; set; }
    public DateTimeOffset Timestamp { get; set; }
}