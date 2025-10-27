using System.Windows;
using System.Windows.Controls;
using ProductMonitorControlLibrary.ViewModels;

namespace ProductMonitorControlLibrary.Views;

public partial class SettingsWindow : UserControl
{
    public SettingsWindow()
    {
        InitializeComponent();
        
        DataContextChanged += (sender, args) =>
        {
            if (DataContext is SettingsWindowViewModel viewModel)
            {
                viewModel.NavigateAction = uri => SettingsFrame.Navigate(uri);
            }
        };
    }
}