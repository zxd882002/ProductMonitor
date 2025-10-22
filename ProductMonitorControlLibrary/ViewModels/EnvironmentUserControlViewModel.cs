using ProductMonitorControlLibrary.Models;

namespace ProductMonitorControlLibrary.ViewModels;

public class EnvironmentUserControlViewModel : BindableBase
{
    private List<EnvironmentModel> _environmentList;

    public List<EnvironmentModel> EnvironmentList
    {
        get => _environmentList;
        set => SetProperty(ref _environmentList, value);
    }

    public EnvironmentUserControlViewModel()
    {
        _environmentList = new ()
        {
            new () { EnvironmentItemName = "光照（lux）", EnvironmentItemValue = 123 },
            new () { EnvironmentItemName = "噪音（dB）", EnvironmentItemValue = 55 },
            new () { EnvironmentItemName = "温度（℃）", EnvironmentItemValue = 80 },
            new () { EnvironmentItemName = "湿度（%）", EnvironmentItemValue = 43 },
            new () { EnvironmentItemName = "PM2.5（μg/m³）", EnvironmentItemValue = 20 },
            new () { EnvironmentItemName = "硫化氢（ppm）", EnvironmentItemValue = 15 },
            new () { EnvironmentItemName = "氮气（ppm）", EnvironmentItemValue = 18 },
        };
    }
}