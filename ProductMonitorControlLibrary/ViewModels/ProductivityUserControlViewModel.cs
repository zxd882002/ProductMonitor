using System.Windows;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;

namespace ProductMonitorControlLibrary.ViewModels;

public class ProductivityUserControlViewModel : BindableBase
{
    private string[] _xLabels;

    public string[] XLabels
    {
        get => _xLabels;
        set => SetProperty(ref _xLabels, value);
    }

    private int _xStep;

    public int XStep
    {
        get => _xStep;
        set => SetProperty(ref _xStep, value);
    }

    private int _minYValue;

    public int MinYValue
    {
        get => _minYValue;
        set => SetProperty(ref _minYValue, value);
    }

    private int _maxYValue;

    public int MaxYValue
    {
        get => _maxYValue;
        set => SetProperty(ref _maxYValue, value);
    }

    private int _yStep;

    public int YStep
    {
        get => _yStep;
        set => SetProperty(ref _yStep, value);
    }

    private ChartValues<int> _productCount;

    public ChartValues<int> ProductCount
    {
        get => _productCount;
        set => SetProperty(ref _productCount, value);
    }

    private ChartValues<int> _badCount;

    public ChartValues<int> BadCount
    {
        get => _badCount;
        set => SetProperty(ref _badCount, value);
    }

    public ProductivityUserControlViewModel()
    {
        _xLabels =
        [
            "8:00",
            "9:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00"
        ];
        _xStep = 1;

        _productCount =
        [
            300,
            400,
            480,
            450,
            380,
            450,
            450,
            330,
            340
        ];

        _badCount =
        [
            15,
            55,
            15,
            40,
            38,
            45
        ];

        _minYValue = 0;
        _maxYValue = 500;
        _yStep = 100;
    }
}