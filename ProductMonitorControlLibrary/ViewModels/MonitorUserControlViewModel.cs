using System.Collections.ObjectModel;
using ProductMonitorControlLibrary.Models;

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
    
    private ObservableCollection<ItemNameValueModel> _environmentList;
    
    public ObservableCollection<ItemNameValueModel> EnvironmentList
    {
        get => _environmentList;
        set => SetProperty(ref _environmentList, value);
    }
    
    private ObservableCollection<ItemNameValueModel> _deviceList;
    
    public ObservableCollection<ItemNameValueModel> DeviceList
    {
        get => _deviceList;
        set => SetProperty(ref _deviceList, value);
    }
    
    private ObservableCollection<ItemNameValueModel> _radarList;
    public ObservableCollection<ItemNameValueModel> RadarList
    {
        get => _radarList;
        set => SetProperty(ref _radarList, value);
    }
    
    public MonitorUserControlViewModel()
    {
        _timer = new Timer(OnTimer, null, 0, 1000);
        _machineCount = "0298";
        _productCount = "1643";
        _badCount = "023";
        
        _environmentList = new ObservableCollection<ItemNameValueModel>()
        {
            new () { ItemName = "光照（lux）", ItemValue = 123 },
            new () { ItemName = "噪音（dB）", ItemValue = 55 },
            new () { ItemName = "温度（℃）", ItemValue = 80 },
            new () { ItemName = "湿度（%）", ItemValue = 43 },
            new () { ItemName = "PM2.5（μg/m³）", ItemValue = 20 },
            new () { ItemName = "硫化氢（ppm）", ItemValue = 15 },
            new () { ItemName = "氮气（ppm）", ItemValue = 18 },
        };
        
        _deviceList = new ObservableCollection<ItemNameValueModel>()
        {
            new () { ItemName = "电能（kWh）", ItemValue = 60.8},
            new () { ItemName = "电压（V）", ItemValue = 390 },
            new () { ItemName = "电流（A）", ItemValue = 5 },
            new () { ItemName = "压差（kpa）", ItemValue = 13 },
            new () { ItemName = "温度（℃）", ItemValue = 36 },
            new () { ItemName = "振动（mm/s）", ItemValue = 4.1 },
            new () { ItemName = "转速（r/min）", ItemValue = 2600 },
            new () { ItemName = "气压（kPa）", ItemValue = 0.5 },
        };
        
        _radarList = new ObservableCollection<ItemNameValueModel>
        {
            new () { ItemName = "排烟风机", ItemValue = 90 },
            new () { ItemName = "客梯", ItemValue = 30 },
            new () { ItemName = "供水机", ItemValue = 34.89 },
            new () { ItemName = "喷淋水泵", ItemValue = 69.59 },
            new () { ItemName = "稳压设备", ItemValue = 20 },
        };
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