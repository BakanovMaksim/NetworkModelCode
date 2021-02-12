using NetworkModelCode.Infrastructure.Data;

using System.Windows.Controls;

namespace NetworkModelCode.Desktop.Views
{
    public partial class ProjectsMenuPage : Page
    {
        public UnitOfWork UnitOfWork { get; }

        public ProjectsMenuPage()
        {
            InitializeComponent();

            UnitOfWork = new(new NetworkModelContext());

            DataContext = this;

            projectListBox.ItemsSource = UnitOfWork.Projects.GetAll();
        }
    }
}
