using ProductMonitorControlLibrary.Models;

namespace ProductMonitorControlLibrary.ViewModels;

public class HumanUserControlViewModel : BindableBase
{
    private int _total;

    public int Total
    {
        get => _total;
        set => SetProperty(ref _total, value);
    }

    private List<StaffOutOfWorkModel> _staffOutOfWorkList;

    public List<StaffOutOfWorkModel> StaffOutOfWorkList
    {
        get => _staffOutOfWorkList;
        set => SetProperty(ref _staffOutOfWorkList, value);
    }

    public HumanUserControlViewModel()
    {
        _total = 870;
        StaffOutOfWorkList = new List<StaffOutOfWorkModel>
        {
            new(){Name = "张晓婷", Position = "技术员", OutOfWorkCount = 123},
            new(){Name = "李晓", Position = "操作员", OutOfWorkCount = 23},
            new(){Name = "王克俭", Position = "技术员", OutOfWorkCount = 134},
            new(){Name = "陈家栋", Position = "统计员", OutOfWorkCount = 143},
            new(){Name = "杨过", Position = "技术员", OutOfWorkCount = 12},
        };
    }
}