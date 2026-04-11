namespace SmartMonitoring.Api.Models;

public class Alert
{
    public int Id { get; set; }
    public string MachineId { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Severity { get; set; } = "warning";
    public DateTime CreatedAt { get; set; }
}