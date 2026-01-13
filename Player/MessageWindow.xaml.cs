using System.Windows;
using System.Windows.Media;

namespace Player
{
    /// <summary>
    /// Логика взаимодействия для MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow(string message)
        {
            InitializeComponent();
            MessageLabelMessage.Content = message;
        }

        private void GotItLabelMessage_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            GotItLabelMessage.Foreground = Brushes.Red;
        }

        private void GotItLabelMessage_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            GotItLabelMessage.Foreground = Brushes.Black;
        }
        private void CloseWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MoveWindow_MousePress(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
