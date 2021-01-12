using NetworkModelCode.Desktop.Views;

using System.Text;

namespace NetworkModelCode.Desktop.Presenters
{
    public class MathModelPresenter
    {
        private IView View { get; }

        public MathModelPresenter(IView view)
        {
            View = view;
        }

        public void ConfigureDataGridView()
        {
            var isTry = int.TryParse(View.NumberWorkCountTxt, out var count);

            if (isTry)
            {
                View.DataGridView.RowCount = count;

                for (int k = 0; k < count; k++)
                {
                    View.DataGridView.Rows[k].HeaderCell.Value = (k + 1).ToString();
                }
            }
        }

        public void CalculateMathModelTemporary()
        {
            var stringBuilder = new StringBuilder();

            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < View.DataGridView.RowCount; i++)
                {
                    stringBuilder.AppendLine(View.DataGridView.Rows[i].Cells[j].Value.ToString());
                }

                stringBuilder.Append("\n");
            }
        }
    }
}
