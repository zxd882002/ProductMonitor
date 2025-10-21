using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using ProductMonitorControlLibrary.Views;

namespace ProductMonitor.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private string _title = "生产监控平台";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _subTitle = "相信自己，你可以的";

        public string SubTitle
        {
            get => _subTitle;
            set => SetProperty(ref _subTitle, value);
        }

        private string _footer = "模拟数据，仅供参考";

        public string Footer
        {
            get => _footer;
            set => SetProperty(ref _footer, value);
        }

        public AsyncDelegateCommand CloseCommand { get; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            CloseCommand = new AsyncDelegateCommand(ExecuteAsync);
        }

        // 异步执行方法（返回Task）
        private async Task ExecuteAsync()
        {
            await Task.Delay(1000);
            Environment.Exit(0);
        }
    }
}