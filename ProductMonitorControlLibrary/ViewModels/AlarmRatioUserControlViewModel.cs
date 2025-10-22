using LiveCharts;
using LiveCharts.Wpf;
using Prism.Mvvm;

namespace ProductMonitorControlLibrary.ViewModels;

public class AlarmRatioUserControlViewModel : BindableBase
{
    private SeriesCollection _pieSeries;

    public SeriesCollection PieSeries
    {
        get => _pieSeries;
        set => SetProperty(ref _pieSeries, value);
    }

    public AlarmRatioUserControlViewModel()
    {
        _pieSeries = new SeriesCollection
        {
            new PieSeries { Title = "压差", Values = new ChartValues<int> { 20 } },
            new PieSeries { Title = "振动", Values = new ChartValues<int> { 40 } },
            new PieSeries { Title = "设备温度", Values = new ChartValues<int> { 10 } },
            new PieSeries { Title = "光照", Values = new ChartValues<int> { 30 } },
        };
    }
}