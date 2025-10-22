using ProductMonitorControlLibrary.Models;

namespace ProductMonitorControlLibrary.ViewModels;

public class AlarmUserControlViewModel : BindableBase
{
    private List<AlarmModel> _alarmList;

    public List<AlarmModel> AlarmList
    {
        get => _alarmList;
        set => SetProperty(ref _alarmList, value);
    }

    public AlarmUserControlViewModel()
    {
        _alarmList = new List<AlarmModel>
        {
            new() { Number = "01", Message = "设备温度过高", AlarmTime = "2023-01-01 10:00:56", DurationSeconds = 7 },
            new() { Number = "02", Message = "车间温度过高", AlarmTime = "2023-12-31 11:40:00", DurationSeconds = 10 },
            new() { Number = "03", Message = "设备转速过快", AlarmTime = "2024-01-01 12:24:34", DurationSeconds = 12 },
            new() { Number = "04", Message = "设备气压过低", AlarmTime = "2024-02-07 13:58:00", DurationSeconds = 90 },
        };
    }
}