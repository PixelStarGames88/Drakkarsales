using System.Windows;

namespace Player;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private void AddFunctional()
    {
        dbConnector = new DataBaseConnector();
        dbConnector.ConnectionToDataBase();
    }

}
