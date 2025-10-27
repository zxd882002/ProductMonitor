using System;
using System.Windows;
using Prism.Dialogs;
using Prism.Ioc;
using ProductMonitor.Views;
using ProductMonitor.Login;
using ProductMonitorControlLibrary.ViewModels;
using ProductMonitorControlLibrary.Views;
using Prism.Navigation.Regions;
using ProductMonitorControlLibrary.Behaviors;

namespace ProductMonitor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            //return new SettingsWindow();
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<LoginUserControl, LoginUserControlViewModel>();
            containerRegistry.RegisterDialog<SettingsWindow, SettingsWindowViewModel>(nameof(SettingsWindow));
            containerRegistry.RegisterForNavigation<MonitorUserControl, MonitorUserControlViewModel>(
                nameof(MonitorUserControl));
            containerRegistry.RegisterForNavigation<WorkShopDetailUserControl, WorkShopDetailUserControlViewModel>(
                nameof(WorkShopDetailUserControl));
        }

        protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
        {
            base.ConfigureDefaultRegionBehaviors(regionBehaviors);
            regionBehaviors.AddIfMissing(NavigationAnimationBehavior.BehaviorKey, typeof(NavigationAnimationBehavior));
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

                // 登录成功后再导航到MonitorUserControl
                var regionManager = Container.Resolve<IRegionManager>();
                regionManager.RequestNavigate("ContentRegion", nameof(MonitorUserControl));
                base.OnInitialized();
            });
        }
    }
}