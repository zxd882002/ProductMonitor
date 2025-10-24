using System.Windows;
using System.Windows.Media.Animation;

namespace ProductMonitorControlLibrary.Behaviors;

public class NavigationAnimationBehavior : RegionBehavior
{
    public const string BehaviorKey = "NavigationAnimationBehavior";

    protected override void OnAttach()
    {
        Region.NavigationService.Navigating += OnNavigating;
        Region.NavigationService.Navigated += OnNavigated;
    }

    private void OnNavigating(object? sender, RegionNavigationEventArgs e)
    {
    }

    private void OnNavigated(object? sender, RegionNavigationEventArgs e)
    {
        if (bool.TryParse(e.NavigationContext.Parameters["EnableAnimation"]?.ToString(), out var enableAnimation) &&
            enableAnimation)
        {
            var newView = Region.ActiveViews.FirstOrDefault() as UIElement;
            if (newView == null)
                return;

            var storyboard = new Storyboard();

            var thicknessAnimation = new ThicknessAnimation(
                new Thickness(0, 50, 0, -50),
                new Thickness(0, 0, 0, 0),
                TimeSpan.FromMilliseconds(400));
            Storyboard.SetTarget(thicknessAnimation, newView);
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath(FrameworkElement.MarginProperty));
            storyboard.Children.Add(thicknessAnimation);

            var opacityAnimation = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(400));
            Storyboard.SetTarget(opacityAnimation, newView);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));
            storyboard.Children.Add(opacityAnimation);

            storyboard.Begin();
        }
    }
}