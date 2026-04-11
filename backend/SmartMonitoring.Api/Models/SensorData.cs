namespace SmartMonitoring.Api.Models;

public class SensorData
{
    public int Id { get; set; }
    public string MachineId { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public double Pressure { get; set; }
    public DateTime Timestamp { get; set; }
}