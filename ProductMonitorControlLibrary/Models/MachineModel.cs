namespace ProductMonitorControlLibrary.Models;

public class MachineModel
{
    public string MachineName { get; set; }
    public string Status { get; set; }
    public int PlanCount { get; set; }
    public int CompleteCount { get; set; }
    public double CompleteRate => CompleteCount * 100.0 / PlanCount;
    public string OrderNumber { get; set; }
}