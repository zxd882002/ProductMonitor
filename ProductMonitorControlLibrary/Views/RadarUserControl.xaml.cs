using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using ProductMonitorControlLibrary.Models;

namespace ProductMonitorControlLibrary.Views;

public partial class RadarUserControl : UserControl
{
    public ObservableCollection<ItemNameValueModel> ItemList
    {
        get => (ObservableCollection<ItemNameValueModel>)GetValue(ItemListProperty);
        set => SetValue(ItemListProperty, value);
    }

    public static readonly DependencyProperty ItemListProperty = DependencyProperty.Register(
        nameof(ItemList), typeof(ObservableCollection<ItemNameValueModel>), typeof(RadarUserControl),
        new PropertyMetadata(default(ObservableCollection<ItemNameValueModel>)));

    public RadarUserControl()
    {
        InitializeComponent();
        SizeChanged += (sender, args) => UpdatePoints();
    }

    public void UpdatePoints()
    {
        if (ItemList == null || ItemList.Count <= 2)
            return;

        var size = Math.Min(RenderSize.Height, RenderSize.Width);
        MainCanvas.Height = size;
        MainCanvas.Width = size;
        var centerX = size / 2;
        var centerY = size / 2;
        var radius = size / 2;
        var angleStep = Math.PI * 2 / ItemList.Count;

        MainCanvas.Children.Clear();

        DrawWeb(P1, 1, centerX, centerY, radius, angleStep);
        MainCanvas.Children.Add(P1);
        
        DrawWeb(P2, 0.75, centerX, centerY, radius, angleStep);
        MainCanvas.Children.Add(P2);
        
        DrawWeb(P3, 0.5, centerX, centerY, radius, angleStep);
        MainCanvas.Children.Add(P3);
        
        DrawWeb(P4, 0.25, centerX, centerY, radius, angleStep);
        MainCanvas.Children.Add(P4);

        DrawData(P5, centerX, centerY, radius, angleStep);
        MainCanvas.Children.Add(P5);
        
        DrawLabel(centerX, centerY, radius, angleStep);
    }

    private void DrawWeb(Polygon polygon, double rate, double centerX, double centerY, double radius, double angleStep)
    {
        polygon.Points.Clear();
        for (var i = 0; i < ItemList.Count; i++)
        {
            var angle = i * angleStep - Math.PI / 2;
            var x = centerX + radius * Math.Cos(angle) * rate;
            var y = centerY + radius * Math.Sin(angle) * rate;
            polygon.Points.Add(new Point(x, y));
        }
    }

    private void DrawData(Polygon polygon, double centerX, double centerY, double radius, double angleStep)
    {
        polygon.Points.Clear();
        for (var i = 0; i < ItemList.Count; i++)
        {
            var angle = i * angleStep - Math.PI / 2;
            var x = centerX + radius * Math.Cos(angle) * (ItemList[i].ItemValue / 100);
            var y = centerY + radius * Math.Sin(angle) * (ItemList[i].ItemValue / 100);
            polygon.Points.Add(new Point(x, y));
        }
    }

    private void DrawLabel(double centerX, double centerY, double radius, double angleStep)
    {
        for (var i = 0; i < ItemList.Count; i++)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Width = 60;
            textBlock.Height = 12;
            textBlock.Text = ItemList[i].ItemName;
            textBlock.FontSize = 10;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.Foreground = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

            MainCanvas.Children.Add(textBlock);
            
            var angle = i * angleStep - Math.PI / 2;
            var x = centerX + radius * Math.Cos(angle) * 1.2;
            var y = centerY + radius * Math.Sin(angle) * 1.2;
            Canvas.SetLeft(textBlock, x - textBlock.Width / 2);
            Canvas.SetTop(textBlock, y - textBlock.Height / 2);
        }
    }
}