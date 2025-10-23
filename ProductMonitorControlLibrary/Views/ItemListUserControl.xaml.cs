using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ProductMonitorControlLibrary.Models;

namespace ProductMonitorControlLibrary.Views;

public partial class ItemListUserControl : UserControl
{
    public ObservableCollection<ItemNameValueModel> ItemList
    {
        get => (ObservableCollection<ItemNameValueModel>)GetValue(ItemListProperty);
        set => SetValue(ItemListProperty, value);
    }

    public static readonly DependencyProperty ItemListProperty = DependencyProperty.Register(
        nameof(ItemList), typeof(ObservableCollection<ItemNameValueModel>), typeof(ItemListUserControl),
        new PropertyMetadata(default(ObservableCollection<ItemNameValueModel>)));
    
    public ItemListUserControl()
    {
        InitializeComponent();
    }
}