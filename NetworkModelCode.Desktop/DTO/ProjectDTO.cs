using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NetworkModelCode.Desktop.DTO
{
    public class ProjectDTO : INotifyPropertyChanged
    {
        private string title = "Новый проект";
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private int workCount;
        public int WorkCount
        {
            get
            {
                return workCount;
            }
            set
            {
                workCount = value;
                OnPropertyChanged(nameof(WorkCount));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
