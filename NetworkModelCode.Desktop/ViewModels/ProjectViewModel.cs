﻿using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Builders;
using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Desktop.DTO;
using NetworkModelCode.Desktop.Services;
using NetworkModelCode.Infrastructure.Business;

using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkModelCode.Desktop.ViewModels
{
    internal class ProjectViewModel
    {
        private IDialogService DefaultDialogService { get; }
        private ProjectImporter Importer { get; }
        private ProjectExporter Exporter { get; }
        public ObservableCollection<ItemDataSourceDTO> WorkDataSourceDTOs { get; set; }
        public ObservableCollection<ItemTimeCharacteristicDTO> WorkTimeCharacteristicDTOs { get; set; }
        public Project Project { get; private set; }

        public ProjectViewModel()
        {
            DefaultDialogService = new DefaultDialogService();
            Importer = new();
            Exporter = new();
            WorkDataSourceDTOs = new();
            WorkTimeCharacteristicDTOs = new();
        }

        public void CalculateWorkTimeCharacteristic()
        {
            var workDataSource = Mapper.
                MapCollection<ItemDataSourceDTO,ItemDataSource, ObservableCollection<ItemDataSourceDTO>,ObservableCollection<ItemDataSource>>(WorkDataSourceDTOs);

            var workTimeCharacteristiccalculator = new WorkTimeCharacteristicCalculator();
            var workTimeCharacteristics = workTimeCharacteristiccalculator.Calculate(workDataSource.ToList()).ToList();

            var criticalPathCalctulator = new CriticalPathCalculator();
            var length = criticalPathCalctulator.Calculate(workDataSource.ToList(), workTimeCharacteristics);

            Project = new ProjectBuilder()
                .SetWorkCount(workDataSource.Count)
                .SetWorkDataSource(workDataSource.ToList())
                .SetWorkTimeCharacteristics(workTimeCharacteristics)
                .SetCriticalPathLength(length)
                .Build();

            foreach (var itemTimeCharacteristic in workTimeCharacteristics)
            {
                var workTimeCharacteristicDto = Mapper.Map<ItemTimeCharacteristic, ItemTimeCharacteristicDTO>(itemTimeCharacteristic);
                WorkTimeCharacteristicDTOs.Add(workTimeCharacteristicDto);
            }
        }

        public async Task ImportWorkDataSourceAsync()
        {
            var openFileDialog = DefaultDialogService.OpenFile();

            if (openFileDialog)
            {
                var workDataSource = await Importer.ImportAsync(DefaultDialogService.FileName);

                foreach (var itemDataSource in workDataSource)
                {
                    var workDataSourceDTO = Mapper.Map<ItemDataSource, ItemDataSourceDTO>(itemDataSource);
                    WorkDataSourceDTOs.Add(workDataSourceDTO);
                }
            }
        }

        public async Task ExportWorkComplexAsync()
        {
            var saveFileDialog = DefaultDialogService.SaveFile();

            if(saveFileDialog)
            {
                await Exporter.ExportAsync(DefaultDialogService.FileName, Project);
            }
        }
    }
}
