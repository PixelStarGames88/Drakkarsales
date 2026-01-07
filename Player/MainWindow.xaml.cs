using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Player;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void MoveWindow_MousePeess(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            this.DragMove();
        }
    }
    private void EnterToAccontCreate_Click(object sender, MouseButtonEventArgs e)
    {
        GridForEnter.Visibility = Visibility.Hidden;
        GridForAcciuntCreating.Visibility = Visibility.Visible;
    }
    private void EnterToEnter_Click(object sender, MouseButtonEventArgs e)
    {
        GridForEnter.Visibility = Visibility.Visible;
        GridForAcciuntCreating.Visibility = Visibility.Hidden;
    }
    private void EnterLabelCreateAccount_MouseEnter(object sender, MouseEventArgs e)
    {
        EnterLabelCreateAccount.Foreground = Brushes.Red;
    }
    private void EnterLabelCreateAccount_MouseLeave(object sender, MouseEventArgs e)
    {
        EnterLabelCreateAccount.Foreground = Brushes.Black;
    }
    private void ExitLabelCreateAccount_MouseEnter(object sender, MouseEventArgs e)
    {
        ExitLabelCreateAccount.Foreground = Brushes.Red;
    }
    private void ExitLabelCreateAccount_MouseLeave(object sender, MouseEventArgs e)
    {
        ExitLabelCreateAccount.Foreground = Brushes.Black;
    }
    private void ExitApplication_Click(object sender, MouseButtonEventArgs e)
    {
        Application.Current.Shutdown();
    }
    private void HideWindow_Click(object sender, MouseButtonEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void NewAccountLabelEnter_MouseEnter(object sender, MouseEventArgs e)
    {
        NewAccountLabelEnter.Foreground = Brushes.Red;
    }

    private void NewAccountLabelEnter_MouseLeave(object sender, MouseEventArgs e)
    {
        NewAccountLabelEnter.Foreground = Brushes.Black;
    }

    private void EnterLabelEnter_MouseEnter(object sender, MouseEventArgs e)
    {
        EnterLabelEnter.Foreground = Brushes.Red;
    }

    private void EnterLabelEnter_MouseLeave(object sender, MouseEventArgs e)
    {
        EnterLabelEnter.Foreground = Brushes.Black;
    }
}