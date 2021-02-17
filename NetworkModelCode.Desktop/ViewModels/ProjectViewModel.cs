using LiveCharts.Wpf.Charts.Base;

using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Builders;
using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Desktop.DTO;
using NetworkModelCode.Desktop.Infrastructure;
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
        public ObservableCollection<TechnologicalConditionDTO> TechnologicalConditionDTOs { get; set; }
        public ObservableCollection<TimeCharacteristicDTO> TimeCharacteristicDTOs { get; set; }
        public ObservableCollection<ResourceDTO> ResourceDTOs { get; set; }
        public Project Project { get; private set; }
        public ProjectDTO ProjectDTO { get; set; }

        public ProjectViewModel()
        {
            DefaultDialogService = new DefaultDialogService();
            UnitOfWork = new UnitOfWork(new NetworkModelContext());
            Importer = new();
            Exporter = new();
            TechnologicalConditionDTOs = new();
            TimeCharacteristicDTOs = new();
            ResourceDTOs = new();
            ProjectDTO = new();
        }

        public void CalculateProjectData()
        {
            var technologicalConditions = Mapper
                .MapCollection<
                    TechnologicalConditionDTO,
                    TechnologicalCondition,
                    ObservableCollection<TechnologicalConditionDTO>,
                    ObservableCollection<TechnologicalCondition>>
                    (TechnologicalConditionDTOs).ToList();

            var resources = Mapper
                .MapCollection<
                ResourceDTO,
                Resource,
                ObservableCollection<ResourceDTO>,
                ObservableCollection<Resource>>
                (ResourceDTOs).ToList();

            var networkEventCalculator = new NetworkEventCalculator();
            var networkEvents = networkEventCalculator.Calculate(technologicalConditions).ToList();
            var timeCharacteristicCalculator = new TimeCharacteristicCalculator();
            var timeCharacteristics = timeCharacteristicCalculator.Calculate(technologicalConditions, networkEvents).ToList();

            foreach (var item in timeCharacteristics)
            {
                var timeCharacteristicDto = Mapper.Map<TimeCharacteristic, TimeCharacteristicDTO>(item);
                TimeCharacteristicDTOs.Add(timeCharacteristicDto);
            }

            Project = new ProjectBuilder()
                .SetTitle(ProjectDTO.Title)
                .SetWorkCount(ProjectDTO.WorkCount)
                .SetTechnologicalConditions(technologicalConditions)
                .SetResources(resources)
                .SetNetworkEvents(networkEvents)
                .SetTimeCharacteristics(timeCharacteristics)
                .Build();
        }

        public async Task SaveProjecAsync()
        {
            await UnitOfWork.Projects.AddAsync(Project);
            await UnitOfWork.TechnologicalConditions.AddRangeAsync(Project.TechnologicalConditions);
            await UnitOfWork.TimeCharacteristics.AddRangeAsync(Project.TimeCharacteristics);
        }

        public async Task ImportWorkDataSourceAsync()
        {
            var openFileDialog = DefaultDialogService.OpenFile();

            if (openFileDialog)
            {
                var project = await Importer.ImportAsync(DefaultDialogService.FileName);

                foreach (var item in project.TechnologicalConditions)
                {
                    var workDataSourceDTO = Mapper.Map<TechnologicalCondition, TechnologicalConditionDTO>(item);
                    TechnologicalConditionDTOs.Add(workDataSourceDTO);
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

        public Chart GetChart()
        {
            return ChartConfiguration.Configure(TechnologicalConditionDTOs, TimeCharacteristicDTOs);
        }
    }
}
