using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace CourseWork2.CustomControls;

/// <summary>
///     Логика взаимодействия для BindablePasswordBox.xaml
/// </summary>
public partial class BindablePasswordBox : UserControl
{
    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register(nameof(Password), typeof(SecureString), typeof(BindablePasswordBox));

    public BindablePasswordBox()
    {
        InitializeComponent();
        passwordBox.PasswordChanged += OnPasswordChanged;
    }

    public SecureString Password
    {
        get => (SecureString)GetValue(PasswordProperty);
        set => SetValue(PasswordProperty, value);
    }

    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        Password = passwordBox.SecurePassword;
    }
}