namespace ProductMonitorControlLibrary.Models;

public class StaffOutOfWorkModel
{
    public string Name { get; set; }
    public string Position { get; set; }
    public int OutOfWorkCount { get; set; }

    public double ShowWidth => OutOfWorkCount * 0.7;
}