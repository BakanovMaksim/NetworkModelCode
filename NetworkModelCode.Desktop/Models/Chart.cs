using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NetworkModelCode.Desktop.Models
{
    public class Chart : INotifyPropertyChanged
    {
        private ObservableCollection<string> xAxisLabels;
        public ObservableCollection<string> XAxisLabels
        {
            get => xAxisLabels;
            set
            {
                xAxisLabels = value;
                OnPropertyChanged(nameof(XAxisLabels));
            }
        }

        private ObservableCollection<string> yAxisLabels;
        public ObservableCollection<string> YAxisLabels
        {
            get => yAxisLabels;
            set
            {
                yAxisLabels = value;
                OnPropertyChanged(nameof(YAxisLabels));
            }
        }

        public ObservableCollection<int> Series { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
