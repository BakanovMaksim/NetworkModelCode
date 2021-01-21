using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Infrastructure.Business.Parsers;
using NetworkModelCode.Desktop.Models;

using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetworkModelCode.Desktop.ViewModels
{
    public class ProjectViewModel
    {
        public Project Project { get; }
        public IReadOnlyList<WorkDataSource> workDataSource;
        public ObservableCollection<WorkTimeCharacteristic> WorkTimeCharacteristics { get; set; }
        private WorkTextParser Parser { get; }

        public ProjectViewModel()
        {
            Project = new();
            Parser = new();
            WorkTimeCharacteristics = new();
        }

        public void CalculateMathModelTemporary()
        {
            Project.Data = "n=8\ni=1,1,2,2,3,3,5,5\nj=2,3,3,4,4,5,6,6\nt=5,2,0,3,7,6,4,5";

            var isTry = Parser.TryParseWorkDataSource(Project.Data, out workDataSource);

            if (isTry)
            {
                var calculator = new WorkTimeCharacteristicCalculator(workDataSource);
                var workTimeCharacteristics = calculator.Calculate();
                foreach(var item in workTimeCharacteristics)
                {
                    WorkTimeCharacteristics.Add(item);
                }
            }
        }
    }
}
