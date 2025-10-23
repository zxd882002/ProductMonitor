namespace ProductMonitorControlLibrary.Models;

public class WorkShopModel
{
    public string Name { get; set; }

    public int WorkingCount { get; set; }
    public int WaitingCount { get; set; }
    public int ErrorCount { get; set; }
    public int StopCount { get; set; }

    public int TotalCount => WorkingCount + WaitingCount + ErrorCount + StopCount;
}