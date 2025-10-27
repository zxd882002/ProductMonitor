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
        public DelegateCommand MinimizeCommand { get; }
        public DelegateCommand MaximizeCommand { get; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            CloseCommand = new AsyncDelegateCommand(ExecuteAsync);
            MinimizeCommand = new DelegateCommand(MinimizeWindow);
            MaximizeCommand = new DelegateCommand(MaximizeOrRestoreWindow);
        }

        // 最大化或还原窗口方法
        private void MaximizeOrRestoreWindow()
        {
            var window = System.Windows.Application.Current.MainWindow;
            if (window.WindowState == System.Windows.WindowState.Maximized)
            {
                window.WindowState = System.Windows.WindowState.Normal;
            }
            else
            {
                window.WindowState = System.Windows.WindowState.Maximized;
            }
        }

        // 最小化窗口方法
        private void MinimizeWindow()
        {
            System.Windows.Application.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
        }

        // 异步执行方法（返回Task）
        private async Task ExecuteAsync()
        {
            System.Windows.Application.Current.MainWindow.Close();
            Environment.Exit(0);
        }
    }
}