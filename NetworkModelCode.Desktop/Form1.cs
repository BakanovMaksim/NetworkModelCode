using NetworkModelCode.Desktop.Presenters;
using NetworkModelCode.Desktop.Views;

using System.Windows.Forms;

namespace NetworkModelCode.Desktop
{
    public partial class Form1 : Form, IView
    {
        public MenuStrip MenuStrip => menuStrip;
        public DataGridView DataGridView => dataGridView;
        public Button EnterButton => enterButton;
        public string NumberWorkCountTxt
        {
            get => numberWorkCountTxt.Text;
            set => numberWorkCountTxt.Text = value;
        }

        private MathModelPresenter MathModelPresenter { get; }

        public Form1()
        {
            InitializeComponent();

            MathModelPresenter = new MathModelPresenter(this);
        }

        private void numberWorkCountTxt_TextChanged(object sender, System.EventArgs e)
        {
            MathModelPresenter.ConfigureDataGridView();
        }

        private void enterButton_Click(object sender, System.EventArgs e)
        {
            MathModelPresenter.CalculateMathModelTemporary();
        }
    }
}
