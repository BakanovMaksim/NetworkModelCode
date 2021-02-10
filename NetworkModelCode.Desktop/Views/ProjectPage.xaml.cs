using NetworkModelCode.Desktop.ViewModels;

using System.Linq;
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
            ProjectViewModel.CalculateWorkTimeCharacteristic();

            var chart = ProjectViewModel.ConfigureChart();

            var axisX = new LiveCharts.Wpf.AxesCollection();
            axisX.Add(new LiveCharts.Wpf.Axis() { Labels = chart.XAxisLabels.ToList() });

            var axisY = new LiveCharts.Wpf.AxesCollection();
            axisY.Add(new LiveCharts.Wpf.Axis() { Labels = chart.YAxisLabels.ToList() });

            ChartGantt.AxisX = axisX;
            ChartGantt.AxisY = axisY;
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
    }
}
