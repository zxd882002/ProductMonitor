namespace ProductMonitorControlLibrary.ViewModels;

public class WorkShopDetailUserControlViewModel : BindableBase, INavigationAware
{
    private IRegionManager _regionManager;

    private string _workShopName;

    public string WorkShopName
    {
        get { return _workShopName; }
        set { SetProperty(ref _workShopName, value); }
    }

    public WorkShopDetailUserControlViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
        if (navigationContext.Parameters.ContainsKey("workShopName"))
        {
            string workShopName = navigationContext.Parameters.GetValue<string>("workShopName");
            WorkShopName = workShopName;
        }
    }

    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }
}