using Microsoft.EntityFrameworkCore;

namespace TaskerApi.Models;

public class TaskItemContext : DbContext
{
    protected readonly IConfiguration Configuration;
    public TaskItemContext(IConfiguration configuration) 
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<TaskItem> TaskItems {get; set; } = null!;
}