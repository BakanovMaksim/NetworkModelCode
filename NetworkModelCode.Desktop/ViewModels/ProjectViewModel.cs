using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Builders;
using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Core.Domain.Interfaces;
using NetworkModelCode.Desktop.DTO;
using NetworkModelCode.Desktop.Services;
using NetworkModelCode.Infrastructure.Business;
using NetworkModelCode.Infrastructure.Data;
using NetworkModelCode.Infrastructure.Data.Repositories;

using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkModelCode.Desktop.ViewModels
{
    internal class ProjectViewModel
    {
        private IDialogService DefaultDialogService { get; }
        private IRepository<Project> ProjectRepository { get; }
        private IRepository<ItemDataSource> ItemDataSourceRepository { get; }
        private IRepository<ItemTimeCharacteristic> ItemTimeCharacteristicRepository { get; }
        private ProjectImporter Importer { get; }
        private ProjectExporter Exporter { get; }
        public ObservableCollection<ItemDataSourceDTO> WorkDataSourceDTOs { get; set; }
        public ObservableCollection<ItemTimeCharacteristicDTO> WorkTimeCharacteristicDTOs { get; set; }
        public Project Project { get; private set; }

        public ProjectViewModel()
        {
            var context = new NetworkModelContext();

            DefaultDialogService = new DefaultDialogService();
            ProjectRepository = new ProjectRepository(context);
            ItemDataSourceRepository = new ItemDataSourceRepository(context);
            ItemTimeCharacteristicRepository = new ItemTimeCharacteristicRepository(context);
            Importer = new();
            Exporter = new();
            WorkDataSourceDTOs = new();
            WorkTimeCharacteristicDTOs = new();
        }

        public async Task CalculateWorkTimeCharacteristic()
        {
            var workDataSource = Mapper.
                MapCollection<ItemDataSourceDTO,ItemDataSource, ObservableCollection<ItemDataSourceDTO>,ObservableCollection<ItemDataSource>>(WorkDataSourceDTOs);

            var workTimeCharacteristiccalculator = new WorkTimeCharacteristicCalculator();
            var workTimeCharacteristics = workTimeCharacteristiccalculator.Calculate(workDataSource.ToList()).ToList();

            foreach (var itemTimeCharacteristic in workTimeCharacteristics)
            {
                var workTimeCharacteristicDto = Mapper.Map<ItemTimeCharacteristic, ItemTimeCharacteristicDTO>(itemTimeCharacteristic);
                WorkTimeCharacteristicDTOs.Add(workTimeCharacteristicDto);
            }

            Project = new ProjectBuilder()
                .SetWorkCount(workDataSource.Count)
                .SetItemsDataSource(workDataSource.ToList())
                .SetItemsTimeCharacteristic(workTimeCharacteristics)
                .Build();

            await ProjectRepository.AddAsync(Project);
            await ItemDataSourceRepository.AddRangeAsync(Project.ItemsDataSource);
            await ItemTimeCharacteristicRepository.AddRangeAsync(Project.ItemsTimeCharacteristic);
        }

        public async Task ImportWorkDataSourceAsync()
        {
            var openFileDialog = DefaultDialogService.OpenFile();

            if (openFileDialog)
            {
                var project = await Importer.ImportAsync(DefaultDialogService.FileName);

                foreach (var itemDataSource in project.ItemsDataSource)
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
