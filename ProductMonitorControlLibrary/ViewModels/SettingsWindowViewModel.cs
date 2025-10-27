using ProductMonitorControlLibrary.Models;

namespace ProductMonitorControlLibrary.ViewModels;

public class SettingsWindowViewModel : BindableBase, IDialogAware
{
    public DelegateCommand<string> OnSelectedCommand { get; }

    public Action<Uri> NavigateAction { get; set; }

    public SettingsWindowViewModel(IEventAggregator eventAggregator)
    {
        OnSelectedCommand = new DelegateCommand<string>(OnSelected);
    }

    private void OnSelected(string navigateName)
        {
            Uri uri = new Uri("pack://application:,,,/ProductMonitorControlLibrary;component/Views/SettingsPage.xaml#" + navigateName,
                UriKind.Absolute);
            NavigateAction?.Invoke(uri);
        }

    public bool CanCloseDialog()
    {
        return true;
    }

    public void OnDialogClosed()
    {
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
    }

    public DialogCloseListener RequestClose { get; }
}