using NetworkModelCode.Desktop.Views;
using NetworkModelCode.Infrastructure.Business.Parsers;
using NetworkModelCode.Core.Application.Calculators;

using System.Text;
using System.Linq;
using System.Windows.Forms;

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
            stringBuilder.Append($"n={View.DataGridView.RowCount - 1}\n");

            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < View.DataGridView.RowCount - 1; i++)
                {
                    if(i == 0)
                        stringBuilder.Append($"{View.DataGridView.Columns[j].HeaderCell.Value}={View.DataGridView.Rows[i].Cells[j].Value}");
                    else
                        stringBuilder.Append($",{View.DataGridView.Rows[i].Cells[j].Value}");
                }

                stringBuilder.Append("\n");
            }

            var parser = new MathModelFileParser();
            var isTry = parser.TryParseSource(stringBuilder.ToString(), out var mathModelSource);

            var calculator = new MathModelTemporaryCalculator(mathModelSource);
            var mathModelTemporary = calculator.Calculate();

            for(int i = 0;i<View.DataGridView.RowCount - 1;i++)
            {
                View.DataGridView.Rows[i].Cells["columnEarlyStart"].Value = mathModelTemporary.EarlyStarts.ToList()[i].ToString();
                View.DataGridView.Rows[i].Cells["columnEarlyEnd"].Value = mathModelTemporary.EarlyEnds.ToList()[i].ToString();
                View.DataGridView.Rows[i].Cells["columnLateStart"].Value = mathModelTemporary.LateStarts.ToList()[i].ToString();
                View.DataGridView.Rows[i].Cells["columnLateEnd"].Value = mathModelTemporary.LateEnds.ToList()[i].ToString();
                View.DataGridView.Rows[i].Cells["columnFullTimeReserve"].Value = mathModelTemporary.FullTimeReserves.ToList()[i].ToString();
                View.DataGridView.Rows[i].Cells["columnFreeTimeReserve"].Value = mathModelTemporary.FreeTimeReserves.ToList()[i].ToString();
            }
        }
    }
}
