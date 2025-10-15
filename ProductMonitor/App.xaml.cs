using System;
using System.Windows;
using Prism.Ioc;
using Prism.Services.Dialogs;
using ProductMonitor.ViewModels;
using ProductMonitor.Views;

namespace ProductMonitor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<LoginUserControl, LoginUserControlViewModel>();
        }

        protected override void OnInitialized()
        {
            var dialog = Container.Resolve<IDialogService>();
            dialog.ShowDialog("LoginUserControl", r =>
            {
                if (r.Result != ButtonResult.OK)
                {
                    Environment.Exit(0);
                    return;
                }
            });

            base.OnInitialized();
        }
    }
}
