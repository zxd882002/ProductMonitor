using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProductMonitorControlLibrary.Views;

public partial class RingUserControl : UserControl
{
    public double PercentageValue
    {
        get => (double)GetValue(PercentageValueProperty);
        set => SetValue(PercentageValueProperty, value);
    }

    public static readonly DependencyProperty PercentageValueProperty = DependencyProperty.Register(
        nameof(PercentageValue), typeof(double), typeof(RingUserControl),
        new PropertyMetadata(default(double)));

    public RingUserControl()
    {
        InitializeComponent();
        SizeChanged += (sender, args) => DrawRing();
    }

    private void DrawRing()
    {
        RootGrid.Width = Math.Min(RenderSize.Width, RenderSize.Height);
        RootGrid.Height = Math.Min(RenderSize.Width, RenderSize.Height);
        var radius = RootGrid.Width / 2;

        // 这里的5是因为StrokeThickness是10，所以需要一半变成5
        double x = radius + (radius - 5) * Math.Sin(PercentageValue / 100 * 2 * Math.PI);
        double y = radius - (radius - 5) * Math.Cos(PercentageValue / 100 * 2 * Math.PI);

        // M 起始X，起始Y A 半径X，半径Y 0 大角度 1 结束X，结束Y
        string pathStr =
            $"M {radius},5 A {radius - 5} {radius - 5} 0 {(PercentageValue < 50 ? 0 : 1)} 1 {x},{y}";
        FillPath.Data = (Geometry)TypeDescriptor.GetConverter(typeof(Geometry)).ConvertFrom(pathStr)!;
    }
}