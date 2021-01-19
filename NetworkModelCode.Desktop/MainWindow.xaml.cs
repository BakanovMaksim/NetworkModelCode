using NetworkModelCode.Desktop.Views;

using System.Windows;

namespace NetworkModelCode.DesktopWpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ProjectPage());
        }
    }
}
