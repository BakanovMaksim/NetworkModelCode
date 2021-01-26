using NetworkModelCode.Desktop.Views;
using NetworkModelCode.Desktop.Infrastructure;

using System.Windows;

namespace NetworkModelCode.DesktopWpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FrameManager.NavigationService = mainFrame.NavigationService;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationService.Navigate(new ProjectPage());
        }

        private void existingProjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationService.Navigate(new ExistingProjectPage());
        }

        private void goBackMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (FrameManager.NavigationService.CanGoBack)
            {
                FrameManager.NavigationService.GoBack();
            }
        }
    }
}
