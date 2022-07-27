namespace TaskManagerSolution.Domain.Entities.SysLog;

public class Syslog
{
    public int Id { get; set; }
    public string LogDate { get; set; }
    public string LogTime { get; set; }
    public string LogMessage { get; set; }
    public string ClaintIP { get; set; }
    
}