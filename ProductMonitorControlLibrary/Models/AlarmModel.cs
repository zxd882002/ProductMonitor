namespace ProductMonitorControlLibrary.Models;

public class AlarmModel
{
    public string Number { get; set; }
    public string Message { get; set; }
    public string AlarmTime { get; set; }
    public int DurationSeconds { get; set; }
}