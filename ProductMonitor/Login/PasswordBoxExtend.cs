using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace ProductMonitor.Login;

public class PasswordBoxExtend : DependencyObject
{
    public static string GetMyPassword(DependencyObject obj)
    {
        return (string)obj.GetValue(MyPasswordProperty);
    }

    public static void SetMyPassword(DependencyObject obj, string value)
    {
        obj.SetValue(MyPasswordProperty, value);
    }

    public static readonly DependencyProperty MyPasswordProperty = DependencyProperty.Register(
        "MyPassword", typeof(string), typeof(PasswordBoxExtend),
        new PropertyMetadata(default(string), OnMyPasswordChanged));

    private static void OnMyPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        PasswordBox passwordBox = d as PasswordBox;
        if (passwordBox == null)
            return;

        string newPassword = (string)e.NewValue;
        if (newPassword == passwordBox.Password)
            return;

        passwordBox.Password = newPassword;
    }
}

public class PasswordBoxBehavior : Behavior<PasswordBox>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.PasswordChanged += OnPasswordChanged;
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject.PasswordChanged -= OnPasswordChanged;
    }

    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordBox passwordBox = sender as PasswordBox;
        if (passwordBox == null)
            return;

        string oldPassword = PasswordBoxExtend.GetMyPassword(passwordBox);

        if (oldPassword == passwordBox.Password)
            return;

        PasswordBoxExtend.SetMyPassword(passwordBox, passwordBox.Password);
    }
}