using System.Collections.ObjectModel;
using System.Windows;
using ProductMonitorControlLibrary.Models;

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

    private ObservableCollection<MachineModel> _machineList;

    public ObservableCollection<MachineModel> MachineList
    {
        get => _machineList;
        set => SetProperty(ref _machineList, value);
    }

    private Visibility _detailBorderVisibility;

    public Visibility DetailBorderVisibility
    {
        get => _detailBorderVisibility;
        set => SetProperty(ref _detailBorderVisibility, value);
    }

    private bool _isDetailVisible;

    public bool IsDetailVisible
    {
        get => _isDetailVisible;
        set => SetProperty(ref _isDetailVisible, value);
    }

    public DelegateCommand<string> GoBackCommand { get; }
    public DelegateCommand ShowDetailCommand { get; }
    public DelegateCommand HideDetailCommand { get; }
    public DelegateCommand OnAnimationCompletedCommand { get; }

    public WorkShopDetailUserControlViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
        _detailBorderVisibility = Visibility.Collapsed;
        GoBackCommand = new DelegateCommand<string>(ShowMonitor);
        ShowDetailCommand = new DelegateCommand(ShowDetail);
        HideDetailCommand = new DelegateCommand(HideDetail);
        OnAnimationCompletedCommand = new DelegateCommand(HideDetailCompleted);
        MachineList = new ObservableCollection<MachineModel>();
        Random random = new Random();
        for (int i = 0; i < 20; i++)
        {
            int plan = random.Next(100, 1000);
            int complete = random.Next(100, plan);
            int status = random.Next(0, 4);
            MachineList.Add(new MachineModel
            {
                MachineName = $"焊接机-{i + 1}",
                CompleteCount = complete,
                PlanCount = plan,
                Status = status switch
                {
                    0 => "作业中",
                    1 => "等待中",
                    2 => "故障中",
                    3 => "停机中",
                    _ => "未知"
                },
                OrderNumber = $"NO-{random.Next(1000, 9999)}"
            });
        }
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

    private void ShowMonitor(string workShopName)
    {
        _regionManager.RequestNavigate("ContentRegion",
            new Uri($"MonitorUserControl?workShopName={workShopName}",
                UriKind.Relative));
    }

    private void ShowDetail()
    {
        DetailBorderVisibility = Visibility.Visible;
        IsDetailVisible = true;
    }

    private void HideDetail()
    {
        IsDetailVisible = false;
    }

    private void HideDetailCompleted()
    {
        DetailBorderVisibility = Visibility.Collapsed;
    }
}