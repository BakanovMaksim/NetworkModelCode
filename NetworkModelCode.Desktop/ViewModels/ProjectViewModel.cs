using Microsoft.Win32;

using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Desktop.DTO;
using NetworkModelCode.Infrastructure.Business;

using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkModelCode.Desktop.ViewModels
{
    internal class ProjectViewModel
    {
        public WorkComplexImporter Importer { get; }
        public ObservableCollection<WorkDataSourceDTO> WorkDataSourceDTOs { get; set; }
        public ObservableCollection<WorkTimeCharacteristicDTO> WorkTimeCharacteristicDTOs { get; set; }

        public ProjectViewModel()
        {
            Importer = new();
            WorkDataSourceDTOs = new();
            WorkTimeCharacteristicDTOs = new();
        }

        public void CalculateWorkTimeCharacteristic()
        {
            var workDataSource = Mapper.MapCollection<WorkDataSourceDTO,ItemDataSource, ObservableCollection<WorkDataSourceDTO>,ObservableCollection<ItemDataSource>>(WorkDataSourceDTOs);

            var calculator = new WorkTimeCharacteristicCalculator(workDataSource.ToList());
            var workTimeCharacteristics = calculator.Calculate();

            foreach (var itemTimeCharacteristic in workTimeCharacteristics)
            {
                var workTimeCharacteristicDto = Mapper.Map<ItemTimeCharacteristic, WorkTimeCharacteristicDTO>(itemTimeCharacteristic);
                WorkTimeCharacteristicDTOs.Add(workTimeCharacteristicDto);
            }
        }

        public async Task ImportWorkDataSourceAsync()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if ((bool)openFileDialog.ShowDialog())
            {
                var workDataSource = await Importer.ImportAsync(openFileDialog.FileName);

                foreach (var itemDataSource in workDataSource)
                {
                    var workDataSourceDTO = Mapper.Map<ItemDataSource, WorkDataSourceDTO>(itemDataSource);
                    WorkDataSourceDTOs.Add(workDataSourceDTO);
                }
            }
        }
    }
}
