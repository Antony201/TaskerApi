namespace TaskerApi.Models;

public class TaskItem
{
    public long id {get; set; }
    public string? Name {get; set; }
    public string? Description{get; set;}
    public bool IsDone {get; set; }
}