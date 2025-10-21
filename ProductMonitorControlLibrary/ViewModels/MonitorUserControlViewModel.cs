namespace ProductMonitorControlLibrary.ViewModels;

public class MonitorUserControlViewModel : BindableBase
{
    private Timer _timer;

    private string _time = string.Empty;

    public string Time
    {
        get => _time;
        set => SetProperty(ref _time, value);
    }

    private string _date = string.Empty;

    public string Date
    {
        get => _date;
        set => SetProperty(ref _date, value);
    }

    private string _week = string.Empty;

    public string Week
    {
        get => _week;
        set => SetProperty(ref _week, value);
    }

    private string _machineCount;

    public string MachineCount
    {
        get => _machineCount;
        set => _machineCount = value;
    }

    private string _productCount;

    public string ProductCount
    {
        get => _productCount;
        set => _productCount = value;
    }

    private string _badCount;

    public string BadCount
    {
        get => _badCount;
        set => _badCount = value;
    }
    
    public MonitorUserControlViewModel()
    {
        _timer = new Timer(OnTimer, null, 0, 1000);
        _machineCount = "0298";
        _productCount = "1643";
        _badCount = "023";
    }

    private void OnTimer(object? state)
    {
        DateTime now = DateTime.Now;
        Time = now.ToString("HH:mm");
        Date = now.ToString("yyyy-MM-dd");
        //Week = new[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" }[(int)now.DayOfWeek];
        Week = now.ToString("dddd");
    }
}