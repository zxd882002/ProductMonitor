using System.Windows;
using System.Windows.Controls;

namespace ProductMonitorControlLibrary.Views;

public partial class WorkShopUserControl : UserControl
{
    public string WorkShopName
    {
        get => (string)GetValue(WorkShopNameProperty);
        set => SetValue(WorkShopNameProperty, value);
    }

    public static readonly DependencyProperty WorkShopNameProperty = DependencyProperty.Register(
        nameof(WorkShopName), typeof(string), typeof(WorkShopUserControl), new PropertyMetadata(default(string)));

    public int Total
    {
        get => (int)GetValue(TotalProperty);
        set => SetValue(TotalProperty, value);
    }

    public static readonly DependencyProperty TotalProperty = DependencyProperty.Register(
        nameof(Total), typeof(int), typeof(WorkShopUserControl), new PropertyMetadata(default(int)));

    public int WorkingCount
    {
        get => (int)GetValue(WorkingCountProperty);
        set => SetValue(WorkingCountProperty, value);
    }

    public static readonly DependencyProperty WorkingCountProperty = DependencyProperty.Register(
        nameof(WorkingCount), typeof(int), typeof(WorkShopUserControl), new PropertyMetadata(default(int)));


    public int ErrorCount
    {
        get => (int)GetValue(ErrorCountProperty);
        set => SetValue(ErrorCountProperty, value);
    }

    public static readonly DependencyProperty ErrorCountProperty = DependencyProperty.Register(
        nameof(ErrorCount), typeof(int), typeof(WorkShopUserControl), new PropertyMetadata(default(int)));

    public int WaitingCount
    {
        get => (int)GetValue(WaitingCountProperty);
        set => SetValue(WaitingCountProperty, value);
    }

    public static readonly DependencyProperty WaitingCountProperty = DependencyProperty.Register(
        nameof(WaitingCount), typeof(int), typeof(WorkShopUserControl), new PropertyMetadata(default(int)));

    public int StopCount
    {
        get => (int)GetValue(StopCountProperty);
        set => SetValue(StopCountProperty, value);
    }

    public static readonly DependencyProperty StopCountProperty = DependencyProperty.Register(
        nameof(StopCount), typeof(int), typeof(WorkShopUserControl), new PropertyMetadata(default(int)));
    
    public WorkShopUserControl()
    {
        InitializeComponent();
    }
}