using Microsoft.EntityFrameworkCore;
using SmartMonitoring.Api.Models;

namespace SmartMonitoring.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<SensorData> SensorData => Set<SensorData>();
    public DbSet<Alert> Alerts => Set<Alert>();
}