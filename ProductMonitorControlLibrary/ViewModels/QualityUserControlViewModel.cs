using LiveCharts;

namespace ProductMonitorControlLibrary.ViewModels;

public class QualityUserControlViewModel : BindableBase
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
    
    private ChartValues<int> _quantity;

    public ChartValues<int> Quantity
    {
        get => _quantity;
        set => SetProperty(ref _quantity, value);
    }

    public QualityUserControlViewModel()
    {
        _xLabels =
        [
            "1#",
            "2#",
            "3#",
            "4#",
            "5#",
            "6#"
        ];
        _xStep = 1;
        _quantity = [8, 2, 7, 6, 4, 14];
        _minYValue = 0;
        _maxYValue = 15;
        _yStep = 5;
    }
}