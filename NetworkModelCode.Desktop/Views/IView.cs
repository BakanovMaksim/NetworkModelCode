using System.Windows.Forms;

namespace NetworkModelCode.Desktop.Views
{
    public interface IView
    {
        MenuStrip MenuStrip { get; }
        DataGridView DataGridView { get; }
        Button EnterButton { get; }
        string NumberWorkCountTxt { get; set; }
    }
}
