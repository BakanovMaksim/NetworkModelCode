using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Infrastructure.Business.Parsers;
using NetworkModelCode.Desktop.Models;

using System.Windows.Controls;

namespace NetworkModelCode.Desktop.ViewModels
{
    public class ProjectViewModel
    {
        public Project Project { get; }
        private MathModelFileParser Parser { get; }

        public ProjectViewModel()
        {
            Project = new Project();
            Parser = new MathModelFileParser();
        }

        public void CalculateMathModelTemporary(DataGrid dataGrid)
        {
            var isTry = Parser.TryParseSource(Project.Data, out var mathModelSource);

            if(isTry)
            {
                var calculator = new MathModelTemporaryCalculator(mathModelSource);
                var mathModelTemporary = calculator.Calculate();
            }
        }
    }
}
