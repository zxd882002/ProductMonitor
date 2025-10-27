using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Microsoft.Xaml.Behaviors;

namespace ProductMonitorControlLibrary.Behaviors;

public class BorderAnimationBehavior : Behavior<Border>
{
    public static readonly DependencyProperty IsVisibleProperty = DependencyProperty.Register(
        nameof(IsVisible), typeof(bool), typeof(BorderAnimationBehavior),
        new PropertyMetadata(false, OnIsVisibleChanged));

    public bool IsVisible
    {
        get => (bool)GetValue(IsVisibleProperty);
        set => SetValue(IsVisibleProperty, value);
    }

    public ICommand OnAnimationCompletedCommand
    {
        get => (ICommand)GetValue(OnAnimationCompletedCommandProperty);
        set => SetValue(OnAnimationCompletedCommandProperty, value);
    }

    public static readonly DependencyProperty OnAnimationCompletedCommandProperty = DependencyProperty.Register(
        nameof(OnAnimationCompletedCommand), typeof(ICommand), typeof(BorderAnimationBehavior),
        new PropertyMetadata(default(ICommand)));

    private static void OnIsVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var behavior = (BorderAnimationBehavior)d;
        if ((bool)e.NewValue && behavior.AssociatedObject != null)
        {
            behavior.ExecuteShowAnimation();
        }
        else if (!(bool)e.NewValue && behavior.AssociatedObject != null)
        {
            behavior.ExecuteHideAnimation();
        }
    }

    private void ExecuteShowAnimation()
    {
        if (AssociatedObject == null) return;

        var storyboard = new Storyboard();

        // 边距动画 - 从下方滑入
        var thicknessAnimation = new ThicknessAnimation(
            new Thickness(0, 50, 0, -50),
            new Thickness(0, 0, 0, 0),
            TimeSpan.FromMilliseconds(400));
        Storyboard.SetTarget(thicknessAnimation, AssociatedObject);
        Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath(FrameworkElement.MarginProperty));
        storyboard.Children.Add(thicknessAnimation);

        // 透明度动画 - 淡入
        var opacityAnimation = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(400));
        Storyboard.SetTarget(opacityAnimation, AssociatedObject);
        Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));
        storyboard.Children.Add(opacityAnimation);

        storyboard.Begin();
    }

    private void ExecuteHideAnimation()
    {
        if (AssociatedObject == null) return;

        var storyboard = new Storyboard();

        // 边距动画 - 从下方滑出
        var thicknessAnimation = new ThicknessAnimation(
            new Thickness(0, 0, 0, 0),
            new Thickness(0, 50, 0, -50),
            TimeSpan.FromMilliseconds(400));
        Storyboard.SetTarget(thicknessAnimation, AssociatedObject);
        Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath(FrameworkElement.MarginProperty));
        storyboard.Children.Add(thicknessAnimation);

        // 透明度动画 - 淡出
        var opacityAnimation = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(400));
        Storyboard.SetTarget(opacityAnimation, AssociatedObject);
        Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));
        storyboard.Children.Add(opacityAnimation);
   
        storyboard.Completed += (s, e) => OnAnimationCompletedCommand?.Execute(null);
        storyboard.Begin();
    }
}