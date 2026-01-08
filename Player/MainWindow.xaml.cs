using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Player;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    DataBaseConnector dbConnector;

    public MainWindow()
    {
        InitializeComponent();
        AddFunctional();
    }


// - - - Transition between windows - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    private void EnterToAccontCreate_Click(object sender, MouseButtonEventArgs e)
    {
        GridForAcciuntCreating.Visibility = Visibility.Visible;
        GridForEnter.Visibility = Visibility.Hidden;
        GridForAcciuntEdit.Visibility = Visibility.Hidden;
        GridForBooking.Visibility = Visibility.Hidden;
    }
    private void EnterToEnter_Click(object sender, MouseButtonEventArgs e)
    {
        GridForEnter.Visibility = Visibility.Visible;
        GridForAcciuntCreating.Visibility = Visibility.Hidden;
        GridForBooking.Visibility = Visibility.Hidden;
        GridForAcciuntEdit.Visibility = Visibility.Hidden;
    }
    private void EnterToBooking_Click(object sender, MouseButtonEventArgs e)
    {
        GridForBooking.Visibility = Visibility.Visible;
        GridForAcciuntEdit.Visibility = Visibility.Hidden;
        GridForAcciuntCreating.Visibility = Visibility.Hidden;
        GridForEnter.Visibility = Visibility.Hidden;
    }
    private void EnterToAccountEdit_Click(object sender, MouseButtonEventArgs e)
    {
        GridForBooking.Visibility = Visibility.Hidden;
        GridForAcciuntEdit.Visibility = Visibility.Visible;
        GridForAcciuntCreating.Visibility = Visibility.Hidden;
        GridForEnter.Visibility = Visibility.Hidden;
    }


// - - - System events - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    private void ExitApplication_Click(object sender, MouseButtonEventArgs e)
    {
        Application.Current.Shutdown();
    }
    private void HideWindow_Click(object sender, MouseButtonEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }
    private void MoveWindow_MousePeess(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            this.DragMove();
        }
    }


// - - - Mouse enter leave reactions red - black - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

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
    private void GridExitToEnterBooking_MouseEnter(object sender, MouseEventArgs e)
    {
        ExitLabelBooking.Foreground = Brushes.Red;
    }
    private void GridExitToEnterBooking_MouseLeave(object sender, MouseEventArgs e)
    {
        ExitLabelBooking.Foreground = Brushes.Black;
    }
    private void EnterLabelBooking_MouseEnter(object sender, MouseEventArgs e)
    {
        EnterLabelBooking.Foreground = Brushes.Red;
    }
    private void EnterLabelBooking_MouseLeave(object sender, MouseEventArgs e)
    {
        EnterLabelBooking.Foreground = Brushes.Black;
    }
    private void EoforvikLabel_MouseEnter(object sender, MouseEventArgs e)
    {
        EoforvikLabel.Foreground = Brushes.Red;
    }
    private void EoforvikLabel_MouseLeave(object sender, MouseEventArgs e)
    {
        EoforvikLabel.Foreground = Brushes.Black;
    }
    private void LondonLabel_MouseEnter(object sender, MouseEventArgs e)
    {
        LondonLabel.Foreground = Brushes.Red;
    }
    private void LondonLabel_MouseLeave(object sender, MouseEventArgs e)
    {
        LondonLabel.Foreground = Brushes.Black;
    }
    private void AhenLabel_MouseEnter(object sender, MouseEventArgs e)
    {
        AhenLabel.Foreground = Brushes.Red;
    }
    private void AhenLabel_MouseLeave(object sender, MouseEventArgs e)
    {
        AhenLabel.Foreground = Brushes.Black;
    }
    private void RomeLabel_MouseEnter(object sender, MouseEventArgs e)
    {
        RomeLabel.Foreground = Brushes.Red;
    }
    private void RomeLabel_MouseLeave(object sender, MouseEventArgs e)
    {
        RomeLabel.Foreground = Brushes.Black;
    }
    private void ConstantinopleLabel_MouseEnter(object sender, MouseEventArgs e)
    {
        ConstantinopleLabel.Foreground = Brushes.Red;
    }
    private void ConstantinopleLabel_MouseLeave(object sender, MouseEventArgs e)
    {
        ConstantinopleLabel.Foreground = Brushes.Black;
    }
    private void DamascusLabel_MouseEnter(object sender, MouseEventArgs e)
    {
        DamascusLabel.Foreground = Brushes.Red;
    }
    private void DamascusLabel_MouseLeave(object sender, MouseEventArgs e)
    {
        DamascusLabel.Foreground = Brushes.Black;
    }
    private void GridEditAccountBooking_MouseEnter(object sender, MouseEventArgs e)
    {
        EditAccountLabelBooking.Foreground = Brushes.Red;
    }
    private void GridEditAccountBooking_MouseLeave(object sender, MouseEventArgs e)
    {
        EditAccountLabelBooking.Foreground = Brushes.Black;
    }
    private void GridHelpBooking_MouseEnter(object sender, MouseEventArgs e)
    {
        HelpLabelBooking.Foreground = Brushes.Red;
    }
    private void GridHelpBooking_MouseLeave(object sender, MouseEventArgs e)
    {
        HelpLabelBooking.Foreground = Brushes.Black;
    }


    // - - - Mouse enter leave reactions yellow - white - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    private void GridExitToAccountEdit_MouseEnter(object sender, MouseEventArgs e)
    {
        ExitLabelAccountEdit.Foreground = Brushes.Yellow;
    }

    private void GridExitToAccountEdit_MouseLeave(object sender, MouseEventArgs e)
    {
        ExitLabelAccountEdit.Foreground = Brushes.White;
    }

    private void GridSaveAccountEdit_MouseEnter(object sender, MouseEventArgs e)
    {
        SaveLabelAccountEdit.Foreground = Brushes.Yellow;
    }
    private void GridSaveAccountEdit_MouseLeave(object sender, MouseEventArgs e)
    {
        SaveLabelAccountEdit.Foreground = Brushes.White;
    }
    private void GridTicketsAccountEdit_MouseEnter(object sender, MouseEventArgs e)
    {
        TicketsLabelAccountEdit.Foreground = Brushes.Yellow;
    }
    private void GridTicketsAccountEdit_MouseLeave(object sender, MouseEventArgs e)
    {
        TicketsLabelAccountEdit.Foreground = Brushes.White;
    }


// - - - Other - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    private void FillTextBox_Click(object sender, MouseButtonEventArgs e)
    {
        if(e.Source is Label sourceLabel)
        {
            if (WhereFromTextBoxBooking.IsFocused)
            {
                string pointName = sourceLabel.Content.ToString() ?? throw new NullReferenceException();
                WhereFromTextBoxBooking.Text = pointName.Substring(1, pointName.Length - 2);
            }
            else if (WhereToTextBoxBooking.IsFocused)
            {
                string pointName = sourceLabel.Content.ToString() ?? throw new NullReferenceException();
                WhereToTextBoxBooking.Text = pointName.Substring(1, pointName.Length - 2);
            }
        }
    }
    private void ClearField_IsVisibleChange(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (sender is TextBox sourceLabel)
        {
            sourceLabel.Clear();
        }
    }
}