using Prism.Mvvm;

namespace ProductMonitor.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
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

        public MainWindowViewModel()
        {
        }
    }
}