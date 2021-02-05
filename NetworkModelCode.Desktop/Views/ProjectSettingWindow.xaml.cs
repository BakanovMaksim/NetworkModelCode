using NetworkModelCode.Desktop.DTO;

using System.Windows;

namespace NetworkModelCode.Desktop.Views
{
    public partial class ProjectSettingWindow : Window
    {
        public ProjectSettingWindow()
        {
            InitializeComponent();
        }

        public ProjectSettingWindow(ProjectDTO projectDTO)
        {
            InitializeComponent();

            DataContext = projectDTO;
        }

        private void saveSettingButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
