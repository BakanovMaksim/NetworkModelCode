using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Builders;
using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Desktop.DTO;
using NetworkModelCode.Desktop.Infrastructure;
using NetworkModelCode.Desktop.Models;
using NetworkModelCode.Desktop.Services;
using NetworkModelCode.Desktop.Views;
using NetworkModelCode.Infrastructure.Business;
using NetworkModelCode.Infrastructure.Data;

using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkModelCode.Desktop.ViewModels
{
    internal class ProjectViewModel
    {
        private IDialogService DefaultDialogService { get; }
        private UnitOfWork UnitOfWork { get; }
        private ProjectImporter Importer { get; }
        private ProjectExporter Exporter { get; }
        public ObservableCollection<ItemDataSourceDTO> ItemsDataSourceDTO { get; set; }
        public ObservableCollection<ItemTimeCharacteristicDTO> ItemsTimeCharacteristicDTO { get; set; }
        public Project Project { get; private set; }
        public ProjectDTO ProjectDTO { get; set; }
        public Chart Chart { get; set; }

        public ProjectViewModel()
        {
            DefaultDialogService = new DefaultDialogService();
            UnitOfWork = new UnitOfWork(new NetworkModelContext());
            Importer = new();
            Exporter = new();
            ItemsDataSourceDTO = new();
            ItemsTimeCharacteristicDTO = new();
            ProjectDTO = new();
        }

        public void CalculateWorkTimeCharacteristic()
        {
            var itemsDataSource = Mapper.
                MapCollection<ItemDataSourceDTO, ItemDataSource, ObservableCollection<ItemDataSourceDTO>, ObservableCollection<ItemDataSource>>(ItemsDataSourceDTO);

            var workTimeCharacteristicCalculator = new WorkTimeCharacteristicCalculator();
            var itemsTimeCharacteristic = workTimeCharacteristicCalculator.Calculate(itemsDataSource.ToList()).ToList();

            foreach (var item in itemsTimeCharacteristic)
            {
                var workTimeCharacteristicDto = Mapper.Map<ItemTimeCharacteristic, ItemTimeCharacteristicDTO>(item);
                ItemsTimeCharacteristicDTO.Add(workTimeCharacteristicDto);
            }

            Project = new ProjectBuilder()
                .SetTitle(ProjectDTO.Title)
                .SetWorkCount(ProjectDTO.WorkCount)
                .SetItemsDataSource(itemsDataSource.ToList())
                .SetItemsTimeCharacteristic(itemsTimeCharacteristic)
                .Build();

            //await UnitOfWork.Projects.AddAsync(Project);
            //await UnitOfWork.ItemsDataSource.AddRangeAsync(Project.ItemsDataSource);
            //await UnitOfWork.ItemsTimeCharacteristic.AddRangeAsync(Project.ItemsTimeCharacteristic);
        }

        public async Task ImportWorkDataSourceAsync()
        {
            var openFileDialog = DefaultDialogService.OpenFile();

            if (openFileDialog)
            {
                var project = await Importer.ImportAsync(DefaultDialogService.FileName);

                foreach (var item in project.ItemsDataSource)
                {
                    var workDataSourceDTO = Mapper.Map<ItemDataSource, ItemDataSourceDTO>(item);
                    ItemsDataSourceDTO.Add(workDataSourceDTO);
                }
            }
        }

        public async Task ExportWorkComplexAsync()
        {
            var saveFileDialog = DefaultDialogService.SaveFile();

            if (saveFileDialog)
            {
                await Exporter.ExportAsync(DefaultDialogService.FileName, Project);
            }
        }

        public void ConfigureProject()
        {
            var projectSettingWindow = new ProjectSettingWindow(ProjectDTO);
            projectSettingWindow.ShowDialog();
        }

        public Chart ConfigureChart()
        {
            return ChartConfiguration.Configure(ItemsDataSourceDTO);
        }
    }
}
