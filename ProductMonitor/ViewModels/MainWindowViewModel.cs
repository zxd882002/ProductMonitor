using Prism.Mvvm;

namespace ProductMonitor.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "生成监控平台";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _subTitle = "一个天花板极的MES系统";

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