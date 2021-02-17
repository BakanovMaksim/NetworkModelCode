using LiveCharts.Wpf;

using NetworkModelCode.Desktop.ViewModels;

using System.ComponentModel;
using System.Windows.Controls;

namespace NetworkModelCode.Desktop.Views
{
    public partial class ProjectPage : Page
    {
        internal ProjectViewModel ProjectViewModel { get; }
        public ProjectPage()
        {
            InitializeComponent();

            ProjectViewModel = new ProjectViewModel();
            DataContext = ProjectViewModel;
        }

        private void enterButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ProjectViewModel.CalculateProjectData();

            var chart = (CartesianChart)ProjectViewModel.GetChart();
            ChartGantt.AxisX = chart.AxisX;
            ChartGantt.AxisY = chart.AxisY;
            ChartGantt.Series = chart.Series;
        }

        private void workTimeCharacteristicDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;
        }

        private void workSourceDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;
        }

        private async void importButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            await ProjectViewModel.ImportWorkDataSourceAsync();
        }

        private async void exportButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            await ProjectViewModel.ExportWorkComplexAsync();
        }

        private void settingButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ProjectViewModel.ConfigureProject();
        }

        private async void saveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            await ProjectViewModel.SaveProjecAsync();
        }
    }
}
